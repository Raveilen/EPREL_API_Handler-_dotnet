using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DotNetEnv;

namespace EprelApiExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DotNetEnv.Env.Load();
            string apiKey = Environment.GetEnvironmentVariable("EPREL_API_KEY");
            // Replace with your actual EPREL API endpoint
            string apiUrl = "https://eprel.ec.europa.eu/api/products/washingmachines2019";

            using (HttpClient client = new HttpClient())
            {
                // Set the Authorization header with the API key (token)
                client.DefaultRequestHeaders.Add("x-api-key", Environment.GetEnvironmentVariable("EPREL_API_KEY"));
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode(); // Throw if not a success code.

                    // Read and process the response JSON string
                    string jsonString = await response.Content.ReadAsStringAsync();

                    await File.WriteAllTextAsync("eprel_response.json", jsonString);
                    Console.WriteLine("Fetched JSON:");
                    Console.WriteLine(jsonString);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }
        }
    }
}