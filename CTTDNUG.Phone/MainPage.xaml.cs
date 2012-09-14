using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace CTTDNUG.Phone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = new MainDataViewModel();
        }

		private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            this.slideView.MoveToPreviousItem();
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            this.slideView.MoveToNextItem();
        }
    }
}
