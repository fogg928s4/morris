/*
* This class defines the properties of celestial bodies
* <summary>
* This is nothing more than an abstract class
* </summary>
*/
using System;

namespace Morris.Models {
    public abstract class CelestialBody {
        
        protected String name;
        protected Double mass; // mass in Earth masses
        protected String hexColor = "000000";

        // Properties
        public string Name {
            get { return name; }
            set { name = value; }
        }
        public double Mass {
            get { return mass; }
            set { mass = value; }
        }
        public String HexColor { 
            get { return hexColor; } 
            set { hexColor = value; } 
        }
    }
}