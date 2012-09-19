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
    public class Event
    {
        public string timezone { get; set; }
        public string organizer_url { get; set; }
        public string organizer_description { get; set; }
        public string organizer_long_description { get; set; }
        public int organizer_id { get; set; }
        public string organizer_name { get; set; }
        public int event_id { get; set; }
        public string category { get; set; }
        public int capacity { get; set; }
        public int num_attendee_rows { get; set; }
        public string title { get; set; }
        public DateTime start_date { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public DateTime end_date { get; set; }
        public string tags { get; set; }
        public string timezone_offset { get; set; }
        public DateTime created { get; set; }
        public string event_url { get; set; }
        public string privacy { get; set; }
        public string venue_city { get; set; }
        public string venue_name { get; set; }
        public string venue_country { get; set; }
        public string venue_region { get; set; }
        public double longitude { get; set; }
        public string  postal_code { get; set; }
        public string address_2 { get; set; }
        public string address { get; set; }
        public double latitude { get; set; }
        public string country_code { get; set; }
        public int venue_id { get; set; }
        public string Lat_Long { get; set; }


    }
}
