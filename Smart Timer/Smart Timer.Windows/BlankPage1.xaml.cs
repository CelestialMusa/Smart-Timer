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
using Windows.Storage;
using Windows.Storage.Pickers;


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

        private  void btnSave_Click(object sender, RoutedEventArgs e)
        {
            newTimer.Hours = Convert.ToInt32(sldHours.Value);
            newTimer.Minutes = Convert.ToInt32(sldMinutes.Value);
            newTimer.Seconds = Convert.ToInt32(sldSeconds.Value);

            MainPage.setTime(newTimer);

            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void btnFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFile = new FileOpenPicker();
                openFile.SuggestedStartLocation = PickerLocationId.MusicLibrary;
                openFile.FileTypeFilter.Add(".MP3");
                openFile.FileTypeFilter.Add(".WMA");
                openFile.FileTypeFilter.Add(".FLAC");
                openFile.FileTypeFilter.Add(".MP3");

                var file = await openFile.PickSingleFileAsync();
                var stream = await file.OpenAsync(FileAccessMode.Read);

                MainPage.mdPlayer.SetSource(stream, file.ContentType);
                MainPage.mdPlayer.Pause();
            }
            catch(Exception)
            {

            }
        }
    }
}
