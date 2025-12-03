using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
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
using Microsoft.UI.Xaml.Shapes;


namespace Morris
{

    public sealed partial class MainWindow : Window
    {
        //initializes main window
        public MainWindow() {
            
            this.InitializeComponent();
            Title = "Morris";
        }

        //Elements that will be used for drawin
        private Brush currentBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        private bool isDrawing = false;
        private bool isErasing = false;
        private Point startPoint;
        //a list?? already done?? sign me up
        private List<UIElement> elementsToRemove = new List<UIElement>();
        private int selectedIndex = 0;
        private Ellipse currentEllipse;
        private Polygon currentPolygon;
        private Rectangle currentRectangle;


        //specify the current drawing shapey
        private enum DrawingMode {
            Circle, Triangle, Rectangle
        }; private DrawingMode currentDM= DrawingMode.Rectangle;

        //thickes for the brush
        public List<double> brushThick { get; } = new List<double>() {
            0.5, 1,2, 4, 8, 10, 12, 14, 16, 18, 20, 22, 24, 30, 42,54, 66, 78, 80, 94, 108, 116, 148, 172
        };

       
    }
}
