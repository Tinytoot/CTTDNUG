using System.ComponentModel;
using System.Collections.ObjectModel;
using CTTDNUG.Model;
using CTTDNUG.Data;


namespace CTTDNUG.Phone.ViewModels
{
    public class TweetsViewModel: INotifyPropertyChanged
    {
       
        private ObservableCollection<Tweet> tweets;
        public ObservableCollection<Tweet> Tweets 
        {
            get { return tweets; }
            set
            {
                if (tweets != value)
                {
                    tweets = value;
                    RaisePropertyChanged("Tweets");
                }
            }
        }

        private bool isDataLoaded = false;
        public bool IsDataLoaded
        {
            get { return isDataLoaded; }

            set
            {
                if (isDataLoaded != value)
                {
                    isDataLoaded = value;
                    RaisePropertyChanged("IsDataLoaded");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }



        public void LoadData()
        {
            var tweetRepository = new TweetRepository();
            tweetRepository.GotTweets += new TweetRepository.GetTweetsCompleted(GotTheTweets);
            tweetRepository.GetTweets("#CTTDNUG");
            
            this.IsDataLoaded = true;
        }


        void GotTheTweets(ObservableCollection<Tweet> newTweets)
        {
            tweets = newTweets;
            RaisePropertyChanged("Tweets");

         }

    }
}
