using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Morris.Models;
using System;
//using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;

namespace Morris
{

    public sealed partial class MainWindow : Window
    {
        //initializes main window
        public MainWindow() {
            try {
                this.InitializeComponent();
                Title = "Morris";
                FetchJSONSimData("\\StarSystem.json");
            }
            catch (Exception ex) {
                if(ex is FileNotFoundException) {
                    Console.WriteLine(ex.Message);
                    throw new FileNotFoundException(Title);
                }
                this.Close();
            }
        }

        public StarSystem currentSimulation;

        // fetch data from JSON file
        public async void FetchJSONSimData(string fileName) {
            string fileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SimData" ;
            string fullPath = fileDirectory + fileName;

            if (!File.Exists(fullPath)) {
                Directory.CreateDirectory(fileDirectory);
                File.Create(fullPath);

            }
            await using Stream openStream = File.OpenRead(fullPath);
            currentSimulation = await JsonSerializer.DeserializeAsync<StarSystem>(openStream);
        }

    }
}
