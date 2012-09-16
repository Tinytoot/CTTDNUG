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
using System.Collections.ObjectModel;

namespace CTTDNUG.Data
{
    public class TweetRepository: ITweetRepository
    {
//        public IList<Tweet> tweets { get; set; }

        public delegate void GetTweetsCompleted(ObservableCollection<Tweet> tweets);

        public void GetTweets(string searchPattern)
        {
            var client = new RestClient();
            client.BaseUrl = "http://search.twitter.com/search.json";
            var request = new RestRequest();
            request.AddParameter("q", searchPattern);
            client.ExecuteAsync<TweetQueryResults>(request, (restResponse) => {
                var tweets = JsonConvert.DeserializeObject<ObservableCollection<Tweet>>(restResponse.Data.results);
                GotTweets(tweets);  
            });
            
        }

        public event GetTweetsCompleted GotTweets;
    }
}
