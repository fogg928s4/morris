using Microsoft.UI.Xaml.Controls;
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
    }
}
