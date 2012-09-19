using CTTDNUG.Model;
using CTTDNUG.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace CTTDNUG.Phone.ViewModels
{
    public class EventsViewModel
    {
        private ObservableCollection<Event> events;
        public ObservableCollection<Event> Events
        {
            get { return events; }
            set
            {
                if (events != value)
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }



        public void LoadData()
        {
            var tweetRepository = new TweetRepository();
            tweetRepository.GetTweets("#CTTDNUG");

            this.IsDataLoaded = true;
        }

    }
}
