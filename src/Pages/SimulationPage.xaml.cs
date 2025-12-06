using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Morris;
using System;
//using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using System.Drawing;
using Microsoft.UI;
using Python.Runtime;
using Morris.Math;

namespace Morris.Pages
{

    public sealed partial class SimulationPage : Page {
        //initializes main window
        public SimulationPage() {
            this.InitializeComponent();
        }

        public void Canvas_FillCanvas(object sender, RoutedEventArgs args) { 
            Ellipse testEllipse = new Ellipse {
                Width = 30,
                Height = 30,
                Stroke = new SolidColorBrush(Colors.Red),
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Colors.Yellow)
            };
            int left = (int) ((canvas.ActualWidth - testEllipse.ActualWidth) / 2);
            int top = (int)((canvas.ActualHeight - testEllipse.ActualHeight) / 2);
            canvas.Children.Add(new TextBox { Text = $"Left: {left}, top: {top}"});
            canvas.Children.Add(testEllipse);
            Canvas.SetLeft(testEllipse, left);
            Canvas.SetTop(testEllipse, top);
            Canvas_AppendOrbit();
        }

        public void Canvas_AppendOrbit() {
            Ellipse testOrbit = new Ellipse {
                Width = canvas.ActualWidth - 20,
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2,
                Fill = null
            };
            testOrbit.Height = OrbitCalculus.CalculateHeight(canvas.ActualHeight);
            int left = (int)((canvas.ActualWidth - testOrbit.ActualWidth) / 2);
            int top = (int)((canvas.ActualHeight - testOrbit.ActualHeight) / 2);
            canvas.Children.Add(testOrbit);
            Canvas.SetLeft(testOrbit, left);
            Canvas.SetTop(testOrbit, top);
        }



    }
}
