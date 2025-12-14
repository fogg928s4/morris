/*
* This class defines the properties of celestial bodies
* <summary>
* This is nothing more than an abstract class
* </summary>
*/
using System;
using Windows.UI;

namespace Morris.Models {
    public abstract class CelestialBody {
        
        protected String name;
        protected Double mass; // mass in Earth masses
        protected Color fillColor;

        // Properties
        public string Name {
            get { return name; }
            set { name = value; }
        }
        public double Mass {
            get { return mass; }
            set { mass = value; }
        }
    }
}