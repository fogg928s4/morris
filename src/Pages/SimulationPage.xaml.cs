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
using Morris.Models;
//using System.Windows.Media;

namespace Morris.Pages {

    public sealed partial class SimulationPage : Page {
        //initializes main window
        public SimulationPage() {
            try {
                this.InitializeComponent();
                FetchJSONSimData("\\StarSystem.json");

                planetEllipse = new Ellipse { 
                    Width = 20,
                    Height = 20,
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 1,
                    Fill = new SolidColorBrush(Colors.Azure)
                };

                planetCoords.x = 0;
                planetCoords.y = 0;
            }
            catch (Exception ex) {
                if (ex is FileNotFoundException) {
                    Console.WriteLine(ex.Message);
                    throw new FileNotFoundException();
                }
            }

        }

        public void Canvas_FillCanvas(object sender, RoutedEventArgs args) {
            DrawOrbit();
            planetPosSlider.Maximum = orbitEllipse.ActualWidth/2;
            planetPosSlider.Minimum = -orbitEllipse.ActualWidth/2;
            planetPosSlider.Value = planetPosSlider.Minimum;
            focalDistance = OrbitCalculus.CalculateFocus(orbitEllipse.ActualWidth, orbitEllipse.ActualHeight);

            DrawStar();
            DrawPlanet();
            SetInitialValues();
        }

        private StarSystem simData;
        private Ellipse orbitEllipse;
        private Ellipse starEllipse;
        private Ellipse planetEllipse;
        private double focalDistance;
        private bool REACHED_MAX = true;
        public struct PlanetCoords {
            public double x, y;
        };
        public PlanetCoords planetCoords = new PlanetCoords();

        public void MovePlanetPos(object sender, RoutedEventArgs args) {
            double x = planetPosSlider.Value;
            double a = orbitEllipse.ActualWidth / 2;
            double y = OrbitCalculus.CalcVerticalPos(x, a);
            double left = (canvas.ActualWidth - orbitEllipse.ActualWidth - planetEllipse.ActualWidth) / 2;
            double top = (canvas.ActualHeight - planetEllipse.ActualHeight) / 2;
            
            if(x == planetPosSlider.Maximum){
                REACHED_MAX = true;
            }
            else if (x == planetPosSlider.Minimum) {
                REACHED_MAX = false;
            }

            Canvas.SetLeft(planetEllipse, left + (orbitEllipse.ActualWidth / 2 + x)); // move horizontally
            Canvas.SetTop(planetEllipse, REACHED_MAX ? (top-y) : (top+y));
            //set to coordinates
            planetCoords.x = x;
            planetCoords.y = y;
            velTxtBlock.Text = $"{y.ToString("0.##")}";
            ShowCalculations();
        }

        // Draws elliptical orbit
        public void DrawOrbit() {
            orbitEllipse = new Ellipse {
                Width = canvas.ActualWidth - 100,
                Stroke = new SolidColorBrush(Microsoft.UI.Colors.White),
                StrokeThickness = 1,
                Fill = null
            };
            orbitEllipse.Height = OrbitCalculus.CalculateHeight(orbitEllipse.ActualWidth / 2); // 2*b= 
            // center it
            int left = (int)((canvas.ActualWidth - orbitEllipse.ActualWidth) / 2);
            int top = (int)((canvas.ActualHeight - orbitEllipse.ActualHeight) / 2);
            canvas.Children.Add(orbitEllipse);
            Canvas.SetLeft(orbitEllipse, left);
            Canvas.SetTop(orbitEllipse, top);
        }

        //draws star focus of ellipse
        public void DrawStar() {
            starEllipse = new Ellipse {
                Width = 50,
                Height = 50,
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Colors.Yellow)
            };
            // centers it on focal point
            double left = (canvas.ActualWidth/2) + focalDistance -starEllipse.Width;
            double top = (double)((canvas.ActualHeight - starEllipse.ActualHeight) / 2);
            
            canvas.Children.Add(starEllipse);
            Canvas.SetLeft(starEllipse, left);
            Canvas.SetTop(starEllipse, top);
        }

        // Dynamic movement
        public void DrawPlanet() {

            // center it
            double left = (canvas.ActualWidth - orbitEllipse.ActualWidth - planetEllipse.ActualWidth) / 2;
            double top = (canvas.ActualHeight - planetEllipse.ActualHeight) / 2;
            canvas.Children.Add(planetEllipse);
            Canvas.SetLeft(planetEllipse, left);
            Canvas.SetTop(planetEllipse, top);
        }

        public void SetInitialValues() {

        }

        public bool isPlayingAnimation = false;
        private void playBtn_Click(object sender, RoutedEventArgs e) {
            isPlayingAnimation = !isPlayingAnimation;
            playBtnIcon.Glyph = isPlayingAnimation ? "&#xE769;" : "&#xE768;"; // pause: play
            PlayAnimation();
        }
    }
}
