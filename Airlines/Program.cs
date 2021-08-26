using System;
using System.IO;
using System.Reflection;
using Airlines.Models;


namespace Airlines
{
    class Program
    {
        static void Main(string[] args)
        {
            // finds path to json file
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // assumes file is in desktop folder
            string filename = @"airlines.json"; // assumes filename
            var path = Path.Combine(desktopPath, filename); // path to file for processing
          
            // processes data
            string json = File.ReadAllText(path);
            Process p = new Process(json);

            XmlMill xmlBuilder = new XmlMill(p);
            Console.WriteLine(xmlBuilder.xml);
        }
    }
}
