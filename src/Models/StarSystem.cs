using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Morris.Models {

    public class StarSystem {
        private Planet[] planets;
        private Star mainStar;

        public StarSystem() {
            this.mainStar = new Star();
            this.planets = new Planet[9];
        }

        private async void SaveSimToJSON() {
            string fileName = "StarSystem.json";
            await using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, this);
        }
    }
}