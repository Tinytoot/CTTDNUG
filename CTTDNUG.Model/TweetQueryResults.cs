using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTTDNUG.Model
{
    public class TweetQueryResults
    {
        public string completed_in { get; set; }
        public string results { get; set; }
    }

    public class tweet
    {
        public DateTime created_at { get; set; }
        public string from_user { get; set; }
        public int from_user_id { get; set; }
        public string from_user_id_str { get; set; }
        public string from_user_name { get; set; }
        public string profile_image_url { get; set; }
        public string profile_image_url_https { get; set; }
        public string source { get; set; }
        public string text { get; set; }
    }
}
