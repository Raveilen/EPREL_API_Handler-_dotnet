using DemoEPREL;
using DemoEPREL.Model;

namespace EprelApiExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DotNetEnv.Env.Load();
            string apiKey = Environment.GetEnvironmentVariable("EPREL_API_KEY");
            await APIControler.GenerateAllCategoryFiles(apiKey);

            EntityMapper.MapAllCategories();
            var test = WashingMachine.All;
            var aaa = 5;
        }
    }
}