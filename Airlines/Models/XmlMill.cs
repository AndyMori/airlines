using System;
namespace Airlines.Models
{
    public class XmlMill
    {
        private Process results;
        public string xml;
        public XmlMill(Process p)
        {
            this.results = p;
            this.build();
        }

        private void build()
        {
            this.xml =
                $"<Data>" +
                $"<TotalAirports>{this.results.airportCount}</TotalAirports>" +
                $"<TotalFlights>{this.results.totalFlights}</TotalFlights>" +
                $"<PercentageDelays>" +
                $"<Security>{this.results.percentSecurityDelays}</Security>" +
                $"<Weather>{this.results.percentWeatherDelays}</Weather>" +
                $"<Carrier>{this.results.percentCarrierDelays}</Carrier>" +
                $"</PercentageDelays>" +
                $"<AirportDelays>" +
                $"<MostSecurity>{this.results.airportMaxSecDelays}</MostSecurity>" +
                $"<LeastSecurity>{this.results.airportMinSecDelays}</LeastSecurity>" +
                $"</AirportDelays>" +
                $"<Carrier>" +
                $"<LeastLate>{this.results.carrierMinDelays}</LeastLate>" +
                $"</Carrier>" +
                $"</Data>";
        }
    }
}
