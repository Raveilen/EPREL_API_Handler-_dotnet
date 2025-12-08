
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace DemoEPREL.Model
{
    public class AirConditioner
    {
        public static List<AirConditioner> All { get; set; } = new List<AirConditioner>();

        [JsonPropertyName("supplierOrTrademark")]
        public string Producer { get; set; }

        [JsonPropertyName("modelIdentifier")]
        public string ModelIdentifier { get; set; }

        [JsonPropertyName("energyClass")]
        public string EnergyClass { get; set; }

        [JsonPropertyName("annualElectricityConsumption")]
        public double AnnualElectricityConsumption { get; set; }

        [JsonPropertyName("seasonalEnergyEfficiencyRatio")]
        public double SeasonalEnergyEfficiencyRatio { get; set; }

        [JsonPropertyName("annualElectricityConsumptionAverage")]
        public double AnnualElectricityConsumptionAverage { get; set; }

        [JsonPropertyName("seasonalCoefficientOfPerformanceAverage")]
        public double SeasonalCoefficientOfPerformanceAverage { get; set; }

        public AirConditioner(JToken jsonData)
        {
            Producer = jsonData.SelectToken("supplierOrTrademark").ToString();
            ModelIdentifier = jsonData.SelectToken("modelIdentifier").ToString();
            EnergyClass = jsonData.SelectToken("energyClass").ToString();
            AnnualElectricityConsumption = Convert.ToDouble(jsonData.SelectToken("coolingCharacteristics.annualElectricityConsumption"));
            SeasonalEnergyEfficiencyRatio = Convert.ToDouble(jsonData.SelectToken("coolingCharacteristics.seasonalEnergyEfficiencyRatio"));
            AnnualElectricityConsumptionAverage = Convert.ToDouble(jsonData.SelectToken("heatingCharacteristics.annualElectricityConsumptionAverage"));
            SeasonalCoefficientOfPerformanceAverage = Convert.ToDouble(jsonData.SelectToken("heatingCharacteristics.seasonalCoefficientOfPerformanceAverage"));
            All.Add(this);
        }
    }
}

