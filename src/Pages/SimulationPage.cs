using Microsoft.UI.Xaml.Controls;
using Morris.Math;
using Morris.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Morris.Pages {
    public partial class SimulationPage : Page {
        public async void FetchJSONSimData(string fileName) {
            string fileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SimData";
            string fullPath = fileDirectory + fileName;

            if (!File.Exists(fullPath)) {
                Directory.CreateDirectory(fileDirectory);
                File.Create(fullPath);

            }
            await using Stream openStream = File.OpenRead(fullPath);
            simData = await JsonSerializer.DeserializeAsync<StarSystem>(openStream);
        }

        public void ShowCalculations() {
            double distPlanetStar = System.Math.Sqrt(OrbitCalculus.CalcSqrDistanceToFocus(planetCoords.x, orbitEllipse.ActualWidth/2));
            //writes two decimal places
            distTxtBlock.Text = $"{distPlanetStar.ToString("0.##")} Gm";

            //speed
            double speed = DynamicCalculus.CalculateSpeed(planetCoords.x, orbitEllipse.ActualWidth / 2, distPlanetStar);
            velTxtBlock.Text = $"{speed.ToString("0.######")} Gm/h";

            // force
            double force = DynamicCalculus.CalculateForce(distPlanetStar, simData.MainStar.Mass, simData.Planets[0].Mass);
            forceTxtBlock.Text = $"{force.ToString("0.##")} EN";
        }
    }
}
