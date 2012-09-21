using System;

namespace CTTDNUG.Model
{
    public class Tweet
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
