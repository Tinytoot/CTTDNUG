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
using CTTDNUG.Model;
using RestSharp;
using Newtonsoft.Json;

namespace CTTDNUG.Data
{
    public class TweetRepository: ITweetRepository
    {
        public IList<Tweet> GetTweets(string searchPattern)
        {
            var client = new RestClient();
            client.BaseUrl = "http://search.twitter.com/search.json";
            var request = new RestRequest();
            request.AddParameter("q", searchPattern);
            var response = client.ExecuteAsync<TweetQueryResults>(request);

            var tweets = JsonConvert.DeserializeObject<IList<tweet>>(response.Data.results);

            return tweets;

        }
    }
}
