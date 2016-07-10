using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetrySharp;
using MetrySharp.Models;

namespace MetrySharpExample
{
    public class Program
    {
        private static async Task MainAsync()
        {
            // Set up the MetryClient
            MetryConfiguration config = new MetryConfiguration()
            {
                AccessToken = "" // Add your access token here
            };
            MetryClient client = new MetryClient(config);
            
            // Get a list of all meters
            MetryPaginatedResponse<Meter> meters = await client.Meters.GetMeters();
            Console.WriteLine("Num meters: {0}", meters.Count);
            return;
        }

        [STAThread]
        public static void Main(string[] args)
        {
            MainAsync().Wait();
        }
    }
}
