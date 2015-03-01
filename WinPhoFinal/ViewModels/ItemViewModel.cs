using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WinPhoFinal
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string _title;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Title
        {
            get {
                return _title;
            }
            set {
                if (value != _title)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string _mpaaRating;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string MpaaRating
        {
            get
            {
                return _mpaaRating;
            }
            set
            {
                if (value != _mpaaRating)
                {
                    _mpaaRating = value;
                    NotifyPropertyChanged("MpaaRating");
                }
            }
        }

        private string _runtime;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Runtime
        {
            get
            {
                return _runtime;
            }
            set
            {
                if (value != _runtime)
                {
                    _runtime = value;
                    NotifyPropertyChanged("Runtime");
                }
            }
        }

        private string _rating;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Rating
        {
            get {
                return _rating;
            }
            set {
                if (value != _rating)
                {
                    _rating = value;
                    NotifyPropertyChanged("Rating");
                }
            }
        }

        private string _synopsis;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Synopsis
        {
            get
            {
                return _synopsis;
            }
            set
            {
                if (value != _synopsis)
                {
                    _synopsis = value;
                    NotifyPropertyChanged("Synopsis");
                }
            }
        }
        

        private string _release;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Release
        {
            get {
                return _release;
            }
            set {
                if (value != _release)
                {
                    _release = value;
                    NotifyPropertyChanged("Release");
                }
            }
        }

        private string _posterUrl;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string PosterUrl
        {
            get {
                return _posterUrl;
            }
            set {
                if (value != _posterUrl)
                {
                    _posterUrl = value;
                    NotifyPropertyChanged("PosterUrl");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}