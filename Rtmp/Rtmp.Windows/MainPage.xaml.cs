using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Devices;
using Rtmp;
using Mntone.Rtmp;
using Mntone.Rtmp.Client;
using Windows.UI.Core;
using Windows.Media;
using System.Runtime.InteropServices;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Rtmp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        MainPage page = new MainPage();
        public MainPage()
        {
            this.InitializeComponent();
            SimpleVideoClient rtpClient = new SimpleVideoClient();

        }
        App myAppContext;
        SimpleVideoClient rtpClient = new SimpleVideoClient();
        public EventRegistrationToken startedEventToken, stoppedEventToken;
        EventRegistrationToken started = new EventRegistrationToken();
        EventRegistrationToken stoped = new EventRegistrationToken();


        void onPageUnloaded(Object sender, RoutedEventArgs e)
        {
            CloseClient();
        }




        private void CloseClient()
        {

            if (rtpClient != null)
            {
                rtpClient.Started -= started;
                rtpClient.Stopped -= stoped;
                rtpClient = null;
            }

            throw new NotImplementedException();
        }

        async void OnStarted(Object sender, SimpleVideoClientStartedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.High, new DispatchedHandler(() =>

            {

                mediaElement.SetMediaStreamSource(args.MediaStreamSource);
                mediaElement.CurrentStateChanged += new RoutedEventHandler(this, OnCurrentStateChanged);
                mediaElement.MediaEnded += new RoutedEventHandler(this, OnMediaEnded);
                mediaElement.Play();

            }));
        }

        async private void button_Click(object sender, RoutedEventArgs e)
        {
            CloseClient();

            SimpleVideoClient rtpClient = new SimpleVideoClient();
            progressRing.Visibility = Visibility.Visible;
            progressRing.IsActive = true;

            var rtpUri = uriTextBox.Text;

            started = rtpClient.Started += new EventHandler<SimpleVideoClientStartedEventArgs>(this, OnStarted);
            stoped = rtpClient.Stopped += new EventHandler<SimpleVideoClientStoppedEventArgs>(this, OnStopped);
            Uri urr = new Uri(rtpUri);
            await rtpClient.ConnectAsync(urr);

        }





        void OnCurrentStateChanged(Object sender, RoutedEventArgs e)
        {
            switch (mediaElement.CurrentState)
            {
                case MediaElementState.Playing:
                    progressRing.Visibility = Visibility.Collapsed;
                    progressRing.IsActive = false;
                    break;

                case MediaElementState.Buffering:
                    progressRing.Visibility = Visibility.Visible;
                    progressRing.IsActive = true;
                    break;
            }


        }
        void OnMediaEnded(Object sender, RoutedEventArgs e)
        {
            foregroundElement.Visibility = Visibility.Visible;
            CloseClient();
        }

        void OnStopped(Object sender, SimpleVideoClientStoppedEventArgs args)
        {

            myAppContext.Exit();

        }

        async void OnMediaButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs e)
        {
            if (e.Button == SystemMediaTransportControlsButton.Pause
                || e.Button == SystemMediaTransportControlsButton.Stop)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Low, new DispatchedHandler(() =>

             {
                 mediaElement.Source = null;
                 var smtc = SystemMediaTransportControls.GetForCurrentView();
                 smtc.PlaybackStatus = MediaPlaybackStatus.Closed;
             }));
            }
            else if(e.Button == SystemMediaTransportControlsButton.Play)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.High, new DispatchedHandler(() =>
                {
                }
                )); 
            }


        }


    }
}
