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
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Smart_Timer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        Timer newTimer = new Timer();

        int hours = 0;
        int minutes = 0;
        int seconds = 0;

        public MainPage()
        {
            this.InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.Tick += timer_Tick;

            setTime();
        }

        private void setTime()
        {
            hours = newTimer.Hours;
            minutes = newTimer.Minutes;
            seconds = newTimer.Seconds;
        }

        private void timer_Tick(object sender, object e)
        {
            if (seconds == 0)
            {
                updateTime();
            }

            lblSeconds.Text = seconds--.ToString(); 
        }

        private async void button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog(newTimer.Hours.ToString());
            await dialog.ShowAsync();

            if (btnStart.Content.ToString() == "Start")
            {
                btnStart.Content = "Pause";
                timer.Stop();
            }
            else
            {
                btnStart.Content = "Start";
                timer.Start();
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            hours = 0;
            minutes = 0;
            seconds = 0;        
        }

        private void updateTime()
        {
            if(hours>0)
            {
                if(minutes == 0)
                {
                    hours--;
                    minutes = 59;
                    seconds = 59;
                    lblHours.Text = hours.ToString();
                    lblMinutes.Text = minutes.ToString();
                    lblSeconds.Text = seconds.ToString();
                }   
            }
            else if (minutes > 0)
            {
                minutes--;
                seconds = 59;
                lblMinutes.Text = minutes.ToString();
                lblSeconds.Text = seconds.ToString();
            }
            else if(hours ==0 && minutes == 0 && seconds ==0)
            {
                timer.Stop();
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage1));
        }
    }
}
