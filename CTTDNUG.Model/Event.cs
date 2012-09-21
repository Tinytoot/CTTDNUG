using System.Collections.Generic;

namespace CTTDNUG.Model
{
    public class Event2
    {
        public string box_header_text_color { get; set; }
        public string link_color { get; set; }
        public string box_background_color { get; set; }
        public string box_border_color { get; set; }
        public string timezone { get; set; }
        public Organizer organizer { get; set; }
        public string background_color { get; set; }
        public object id { get; set; }
        public string category { get; set; }
        public string box_header_background_color { get; set; }
        public int capacity { get; set; }
        public int num_attendee_rows { get; set; }
        public string title { get; set; }
        public string start_date { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string end_date { get; set; }
        public string tags { get; set; }
        public string timezone_offset { get; set; }
        public string text_color { get; set; }
        public string title_text_color { get; set; }
        public List<Ticket> tickets { get; set; }
        public string created { get; set; }
        public string url { get; set; }
        public string box_text_color { get; set; }
        public string privacy { get; set; }
        public Venue venue { get; set; }
        public string modified { get; set; }
        public string repeats { get; set; }
    }

    public class Event
    {
        public Event2 @event { get; set; }
    }

    public class Events
    {
        public List<Event> events { get; set; }
    }
}
