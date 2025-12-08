using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morris.Math
{
    public sealed partial class DynamicCalculus {
        public static double CalculateSpeed(double x, double a) {
            const double e = 0.6;
            double y = OrbitCalculus.CalcVerticalPos(x, a);
            double r = System.Math.Sqrt(OrbitCalculus.CalcSqrDistanceToFocus(x, a, e * a)); // distance to star

            double cosV = (a + a * e * e - r) / (e * r);

            return System.Math.Acos(cosV);
        }

        public static double CalculateForce(double x, double a, double M, double m) {
            const double e = 0.6;
            double rSqr = OrbitCalculus.CalcSqrDistanceToFocus(x, a, e * a);
            double G = 6.674 * System.Math.Pow(10, -11);
            return (M * m * G) / rSqr;
        }
    }
}
