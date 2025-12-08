using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DemoEPREL.Model
{
    public class Refrigerator
    {
        public static List<Refrigerator> All = new List<Refrigerator>();

        [JsonPropertyName("supplierOrTrademark")]
        public string Producer { get; set; }

        [JsonPropertyName("modelIdentifier")]
        public string ModelIdentifier { get; set; }

        [JsonPropertyName("capacity")] //compartments.[0]
        public double Capacity { get; set; }

        [JsonPropertyName("energyClass")]
        public string EnergyClass { get; set; }

        [JsonPropertyName("energyConsAnnual")]
        public double AnnualEnergyConsumption { get; set; }

        public Refrigerator(JToken jsonData)
        {
            Producer = jsonData.SelectToken("supplierOrTrademark").ToString();
            ModelIdentifier = jsonData.SelectToken("modelIdentifier").ToString();
            Capacity = Convert.ToDouble(jsonData.SelectToken("compartments.[0].capacity"));
            EnergyClass =jsonData.SelectToken("energyClass").ToString();
            AnnualEnergyConsumption = Convert.ToDouble(jsonData.SelectToken("energyConsAnnual"));
            All.Add(this);
        }
    }
}
