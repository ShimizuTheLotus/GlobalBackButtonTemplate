using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlobalBackButtonTemplate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Loaded += MainPage_Loaded;

            //Use it you can extend the button into the title bar.
            ExtendPanelIntoTitleBar();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationFrame.Navigate(typeof(HomePage));
            NavigationFrame.Navigated += NavigationFrame_Navigated;
        }
        private void NavigationFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (NavigationFrame.CanGoBack)
            {
                GoBackButton.IsEnabled = true;
            }
            else
            {
                GoBackButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Initialize TitleBar.
        /// </summary>
        public void ExtendPanelIntoTitleBar()
        {
            //Extend view into TitleBar
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            // Set XAML element as a drag region.
            Window.Current.SetTitleBar(DragBar);
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

            //Set TitleBar button color
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationFrame.CanGoBack)
            {
                NavigationFrame.GoBack();
                if (NavigationFrame.CanGoBack)
                {
                    GoBackButton.IsEnabled = true;
                }
                else
                {
                    GoBackButton.IsEnabled = false;
                }
            }
        }
    }
}
