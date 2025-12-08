using Microsoft.UI.Xaml.Controls;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morris.Math {
    public class OrbitCalculus {
        public static double CalculateHeight(double a) {
            const double e = 0.75; //  eccentricity
            double c = e * a;
            return 2*System.Math.Sqrt(Squared(a) - Squared(c));
        }
        private static double Squared(double n) {
            return n * n;
        }

        public static double CalculateFocus(double width, double height) {
            double a = width / 2;
            double b = height / 2;
            return System.Math.Sqrt(Squared(a) - Squared(b)); //c
        }

        public static double CalcVerticalPos(double x, double a) {
            double temp = Squared(x / a);
            double b = CalculateHeight(a) / 2;
            return System.Math.Sqrt((1 - temp) * Squared(b)) ;
        }

        public static double CalcSqrDistanceToFocus(double x, double a, double c ) {
            double y = CalcVerticalPos(x, a);
            return Squared(c-y) + Squared(x); 
        }

        // deprecated
        public static double CalculateHeightPython() {
            double ellipseHeight;
            PythonEngine.Initialize();
            using (Py.GIL()) {
                string baseDir = Path.Combine(Directory.GetCurrentDirectory(), "..", "Math");
                dynamic sys = Py.Import("sys");
                sys.path.append(baseDir);
                dynamic ellipseCalc = Py.Import("elliptipcal_calculus");
                // ellipseHeight = ellipseCalc.ellipse_dimension(canvas.ActualWidth - 20); // call function
            }
            PythonEngine.Shutdown();
            return 0;
        }
    }
}
