using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DemoEPREL.Model;
using DotNetEnv;

namespace EprelApiExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DotNetEnv.Env.Load();
            string apiKey = Environment.GetEnvironmentVariable("EPREL_API_KEY");
            await APIControler.GenerateAllCategoryFiles(apiKey);
        }
    }
}