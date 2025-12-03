using System.Collections.Generic;

namespace Morris.Models {
    public class SpaceSystem {
        private List<Planet> planetsSys;
        private Star mainStar;

        private SpaceSystem() {
            this.mainStar = new Star();
            planetsSys = new List<Planet>();
        }
    }
}