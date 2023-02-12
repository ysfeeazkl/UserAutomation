using System;

namespace UserAutomation.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Welcome to Yusuf Efe's Otomations");

            string url = "https://localhost:7264/api/CompanyControllers/GetById";
            //string url = "https://localhost:7264/WeatherForecast";


            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                Console.WriteLine(response);
                //if (response.IsSuccessStatusCode)
                //{
                //    Console.WriteLine(response.Content);
                //}
            }

            Console.ReadKey();
        }
    }
}