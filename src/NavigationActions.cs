using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Shapes;
using Morris.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;

namespace Morris {
    partial class MainWindow {
        private void Navigate_Invoke(NavigationView sender, NavigationViewItemInvokedEventArgs args) {
            // takes the content value from selected item
            string invokedItem = args.InvokedItem as string; 
             // var item = sender.MenuItems
             //         .OfType<NavigationViewItem>()
             //         .FirstOrDefault(x => x.Content.Equals(args.InvokedItem));
            switch (invokedItem) {
                case "Add Star":
                    MainContentFrame.Navigate(typeof(CreateStarPage), currentSimulation.MainStar);
                    break;
                case "Add Planet":
                    MainContentFrame.Navigate(typeof (CreatePlanetPage), currentSimulation.Planets);
                    break;
                case "View Simulation": // Main simulation page
                    MainContentFrame.Navigate(typeof(SimulationPage), currentSimulation);
                    break;
                case "Settings":
                    MainContentFrame.Navigate(typeof(SettingsPage), currentSimulation);
                    break;
            }
        }

        private void goForItBtn_Click(object sender, RoutedEventArgs args ) {
            MainContentFrame.Navigate(typeof(SimulationPage), currentSimulation);
        }
    }
}