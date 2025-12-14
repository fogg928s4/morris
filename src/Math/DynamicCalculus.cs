using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Morris.Math
{
    public sealed partial class DynamicCalculus {
        private static double e = 0.75; //  eccentricity
        public static double CalculateSpeed(double x, double a, double r) {
            double y = OrbitCalculus.CalcVerticalPos(x, a);
            // double r = System.Math.Sqrt(OrbitCalculus.CalcSqrDistanceToFocus(x, a)); // distance to star

            double cosV = (a + a * e * e - r) / (e * r);

            return System.Math.Acos(cosV);
        }


        public static double G = 6.67;
        public static double EarthKg = 5.972;
        public static double CalculateForce(double r, double M, double m) {
            double temp = G * M * m * OrbitCalculus.Squared(EarthKg);
            return temp / OrbitCalculus.Squared(r);
            
        }
    }
}
