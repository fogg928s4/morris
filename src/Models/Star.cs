using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morris.Models {
    internal class Star : CelestialBody {

        // Constructors
        public Star() {
            this.name = "Sun";
            this.baseMass = 1.998;
            this.massOrderPower = 30;
            this.trueMass = baseMass * Math.Pow(10, massOrderPower);
        }
        public Star(string name, double baseMass) {
            this.name = name;
            this.baseMass = baseMass;
            this.massOrderPower = 30;
            this.trueMass = this.baseMass * Math.Pow(10, massOrderPower);
        }
        public Star(string name) {
            this.name = name;
            this.baseMass = 5.97;
            this.massOrderPower = 24;
            this.trueMass = baseMass * Math.Pow(10, massOrderPower);
        }


        public int MassOrderPower {
            set { massOrderPower = 30; }
        }
    }
}
