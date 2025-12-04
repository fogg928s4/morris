using System;

namespace Morris.Models {

    public class Planet : CelestialBody {

        // Constructors
        public Planet() {
            this.name = "Earth";
            this.mass = 5.97;
        }
        public Planet(string name, double mass) {
            this.name = name;
            this.mass = mass;
        }

    }
}