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

namespace CTTDNUG.Model
{
    public class Venue
    {
        public string city { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public double longitude { get; set; }
        public string postal_code { get; set; }
        public string address_2 { get; set; }
        public string address { get; set; }
        public double latitude { get; set; }
        public string country_code { get; set; }
        public int id { get; set; }
    }
}
