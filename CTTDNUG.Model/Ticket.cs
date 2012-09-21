
namespace CTTDNUG.Model
{
    public class Ticket2
    {
        public string description { get; set; }
        public string end_date { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public string price { get; set; }
        public string visible { get; set; }
        public string start_date { get; set; }
        public string currency { get; set; }
        public int type { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Ticket
    {
        public Ticket2 ticket { get; set; }
    }
}
