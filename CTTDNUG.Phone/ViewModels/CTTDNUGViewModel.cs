using System.Collections.ObjectModel;
using System.ComponentModel;
using CTTDNUG.Data;
using CTTDNUG.Model;


namespace CTTDNUG.Phone.ViewModels
{
    public class CTTDNUGViewModel : INotifyPropertyChanged
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

        private ObservableCollection<Event> events;
        public ObservableCollection<Event> Events
        {
            get { return events; }
            set
            {
                if(events != value)
                {
                    events = value;
                    RaisePropertyChanged("Events");
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

        private bool eventError = false;
        public bool EventError
        {
            get { return eventError; }

            set
            {
                if (eventError != value)
                {
                    eventError = value;
                    RaisePropertyChanged("EventError");
                }
            }
        }


        private bool tweetError = false;
        public bool TweetError
        {
            get { return tweetError; }

            set
            {
                if (tweetError != value)
                {
                    tweetError = value;
                    RaisePropertyChanged("TweetError");
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
            LoadTweets();
            LoadEvents();
            this.IsDataLoaded = true;
        }

        public void LoadTweets()
        {
            var tweetRepository = new TweetRepository();
            tweetRepository.success += new TweetRepository.GetTweetsCompleted(TweetsLoadSuccessful);
            tweetRepository.failure += new TweetRepository.GetTweetsErrored(TweetsLoadFailed);
            tweetRepository.GetTweets("#CTTDNUG");
        }

        public void LoadEvents()
        {
            var eventRepository = new EventRepository();
            eventRepository.success += new EventRepository.GetEventsCompleted(EventLoadSucessful);
            eventRepository.failure += new EventRepository.GetEventsErrored(EventLoadFailed);
            eventRepository.GetEvents();
        }

        void EventLoadSucessful(ObservableCollection<Event> response)
        {
            events = response;
            RaisePropertyChanged("Events");
               
        }

        void EventLoadFailed(string error)
        {
            eventError = true;
            RaisePropertyChanged("EventError");
        }


        void TweetsLoadSuccessful(ObservableCollection<Tweet> newTweets)
        {
            tweets = newTweets;
            RaisePropertyChanged("Tweets");

         }

        void TweetsLoadFailed(string error)
        {
            tweetError = true;
            RaisePropertyChanged("TweetError");

        }

    }
}
