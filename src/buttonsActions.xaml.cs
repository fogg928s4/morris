using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Microsoft.UI.Xaml.Shapes;

namespace Morris {
    partial class MainWindow {
        //methods for the canvas
        private void pencilBtn_Click(object sender, RoutedEventArgs e) {
            ToggleButton clickedBtn  = sender as ToggleButton;

            pencilBtn.IsChecked = true;
            brushBtn.IsChecked = false;
            eraserBtn.IsChecked = false;
            clsBtn.IsChecked = false;
            colorPickrBtn.IsChecked = false;
        }
        private void brushBtn_Click(object sender, RoutedEventArgs e) {
            ToggleButton clickedBtn = sender as ToggleButton;
            pencilBtn.IsChecked = false;
            brushBtn.IsChecked = true;
            eraserBtn.IsChecked = false;
            clsBtn.IsChecked = false;
            colorPickrBtn.IsChecked = false;

        }
        private void eraserBtn_Click(object sender, RoutedEventArgs e) {
            isErasing = !isErasing;
            currentBrush = new SolidColorBrush(Color.FromArgb(255,255,255,255));
            pencilBtn.IsChecked = false;
            brushBtn.IsChecked = false;
            eraserBtn.IsChecked = true;
            clsBtn.IsChecked = false;
            colorPickrBtn.IsChecked = false;
        }
        private void clsBtn_Click(object sender, RoutedEventArgs e) {
            pencilBtn.IsChecked = false;
            brushBtn.IsChecked = false;
            eraserBtn.IsChecked = false;
            clsBtn.IsChecked = true;
            colorPickrBtn.IsChecked = false;
            //System.Threading.Thread.Sleep(750);
            canvas.Children.Clear();
            pencilBtn.IsChecked = true;
            clsBtn.IsChecked = false;
        }

        private void colorPickrBtn_Click(object sender, RoutedEventArgs e) {
            pencilBtn.IsChecked = false;
            brushBtn.IsChecked = false;
            eraserBtn.IsChecked = false;
            clsBtn.IsChecked = false;
            colorPickrBtn.IsChecked = true;
            shapesBtn.IsChecked = false;

        }
        private void shapesBtn_Click(object sender, RoutedEventArgs e) {
            pencilBtn.IsChecked = false;
            brushBtn.IsChecked = false;
            eraserBtn.IsChecked = false;
            clsBtn.IsChecked = false;
            colorPickrBtn.IsChecked = false;
            shapesBtn.IsChecked = true;
        }

        private void colorPicker_ColorChanged(ColorPicker sender, ColorChangedEventArgs args) {
            //new color, and sets the bg
            //this is all ya need to actually se sumn
            currentBrush = new SolidColorBrush(args.NewColor);
            currentColor.Background = new SolidColorBrush(args.NewColor);

        }
        private void backColorPicker_ColorChanged(ColorPicker sender, ColorChangedEventArgs args) {
            canvas.Background = new SolidColorBrush(args.NewColor);
            backgColor.Background = new SolidColorBrush(args.NewColor);

        }
        private void comboBrushThick_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            selectedIndex = comboBrushThick.SelectedIndex;
        }


        private void ComboShapes_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            switch (ComboShapes.SelectedIndex) {
                case 0:
                    currentDM = DrawingMode.Circle;
                    break;
                case 1:
                    currentDM = DrawingMode.Rectangle;
                    break;
                case 2:
                    currentDM = DrawingMode.Triangle;
                    break;
            }
        }
    }
}
