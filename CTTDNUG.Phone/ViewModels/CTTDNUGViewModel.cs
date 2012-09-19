using System.ComponentModel;
using System.Collections.ObjectModel;
using CTTDNUG.Model;
using CTTDNUG.Data;
using System.Collections.Generic;
using System;


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

        private ObservableCollection<Event> eventsObs;
        public ObservableCollection<Event> Events
        {
            get { return eventsObs; }
            set
            {
                if(eventsObs != value)
                {
                    eventsObs = value;
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
     //       LoadEvents();
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

        void GetCurrentEvents(List<EventBriteReponse> events)
        {
            foreach(EventBriteReponse response in events)
            {
                eventsObs.Add(new Event{
                timezone= response.timezone,
                organizer_url= response.url,
                organizer_description= "",
                organizer_long_description= "",
                organizer_id = 0,
                organizer_name = "",
                event_id = response.id,
                category = response.category,
                capacity = response.capacity,
                num_attendee_rows = response.num_attendee_rows,
                title = response.title,
                start_date = response.start_date,
                status = response.status,
                description = response.description,
                end_date = response.end_date,
                tags = response.tags,
                timezone_offset = response.timezone_offset,
                created = response.created,
                event_url = response.url,
                privacy = response.privacy,
                venue_city = "",
                venue_name = "",
                venue_country = "",
                venue_region = "",
                longitude = 0,
                postal_code = "" ,
                address_2 = "",
                address = "",
                latitude = 0.0,
                country_code = "",
                venue_id = 0,
                Lat_Long = ""
                });

            }

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
