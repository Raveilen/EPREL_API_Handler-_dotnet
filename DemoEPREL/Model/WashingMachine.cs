using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DemoEPREL.Model
{
    public class WashingMachine
    {
        public static List<WashingMachine> All { get; set; } = new List<WashingMachine>();

        [JsonPropertyName("supplierOrTrademark")]
        public string Producer { get; set; }

        [JsonPropertyName("modelIdentifier")]
        public string ModelIdentifier { get; set; }

        [JsonPropertyName("energyClass")]
        public string EnergyClass { get; set; }

        [JsonPropertyName("dimensionDepth")]
        public double? DimensionDepth { get; set; }

        [JsonPropertyName("dimensionHeight")]
        public double? DimensionHeight { get; set; }

        [JsonPropertyName("dimensionWidth")]
        public double? DimensionWidth { get; set; }

        [JsonPropertyName("waterCons")]
        public double? WaterConsumption { get; set; }

        [JsonPropertyName("energyConsPer100Cycle")]
        public double? EnergyConsPer100Cycle { get; set; }

        [JsonPropertyName("energyConsPerCycle")]
        public double? EnergyConsPerCycle { get; set; }

        [JsonPropertyName("energyEfficiencyIndex")]
        public double? EnergyEfficiencyIndex { get; set; }

        public WashingMachine(JToken jsonData)
        {
            Producer = jsonData.SelectToken("supplierOrTrademark").ToString();
            ModelIdentifier = jsonData.SelectToken("modelIdentifier").ToString();
            EnergyClass = jsonData.SelectToken("energyClass").ToString();
            DimensionDepth = Convert.ToDouble(jsonData.SelectToken("dimensionDepth"));
            DimensionHeight = Convert.ToDouble(jsonData.SelectToken("dimensionHeight"));
            DimensionWidth = Convert.ToDouble(jsonData.SelectToken("dimensionWidth"));
            WaterConsumption = Convert.ToDouble(jsonData.SelectToken("waterCons"));
            EnergyConsPer100Cycle = Convert.ToDouble(jsonData.SelectToken("energyConsPer100Cycle"));
            EnergyConsPerCycle = Convert.ToDouble(jsonData.SelectToken("energyConsPerCycle"));
            EnergyEfficiencyIndex = Convert.ToDouble(jsonData.SelectToken("energyEfficiencyIndex"));

            All.Add(this);
        }

    }
}
