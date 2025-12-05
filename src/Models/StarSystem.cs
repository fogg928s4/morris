using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System;

namespace Morris.Models {

    public class StarSystem {
        
        private IList<Planet> planets;
        private Star mainStar;
        private int planetCount;
        public string Title { get; set; }

        public StarSystem() {
            this.mainStar = new Star();
            this.planets = new List<Planet>();
            this.planetCount = planets.Count;
        }

        //Properties that will go in JSON
        public Star MainStar {
            get { return this.mainStar; }
            set { this.mainStar = value; }
        }
        public int PlanetCount {
            get { return this.planetCount;}
            set { planetCount = value; }
        }
        public IList<Planet> Planets {
            get { return this.planets; }
            set { this.planets = value; }
        }


        private async void WriteSimToJSON() {
            string fileName = "StarSystem.json";
            await using FileStream createStream = File.Create(fileName);
            var options = new JsonSerializerOptions { WriteIndented = true };
            await JsonSerializer.SerializeAsync(createStream, this, options);
        }


    }
}