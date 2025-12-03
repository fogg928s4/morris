using System;

namespace Morris.Models {

    public class Planet : CelestialBody {

        // Constructors
        public Planet() {
            this.name = "Earth";
            this.baseMass = 5.97;
            this.massOrderPower = 24;
            this.trueMass = baseMass * Math.Pow(10, massOrderPower);
        }
        public Planet(string name, double baseMass) {
            this.name = name;
            this.baseMass = baseMass;
            this.massOrderPower = 24;
            this.trueMass = this.baseMass * Math.Pow(10, massOrderPower);
        }
        public Planet(string name) {
            this.name = name;
            this.baseMass = 5.97;
            this.massOrderPower = 24;
            this.trueMass = baseMass * Math.Pow(10, massOrderPower);
        }


        public int MassOrderPower {
            set { massOrderPower = 24; }
        }
    }
}