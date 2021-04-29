using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SImpleReceiverPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            bool cont = true;

            while (cont) {
                Console.WriteLine("Please enter a command (update/END)");
                string input = Console.ReadLine();
                if (input == "END")
                    cont = false;
                else if (input == "update") {
                    //HttpResponseMessage response = await client.GetAsync("https://localhost:44359/receive");
                    //text = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Message received: {getMessage(client).Result.ToString()}");
                }
            }
        }

        public async static Task<string> getMessage(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:44359/receive");
            string text = await response.Content.ReadAsStringAsync();
            return text;
        }
    }
}
