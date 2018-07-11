using Microsoft.AppCenter;
using Microsoft.HockeyApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppCenterDemo
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            HockeyClient.Current.TrackPageView(this.Name);
        }

        private void event1Sender_Click(object sender, RoutedEventArgs e)
        {
            HockeyClient.Current.TrackEvent("myEvent1");
        }

        private void event2Sender_Click(object sender, RoutedEventArgs e)
        {
            HockeyClient.Current.TrackEvent("myEvent2");
        }

        private void customEventSender_Click(object sender, RoutedEventArgs e)
        {
            HockeyClient.Current.TrackEvent(this.customEventTextBox.Text);
        }

        private void tryCatchCrash_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new Exception("It crash");
            }
            catch (Exception ex)
            {
                HockeyClient.Current.TrackException(ex);
            }
        }

        private void crash_Click(object sender, RoutedEventArgs e)
        {
            HockeyClient.Current.TrackException(new Exception("it realy crashed"));
        }

        private void flush_Click(object sender, RoutedEventArgs e)
        {
            HockeyClient.Current.Flush();
        }
    }
}
