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
        static Timer new_timer;

        public static MediaElement mdPlayer = new MediaElement();

        static int hours = 0;
        static int minutes = 0;
        static int seconds = 0;

        public MainPage()
        {
            this.InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.Tick += timer_Tick;
        }

        public static void setTime(Timer newTimer)
        {
            new_timer = newTimer;
            setTime();
        }

        private static void setTime()
        {
            hours = new_timer.Hours;
            minutes = new_timer.Minutes;
            seconds = new_timer.Seconds;
        }

        private void timer_Tick(object sender, object e)
        {   
            if (seconds == 0)
            {
                updateTime();
            }

            lblHours.Text = String.Format("{0:00}", hours);
            lblMinutes.Text = String.Format("{0:00}", minutes);
            lblSeconds.Text = String.Format("{0:00}", seconds--);
        }

        private  void button_Click_1(object sender, RoutedEventArgs e)
        {
            if (btnStart.Content.ToString().Trim() == "Start" && !(hours == 0 && minutes == 0 && seconds == 0))
            {
                btnStart.Content = "Pause";
                timer.Start();
            }
            else
            {
                btnStart.Content = "Start";
                timer.Stop();
            }
        }

        private  void updateTime()
        {
            if(hours>0 && minutes>0)
            {
                minutes--;
                seconds = 59;
            }
            else if(hours>0 && minutes == 0)
            {
                    hours--;
                    minutes = 59;
                    seconds = 59;
                    lblHours.Text = String.Format("{0:00}", hours);
                    lblMinutes.Text = String.Format("{0:00}", minutes);
                    lblSeconds.Text = String.Format("{0:00}", seconds);   
            }
            else if (minutes > 0)
            {
                minutes--;
                seconds = 59;
                lblMinutes.Text = String.Format("{0:00}", minutes);
                lblSeconds.Text = String.Format("{0:00}", seconds);
            }
            else if(hours == 0 && minutes == 0 && seconds == 0)
            {
                timer.Stop();
                mdPlayer.Play();
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            hours = 0;
            minutes = 0;
            seconds = 0;

            if (hours == 0 && minutes == 0 && seconds == 0)
            {
                mdPlayer.Stop();
            }
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
