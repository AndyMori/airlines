using System.Linq;
using Newtonsoft.Json.Linq;
namespace Airlines.Models
{
    public class Process
    {
        private JArray jArray;
        public int airportCount { get; set; } // Total number of airports
        public int totalFlights { get; set; } // Total number of flights
        private int totalSecurityDelays { get; set; }
        private int totalWeatherDelays { get; set; }
        private int totalCarrierDelays { get; set; }
        public double percentSecurityDelays { get; set; } // Percentage of total flights delayed by "security"
        public double percentWeatherDelays { get; set; } // Percentage of total flights delayed by "weather"
        public double percentCarrierDelays { get; set; } // Percentage of total flights delayed by "carrier"
        public string airportMaxSecDelays { get; set; } // Airport with the highest number of delays due to "security"
        public string airportMinSecDelays { get; set; } // Airport with the lowest number of delays due to "security"
        public string carrierMinDelays { get; set; } // Carrier with the least amount of "late aircraft"

        public Process(string json)
        {
            this.jArray = JArray.Parse(json);
            this.calculate();
        }

        // main driver function for all calculations
        private void calculate()
        {
            this.calcAirportCount();
            this.calcTotalFlights();
            this.calcTotalCarrierDelays();
            this.calcTotalSecurityDelays();
            this.calcTotalWeatherDelays();
            this.calcPercentages();
            this.calcMinMaxSecDelays();
            this.calcMinDelays();
        }

        // calculates total number of airports
        private int calcAirportCount()
        {
            this.airportCount =
                (from c in jArray
                 group c by c["airport"]["code"]
                     into g
                 select g.Key).Count();
            return this.airportCount;
        }

        // counts total number of flights
        // for percenatage calculations
        private int calcTotalFlights()
        {
            this.totalFlights =
                (from c in jArray
                 select (int)c["statistics"]["flights"]["total"]).Sum();
            return this.totalFlights;
        }

        // calculates total number of security delays
        // for percentage calculations
        private int calcTotalSecurityDelays()
        {
            this.totalSecurityDelays =
                (from c in jArray
                 select (int)c["statistics"]["# of delays"]["security"]).Sum();
            return this.totalSecurityDelays;
        }

        // counts total number of weather delays
        // for percentage calculations
        private int calcTotalWeatherDelays()
        {
            this.totalWeatherDelays =
                (from c in jArray
                 select (int)c["statistics"]["# of delays"]["weather"]).Sum();
            return this.totalWeatherDelays;
        }

        // counts total number of carrier delays
        // for percentage calculations
        private int calcTotalCarrierDelays()
        {
            this.totalCarrierDelays =
                (from c in jArray
                 select (int)c["statistics"]["# of delays"]["carrier"]).Sum();
            return this.totalCarrierDelays;
        }

        // calculates percentage of delays
        private void calcPercentages()
        {
            this.percentCarrierDelays = ((double)totalCarrierDelays / totalFlights) * 100;
            this.percentSecurityDelays = ((double)totalSecurityDelays / totalFlights) * 100;
            this.percentWeatherDelays = ((double)totalWeatherDelays / totalFlights) * 100;
            return;
        }

        // calculates the airports with the most and least delays due to security
        private void calcMinMaxSecDelays()
        {
            var list = (from c in jArray
                        group (int)c["statistics"]["# of delays"]["security"] by c["airport"]["name"] into g
                        orderby g.Sum() descending
                        select (string)g.Key);
            this.airportMaxSecDelays = list.First();
            this.airportMinSecDelays = list.Last();
            return;
        }

        // calculates the carrier with the least amount of delays
        private string calcMinDelays()
        {
            var list = (from c in jArray
                        group (int)c["statistics"]["flights"]["delayed"] by c["carrier"]["name"] into g
                        orderby g.Sum() descending
                        select (string)g.Key);

            this.carrierMinDelays = list.Last();
            return this.carrierMinDelays;
        }
    }
}
