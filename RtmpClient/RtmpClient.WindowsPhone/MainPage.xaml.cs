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
using Mntone.Rtmp;
using Mntone.Data;
using Windows.Media;
using Mntone.Rtmp.Client;
using Windows.UI;
using Windows.UI.Core;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RtmpClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        Mntone.Rtmp.RtmpUri rtmpUri;

        private async void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }


        MediaElement elem = new MediaElement();

        public async void OnStart(object sender, SimpleVideoClientStartedEventArgs VideoStart)
        {
            Windows.UI.Core.CoreDispatcher dis = CoreWindow.GetForCurrentThread().Dispatcher;
            CoreWindow wiw = CoreWindow.GetForCurrentThread();
            await wiw.Dispatcher.RunAsync(CoreDispatcherPriority.High,
                ref new DispatchedHandler(() =>
                {
                    
                    elem.SetMediaStreamSource(VideoStart.MediaStreamSource);
                    elem.CurrentStateChanged += 

                }
            ));
        }

        private void Elem_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnCSStateChange(object sender, RoutedEventArgs a)
        {
            ProgressRing ring = new ProgressRing();

            switch (elem.CurrentState)
            {
                case MediaElementState.Playing:
                    ring.Visibility = Visibility.Collapsed;
                    ring.IsActive = false;
                    break;

                case MediaElementState.Buffering:
                    ring.IsActive = true;
                    ring.Visibility = Visibility.Visible;
                    break;
            }


            throw new NotImplementedException();
        }

        


        
                            




                /*
                MediaElement elem = new MediaElement();
                elem.SetMediaStreamSource(VideoStart.MediaStreamSource);
                elem.CurrentStateChanged += new RoutedEventHandler(this, //OnCurrentStateChanged); 
                */

            }
             //dis += MediaElement.
            //await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, ref new DispatchedHandler([]);
        }

        private async void Stream_Click(object sender, RoutedEventArgs e)
        {
            Mntone.Rtmp.RtmpUri rtmpUri;

            
            rtmpUri = new RtmpUri(textBox1.Text);
            // Uri.CheckHostName(textBox.Text);     
            rtmpUri.Instance = "AudioStream.sdp";
            Mntone.Rtmp.Client.SimpleVideoClient AudioVideoClient = null;
            await AudioVideoClient.ConnectAsync(rtmpUri);


            Mntone.Rtmp.Media.AudioFormat wavAudio;
            Mntone.Rtmp.Media.AudioInfo wav1;
            Windows.Media.SystemMediaTransportControls medi = null;
            MediaElement audio = new MediaElement();

            Mntone.Rtmp.Client.SimpleVideoClient client = new Mntone.Rtmp.Client.SimpleVideoClient();

            //client.Started += new EventHandler<SimpleVideoClientStartedEventArgs>()

            
              
        
          
        }
    }
}
