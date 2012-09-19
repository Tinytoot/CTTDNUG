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
    public class EventBriteReponse
    {
         public string timezone { get; set; }
         public string organizer { get; set; }
         public int id { get; set; }
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
         public string url { get; set; }
         public string privacy { get; set; }
         public string venue { get; set; }
    }
}
