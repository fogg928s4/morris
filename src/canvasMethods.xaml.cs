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
using Microsoft.UI.Input;
using Microsoft.UI.Xaml.Media.Imaging;

namespace Morris {
    partial class MainWindow {
        //methods for the canvas
        private async void canvas_PointerPressed(object sender, PointerRoutedEventArgs e) {
            //check if what was pressed was a mouse
            if (e.Pointer.PointerDeviceType.Equals(PointerDeviceType.Mouse)) {
                if(colorPickrBtn.IsChecked == true) {
                    //gets the current posistio
                    var pointerPosition = e.GetCurrentPoint(canvas);
                    int x = (int) pointerPosition.Position.X;
                    int y = (int) pointerPosition.Position.Y;

                    //renders into what yall see
                    RenderTargetBitmap renderBitMap = new RenderTargetBitmap();
                    //please load canvas pls pls pls
                    await renderBitMap.RenderAsync(canvas);

                    var pixelBuffer = await renderBitMap.GetPixelsAsync();
                    var pixelData = pixelBuffer.ToArray();

                    int pixelIndex = (y * renderBitMap.PixelHeight + x) * 4;
                    byte[] pixelColor = new byte[4];

                    //ok so, pixelData is the buffer of pixels in an array which gets copied to pixel Color, starting from pixelIndex
                    //pixel index is gathered from the cords of where it was all pressed
                    Array.Copy(pixelData, pixelIndex ,pixelColor, 0, 4);
                    //these are all from windows.ui
                    Color color = Color.FromArgb(pixelColor[3], pixelColor[2], pixelColor[1], pixelColor[0]);
                    currentColor.Background = currentBrush = new SolidColorBrush(color);
                    return;
                }
                isDrawing = true;
                startPoint = e.GetCurrentPoint(canvas).Position;

                //now if its a shapes button not the brush, theres 100% a better way to do this
                if (shapesBtn.IsChecked == true) {
                    switch (currentDM) {
                        case DrawingMode.Circle:
                            currentEllipse = new Ellipse {
                                Width = 0,
                                Height = 0,
                                Stroke = currentBrush,
                                StrokeThickness = brushThick[selectedIndex]
                            };
                            canvas.Children.Add(currentEllipse);
                            Canvas.SetLeft(currentEllipse, startPoint.X);
                            Canvas.SetTop(currentEllipse, startPoint.Y);
                            break;
                        case DrawingMode.Triangle:
                            currentPolygon = new Polygon {
                                Stroke = currentBrush,
                                StrokeThickness = brushThick[selectedIndex]
                            };
                            //htree points cus triangle
                            currentPolygon.Points.Add(startPoint);
                            currentPolygon.Points.Add(startPoint);
                            currentPolygon.Points.Add(startPoint);
                            canvas.Children.Add(currentPolygon);

                            break;
                        case DrawingMode.Rectangle:
                            currentRectangle = new Rectangle {
                                Width = 0,
                                Height = 0,
                                Stroke = currentBrush,
                                StrokeThickness = brushThick[selectedIndex]
                            };
                            canvas.Children.Add(currentRectangle);
                            Canvas.SetLeft(currentRectangle, startPoint.X);
                            Canvas.SetTop(currentRectangle, startPoint.Y);
                            break;

                    }
                }
            }
        }

        private void canvas_PointerMoved(object sender, PointerRoutedEventArgs e) {

            //if its just moving cursor why do i care
            if(!isDrawing) 
                return;

            if (shapesBtn.IsChecked == true) {
                Point currentPoint = e.GetCurrentPoint(canvas).Position;
                switch (currentDM) {
                    case DrawingMode.Circle:
                        currentEllipse.Width = Math.Abs(currentPoint.X - startPoint.X) * 2;
                        currentEllipse.Height = Math.Abs(currentPoint.Y - startPoint.Y) * 2;

                        double left = Math.Min(startPoint.X, currentPoint.Y);
                        double top = Math.Min(startPoint.Y, currentPoint.Y);
                        Canvas.SetLeft(currentEllipse, left);
                        Canvas.SetTop(currentEllipse, top);
                        break;
//god knows what it does here, i dont
                    case DrawingMode.Triangle:
                        double centerX = (startPoint.X + currentPoint.X) / 2;
                        double centerY = (startPoint.Y + currentPoint.Y) / 2;
                        double sideLength = Math.Min(Math.Abs(currentPoint.X - startPoint.X), Math.Abs(currentPoint.Y - startPoint.Y));
                        Point vtx1 = new Point(centerX, centerY - (sideLength / 2));
                        Point vtx2 = new Point(centerX - (sideLength / 2), centerY + (sideLength / 2));
                        Point vtx3 = new Point(centerX + (sideLength / 2), centerY + (sideLength / 2));
                        currentPolygon.Points.Clear();
                        currentPolygon.Points.Add(vtx1);
                        currentPolygon.Points.Add(vtx2);
                        currentPolygon.Points.Add(vtx3);
                        currentPolygon.Points.Add(vtx1);
                        break;
                    case DrawingMode.Rectangle:
                        currentRectangle.Width = Math.Abs(currentPoint.X - startPoint.X);
                        currentRectangle.Height = Math.Abs(currentPoint.Y - startPoint.Y);
                        left = Math.Min(startPoint.X, currentPoint.Y);
                        top = Math.Min(startPoint.Y, currentPoint.Y);
                        Canvas.SetLeft(currentRectangle, left);
                        Canvas.SetTop(currentRectangle, top);
                        break;


                }
            }
            else if (brushBtn.IsChecked == true || eraserBtn.IsChecked == true) {
                Line line = new Line {
                    X1 = startPoint.X, Y1 = startPoint.Y,
                    X2 = e.GetCurrentPoint(canvas).Position.X, Y2 = e.GetCurrentPoint (canvas).Position.Y,
                    Stroke = currentBrush, StrokeThickness = brushThick[selectedIndex],
                    StrokeEndLineCap = PenLineCap.Round, StrokeStartLineCap = PenLineCap.Round,
                    StrokeLineJoin = PenLineJoin.Round
                };

                Line lineBlur = new Line {
                    X1 = startPoint.X, Y1 = startPoint.Y,
                    X2 = e.GetCurrentPoint(canvas).Position.X, Y2 = e.GetCurrentPoint(canvas).Position.Y,
                    Stroke = currentBrush, StrokeThickness = brushThick[selectedIndex] + 10,
                    StrokeEndLineCap = PenLineCap.Round, StrokeStartLineCap = PenLineCap.Round,
                    StrokeLineJoin = PenLineJoin.Round,
                    Opacity = 0.3
                };
                canvas.Children.Add(lineBlur);
                canvas.Children.Add(line);
                startPoint = e.GetCurrentPoint(canvas).Position;
            }
            //just draws a lil something
            else {
                Line line = new Line {
                    X1 = startPoint.X, Y1 = startPoint.Y,
                    X2 = e.GetCurrentPoint(canvas).Position.X, Y2 = e.GetCurrentPoint(canvas).Position.Y,
                    Stroke = currentBrush, StrokeThickness = brushThick[selectedIndex],
                    StrokeEndLineCap = PenLineCap.Round, StrokeStartLineCap = PenLineCap.Round,
                    StrokeLineJoin = PenLineJoin.Round
                };
                canvas.Children.Add (line);
                startPoint = e.GetCurrentPoint(canvas).Position;
            }
        }

        private void canvas_PointerReleased(object sender, PointerRoutedEventArgs e) {
            isDrawing = false;
            isErasing = false;
        }
    }
}
  