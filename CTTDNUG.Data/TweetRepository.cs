using CTTDNUG.Model;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using CTTDNUG.Data.Helpers;

namespace CTTDNUG.Data
{
    public class TweetRepository: ITweetRepository
    {
        public delegate void GetTweetsCompleted(ObservableCollection<Tweet> tweets);

        public void GetTweets(string searchPattern)
        {
            var client = new RestClient();
            client.BaseUrl = AppSettings.tweetUri;
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
