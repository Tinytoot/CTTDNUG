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
                    RaisePropertyChanged("LoadingEventError");
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
            tweetRepository.GotTweets += new TweetRepository.GetTweetsCompleted(GotTheTweets);
            tweetRepository.GetTweets("#CTTDNUG");
        }

        public void LoadEvents()
        {
            var eventRepository = new EventRepository();
            eventRepository.success += new EventRepository.GetEventsCompleted(GetCurrentEvents);
            eventRepository.failure += new EventRepository.GetEventsErrored(LoadingEventError);
            eventRepository.GetEvents();
        }

        void GetCurrentEvents(ObservableCollection<Event> response)
        {
            events = response;
            RaisePropertyChanged("Events");
               
        }

        void LoadingEventError(string error)
        {
            eventError = true;
            RaisePropertyChanged("LoadingEventError");
        }


        void GotTheTweets(ObservableCollection<Tweet> newTweets)
        {
            tweets = newTweets;
            RaisePropertyChanged("Tweets");

         }

    }
}
