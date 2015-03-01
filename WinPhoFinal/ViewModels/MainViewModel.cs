using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows.Media.Animation;
using Microsoft.Phone.Controls;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using WinPhoFinal.Models;
using System.Data.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;


namespace WinPhoFinal
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            requestData();

        }
        private void addData(Movie movie)
        {
            this.Items.Add(new ItemViewModel()
            {
                Title = movie.Title,
                Rating = movie.Rating,
                MpaaRating = movie.MpaaRating,
                Runtime = movie.Runtime,
                Synopsis = movie.Synopsis,
                Release = movie.Release,
                PosterUrl = movie.PosterUrl,
            });
            this.IsDataLoaded = true;
        }

        private void requestData()
        {
            string requestURL = "http://api.rottentomatoes.com/api/public/v1.0/lists/movies/in_theaters.json?apikey=f3nf55g8ezu9d8tvwrth9256";
            Uri uri = new Uri(requestURL, UriKind.Absolute);

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_RetrieveMovies);
            client.DownloadStringAsync(uri);
        }

        private void client_RetrieveMovies(object sender, DownloadStringCompletedEventArgs e)
        {
            //Use json.net to get result as a JObject then we can use indexing or LINQ to get the data
            Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(e.Result);
            JArray movieArray = (JArray) jObject.Children().ElementAt(1).First;
            int length = movieArray.Count;
            for (int i = 0; i < length; i++)
            {
                retrieveMovieDetails((JObject) movieArray.ElementAt(i));
            }
        }

        private void retrieveMovieDetails(JObject movie)
        {
            Movie m = new Movie();
            m.Title = movie["title"].ToString();
            m.MpaaRating = movie["mpaa_rating"].ToString();
            m.Runtime = movie["runtime"].ToString();
            m.Rating = movie["ratings"]["audience_score"].ToString();
            m.Synopsis = movie["synopsis"].ToString();
            m.Release = movie["release_dates"]["theater"].ToString();
            m.PosterUrl = movie["posters"]["detailed"].ToString();
            addData(m);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}