/*
* This class defines the properties of celestial bodies
* <summary>
* This is nothing more than an abstract class
* </summary>
*/
using System;

namespace Morris.Models {
    public abstract class CelestialBody {
        
        protected String name = "";
        protected Double baseMass; // mass
        protected double trueMass;
        protected int massOrderPower;
        protected String hexColor = "000000";

        // Properties
        public string Name {
            get { return name; }
            set { name = value; }
        }
        public double Mass {
            get { return baseMass; }
            set {
                baseMass = value;
                trueMass = baseMass * Math.Pow(10, massOrderPower);
            }
        }
        public String HexColor { 
            get { return hexColor; } 
            set { hexColor = value; } 
        }
    }
}