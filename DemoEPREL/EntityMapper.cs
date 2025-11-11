using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoEPREL.Model;
using Newtonsoft.Json.Linq;

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
    }
}
