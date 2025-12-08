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

namespace Morris.Pages {

    public sealed partial class SimulationPage : Page {
        //initializes main window
        public SimulationPage() {
            this.InitializeComponent();
        }



        public void Canvas_FillCanvas(object sender, RoutedEventArgs args) {
            DrawOrbit();
            focalDistance = OrbitCalculus.CalculateFocus(orbitEllipse.ActualWidth, orbitEllipse.ActualHeight);
            DrawStar();
            DrawPlanet();
        }

        private Ellipse orbitEllipse;
        private Ellipse starEllipse;
        private Ellipse planetEllipse;
        private double focalDistance;

        // Draws elliptical orbit
        public void DrawOrbit() {
            orbitEllipse = new Ellipse {
                Width = canvas.ActualWidth - 100,
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 1,
                Fill = null
            };
            orbitEllipse.Height = OrbitCalculus.CalculateHeight(orbitEllipse.ActualWidth / 2);
            // center it
            int left = (int)((canvas.ActualWidth - orbitEllipse.ActualWidth) / 2);
            int top = (int)((canvas.ActualHeight - orbitEllipse.ActualHeight) / 2);
            canvas.Children.Add(orbitEllipse);
            Canvas.SetLeft(orbitEllipse, left);
            Canvas.SetTop(orbitEllipse, top);
        }

        //draws star in themiddle of canvas
        public void DrawStar() {
            starEllipse = new Ellipse {
                Width = 30,
                Height = 30,
                Stroke = new SolidColorBrush(Colors.Red),
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Colors.Yellow)
            };

            // centers it
            double left = (canvas.ActualWidth/2) + focalDistance -starEllipse.Width;
            double top = (double)((canvas.ActualHeight - starEllipse.ActualHeight) / 2);
            canvas.Children.Add(new TextBox { Text = $"focal: {focalDistance}, width: {canvas.ActualWidth}" });
            canvas.Children.Add(starEllipse);
            Canvas.SetLeft(starEllipse, left);
            Canvas.SetTop(starEllipse, top);
        }

        public void DrawPlanet() {
            planetEllipse = new Ellipse {
                Width = 40,
                Height =40,
                Stroke = new SolidColorBrush(Colors.Pink),
                StrokeThickness = 1,
                Fill = new SolidColorBrush(Colors.SkyBlue)
            };
            // center it
            double left = (canvas.ActualWidth - orbitEllipse.ActualWidth - planetEllipse.ActualWidth) / 2;
            double top = (canvas.ActualHeight - planetEllipse.ActualHeight) / 2;
            canvas.Children.Add(planetEllipse);
            Canvas.SetLeft(planetEllipse, left);
            Canvas.SetTop(planetEllipse, top);
        }
    }
}
