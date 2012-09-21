using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.Reflection;

namespace CTTDNUG.Phone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.CttdnugVM;

         }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (!App.CttdnugVM.IsDataLoaded)
            {
                App.CttdnugVM.LoadData();
            }

            base.OnNavigatedTo(e);

        }

        private void Support_Click(object sender, RoutedEventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly().FullName;
            string version = assembly.Split('=')[1].Split(',')[0];

            EmailComposeTask emailcomposer = new EmailComposeTask();
            emailcomposer.To = "orangecrushie@gmail.com";
            emailcomposer.Subject = "Support Request from CTTDNUG " + version;
            emailcomposer.Body = "";
            emailcomposer.Show();
        }

        private void Review_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void OtherApps_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();
            marketplaceSearchTask.SearchTerms = "Orange Crush";
            marketplaceSearchTask.Show();
        }
 
    }
}