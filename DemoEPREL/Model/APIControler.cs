using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEPREL.Model
{
    public static class APIControler
    {
        public static string GeneralPath { get; } = "https://eprel.ec.europa.eu/api/products/";
        public static string HouseholdWashingMachines { get; } = GeneralPath + "washingmachines";
        public static string WashingMachines2019 { get; } = GeneralPath + "washingmachines2019";
        public static string HouseholdRefrigeratingApplieance { get; } = GeneralPath + "refrigeratingappliances";
        public static string AirConditioners { get; } = GeneralPath + "airconditioners";
        public static string Ovens { get; } = GeneralPath + "ovens";
        public static string Dishwashers { get; } = GeneralPath + "dishwashers";
        public static string Television { get; } = GeneralPath + "televisions";


        public static async void GenerateCategoryJSONFile(string categoryPath, string filename, string apiKey)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
                try
                {
                    HttpResponseMessage response = await client.GetAsync(categoryPath);
                    response.EnsureSuccessStatusCode();

                    string jsonString = await response.Content.ReadAsStringAsync();

                    await File.WriteAllTextAsync($"jsons/{filename}.json", jsonString);
                    Console.WriteLine("Fetched JSON:");
                    Console.WriteLine(jsonString);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }
        }

        public static void GenerateAllCategoryFiles(string apiKey)
        {
            GenerateCategoryJSONFile(HouseholdWashingMachines, "HouseholdWashingMachines", apiKey);
            GenerateCategoryJSONFile(WashingMachines2019, "WashingMachines2019", apiKey);
            GenerateCategoryJSONFile(HouseholdRefrigeratingApplieance, "HouseholdRefrigeratingApplieance", apiKey);
            GenerateCategoryJSONFile(AirConditioners, "AirConditioners", apiKey);
            GenerateCategoryJSONFile(Ovens, "Ovens", apiKey);
            GenerateCategoryJSONFile(Dishwashers, "Dishwashers", apiKey);
            GenerateCategoryJSONFile(Television, "Television", apiKey);
        }
    }
}
