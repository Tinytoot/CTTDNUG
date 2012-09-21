using System.Collections.ObjectModel;
using CTTDNUG.Data.Helpers;
using CTTDNUG.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace CTTDNUG.Data
{
    public class TweetRepository: ITweetRepository
    {
   
        public delegate void GetTweetsCompleted(ObservableCollection<Tweet> tweets);
        public delegate void GetTweetsErrored(string failure);

        public void GetTweets(string searchPattern)
        {
            var client = new RestClient();
            client.BaseUrl = AppSettings.tweetUri;
            var request = new RestRequest();
            request.AddParameter("q", searchPattern);
            client.ExecuteAsync<TweetQueryResults>(request, (response) => {
               if (response.StatusCode == HttpStatusCode.OK)
                {
                    success(DeserializeTweets(response.Data));

                }
                else
                {
                    failure(response.ErrorMessage);
                }
            });
            
        }

        public event GetTweetsCompleted success;
        public event GetTweetsErrored failure;


        public ObservableCollection<Tweet> DeserializeTweets(TweetQueryResults tweets)
        {
            var tweetsObs = JsonConvert.DeserializeObject<ObservableCollection<Tweet>>(tweets.results);
            return tweetsObs;
        }
    }
}
