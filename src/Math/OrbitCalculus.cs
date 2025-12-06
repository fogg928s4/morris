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
            const double e = 0.0167; // earth eccentricity
            double c = e * a;
            return System.Math.Sqrt(Squared(a) - Squared(c));
        }
        private static double Squared(double n) {
            return n * n;
        }

        // deprecated
        public static double CalculateHeightPython() {
            double ellipseHeight;
            PythonEngine.Initialize();
            using (Py.GIL()) {
                string baseDir = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..", "Math");
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
