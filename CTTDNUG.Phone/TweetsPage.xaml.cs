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
using Telerik.Windows.Controls;

namespace CTTDNUG.Phone
{
    public partial class TweetsPage : PhoneApplicationPage
    {
		private PivotBlocker pivotBlocker;

        public TweetsPage()
        {
            InitializeComponent();
            this.pivotBlocker = new PivotBlocker();
            this.DataContext = new MainDataViewModel();
        }

		private void RadDataBoundListBox_IsCheckModeActiveChanged(object sender, Telerik.Windows.Controls.IsCheckModeActiveChangedEventArgs e)
        {
            RadDataBoundListBox listBox = sender as RadDataBoundListBox;
            if (listBox == null)
            {
                return;
            }
            if (listBox.IsCheckModeActive)
            {
                this.pivotBlocker.Start(this.MainPivot);
            }
            else
            {
                this.pivotBlocker.End();
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (this.MainPivot.SelectedIndex == 0)
            {
                this.DataBoundListBox1.IsCheckModeActive ^= true;
            }
            else
            {
                this.DataBoundListBox2.IsCheckModeActive ^= true;
            }
        }
    }
}
