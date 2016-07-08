using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Smart_Timer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        Timer newTimer = new Timer();
        private readonly RoutedEventHandler textBlock1_Copy1_SelectionChanged;

        public BlankPage1()
        {
            this.InitializeComponent();
            
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            newTimer.Hours = Convert.ToInt32(sldHours.Value);
            newTimer.Minutes = Convert.ToInt32(sldMinutes.Value);
            newTimer.Seconds = Convert.ToInt32(sldSeconds.Value);

            MessageDialog dialog = new MessageDialog(newTimer.Hours.ToString());
            await dialog.ShowAsync();

            //this.Frame.Navigate(typeof(MainPage));
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
