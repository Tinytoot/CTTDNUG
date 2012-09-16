using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using CTTDNUG.Model;
using CTTDNUG.Data;



namespace CTTDNUG.Phone
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Tweets = new ObservableCollection<Tweet>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }


        /// <summary>
        /// A List for TweetViewModel objects.
        /// </summary>
        public ObservableCollection<Tweet> Tweets { get; private set; }


        public bool IsDataLoaded
        {
  
            get;
            private set;
        }

        void GotTheTweets(ObservableCollection<Tweet> tweets)
        {
            Tweets = tweets ;
            NotifyPropertyChanged("Tweets");
        }
        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            var tweetRepository = new TweetRepository();
            tweetRepository.GotTweets+=new TweetRepository.GetTweetsCompleted(GotTheTweets);
            tweetRepository.GetTweets("#CTTDNUG");
            this.Tweets.Add(new Tweet() { from_user_name = "Bobby", text = "This is a test tweet!!" });


            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}