using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WinPhoFinal.Models
{
    [DataContract(Name = "Movie", Namespace = ":jferna11")]
    public class Movie
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Rating { get; set; }
        [DataMember]
        public string MpaaRating { get; set; }
        [DataMember]
        public string Runtime { get; set; }
        [DataMember]
        public string Synopsis { get; set; }
        [DataMember]
        public string Release { get; set; }
        [DataMember]
        public string PosterUrl { get; set; }
    }
}
