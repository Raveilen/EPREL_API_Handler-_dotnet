
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace DemoEPREL.Model
{
    public class Oven
    {
        public static List<Oven> All { get; set; } = new List<Oven>();

        [JsonPropertyName("supplierOrTrademark")]
        public string Producer { get; set; }

        [JsonPropertyName("modelIdentifier")]
        public string ModelIdentifier { get; set; }

        [JsonPropertyName("energyClass")]
        public string EnergyClass { get; set; }

        [JsonPropertyName("energyConsumptionCycle")] //cavities
        public double? EnergyConsumptionCycle {  get; set; }

        [JsonPropertyName("energyConsumptionCycleFanForced")] //cavities
        public double? EnergyConsumptionCycleFanForced { get; set; }

        [JsonPropertyName("energyEfficiencyIndex")] //cavities
        public double EnergyEfficiencyIndex { get; set; }

        [JsonPropertyName("volume")]
        public double Volume { get; set; }

        public Oven(JToken jsonData)
        {
            Producer = jsonData.SelectToken("supplierOrTrademark").ToString();
            ModelIdentifier = jsonData.SelectToken("modelIdentifier").ToString();
            EnergyClass = jsonData.SelectToken("energyClass").ToString();

            var energyConsumptionCycle = jsonData.SelectToken("cavities.[0].energyConsumptionCycle");
            EnergyConsumptionCycle = energyConsumptionCycle.HasValues ? Convert.ToDouble(energyConsumptionCycle) : null;

            var energyConsumptionCycleFanForced = jsonData.SelectToken("cavities.[0].energyConsumptionCycleFanForced");
            EnergyConsumptionCycleFanForced = energyConsumptionCycleFanForced.HasValues ? Convert.ToDouble(energyConsumptionCycleFanForced) : null;

            EnergyEfficiencyIndex = Convert.ToDouble(jsonData.SelectToken("cavities.[0].energyEfficiencyIndex"));
            Volume = Convert.ToDouble(jsonData.SelectToken("cavities.[0].volume"));
            All.Add(this);
        }
    }
}
