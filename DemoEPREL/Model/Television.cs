using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;

namespace DemoEPREL.Model
{
    public class Television
    {
        public static List<Television> All { get; set; } = new List<Television>();


        [JsonPropertyName("supplierOrTrademark")]
        public string Producer { get; set; }

        [JsonPropertyName("modelIdentifier")]
        public string ModelIdentifier { get; set; }

        [JsonPropertyName("diagonalInch")]
        public double DiagonalInch { get; set; }

        [JsonPropertyName("horizontalResolution")]
        public double HorizontalResolution { get; set; }

        [JsonPropertyName("energyClass")]
        public string EnergyClass { get; set; }

        [JsonPropertyName("energyAnual")]
        public double EnergyAnual { get; set; }

        [JsonPropertyName("energyConsumption")]
        public double EnergyConsumption { get; set; }

        [JsonPropertyName("energyConsumptionStandbyMode")]
        public double EnergyConsumptionStandbyMode {  get; set; }

        public Television(JToken jsonData)
        {
            Producer = jsonData.SelectToken("supplierOrTrademark").ToString();
            ModelIdentifier = jsonData.SelectToken("modelIdentifier").ToString();
            DiagonalInch = Convert.ToDouble(jsonData.SelectToken("diagonalInch"));
            HorizontalResolution = Convert.ToDouble(jsonData.SelectToken("horizontalResolution"));
            EnergyClass = jsonData.SelectToken("energyClass").ToString();
            EnergyAnual = Convert.ToDouble(jsonData.SelectToken("energyAnnual"));
            EnergyConsumption = Convert.ToDouble(jsonData.SelectToken("energyConsumption"));
            EnergyConsumptionStandbyMode = Convert.ToDouble(jsonData.SelectToken("energyConsumptionStandbyMode"));

            All.Add(this);
        }
    }
}
