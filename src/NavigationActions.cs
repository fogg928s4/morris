using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Shapes;
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
                    MainContentFrame.Navigate(typeof(Pages.CreateStarPage));
                    break;
                case "Add Planet":
                    MainContentFrame.Navigate(typeof (Pages.CreatePlanetPage));
                    break;
            }
        }
    }
}