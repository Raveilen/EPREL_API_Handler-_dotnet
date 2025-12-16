using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoEPREL.Model;
using Newtonsoft.Json.Linq;
using Sprache;

namespace DemoEPREL
{
    public static class EntityMapper
    {
        public static void MapAllTelevisions()
        {
            var jsonData = JObject.Parse(File.ReadAllText($"jsons/{JSONFileNames.Televisions}"));
            var hits = jsonData.SelectToken("hits");

            foreach(JToken jt in hits)
            {
                new Television(jt);
            }

        }

        public static void MapAllAirConditioners()
        {
            var jsonData = JObject.Parse(File.ReadAllText($"jsons/{JSONFileNames.AirConditioners}"));
            var hits = jsonData.SelectToken("hits");

            foreach(JToken jt in hits)
            {
                new AirConditioner(jt);
            }
        }

        public static void MapAllRefrigerators()
        {
            var jsonData = JObject.Parse(File.ReadAllText($"jsons/{JSONFileNames.HouseholdRefrigeratingApplieance}"));
            var hits = jsonData.SelectToken("hits");

            foreach(JToken jt in hits)
            {
                new Refrigerator(jt);
            }
        }

        public static void MapAllOvens()
        {
            var jsonData = JObject.Parse(File.ReadAllText($"jsons/{JSONFileNames.Ovens}"));
            var hits = jsonData.SelectToken("hits");

            foreach(JToken jt in hits)
            {
                new Oven(jt);
            }
        }

        public static void MapAllWashingMachines()
        {
            var jsonData = JObject.Parse(File.ReadAllText($"jsons/{JSONFileNames.WashingMachines2019}"));
            var hits = jsonData.SelectToken("hits");

            foreach (JToken jt in hits)
            {
                new WashingMachine(jt);
            }

        }

        public static void MapAllCategories()
        {
            MapAllTelevisions();
            MapAllAirConditioners();
            MapAllRefrigerators();
            MapAllOvens();
            MapAllWashingMachines();
        }
        
    }
}
