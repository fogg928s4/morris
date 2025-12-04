using System.Collections.Generic;

namespace Morris.Models {

    public class StarSystem {
        private List<Planet> planetsSys;
        private Star mainStar;

        public StarSystem() {
            this.mainStar = new Star();
            this.planetsSys = new List<Planet>();
        }
    }
}