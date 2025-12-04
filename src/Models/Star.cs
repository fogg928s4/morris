using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morris.Models {
    public class Star : CelestialBody {

        // Constructors
        // Constructors
        public Star() {
            this.name = "Sun";
            this.mass = 5.97;
        }
        public Star(string name, double mass) {
            this.name = name;
            this.mass = mass;
        }
    }
}
