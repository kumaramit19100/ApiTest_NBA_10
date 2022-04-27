using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest_NBA_10
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public string BirthDate { get; set; }
        public string PhotoUrl { get; set; }
        public string SportRadarPlayerID { get; set; }
        public string FanDuelName { get; set; }
        public string YahooName { get; set; }
        public string UsaTodayHeadshotUrl { get; set; }
        public string UsaTodayHeadshotUpdated { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            api().Wait();
            Console.ReadKey();
        }

        public static async Task api()
        {
            var Keys = "?Ocp-Apim-Subscription-Key=b2604730c1724b21ba76910924423bd7";

            using (HttpClient client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.sportsdata.io/v3/nba/scores/json/FreeAgents");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "b2604730c1724b21ba76910924423bd7");
               
                HttpResponseMessage message =await client.GetAsync(Keys);
                if (message.IsSuccessStatusCode)
                {
                    var data = message.Content.ReadAsAsync<IEnumerable<Player>>().Result;
                    foreach (var v in data)
                    {
                        Console.WriteLine("Player Name : "+v.FirstName+" "+v.LastName);
                        Console.WriteLine("Player Id : "+v.PlayerID);
                        Console.WriteLine("Status : " + v.Status);
                        Console.WriteLine("Birth Date : " + v.BirthDate);
                        Console.WriteLine("Photo Url : " + v.PhotoUrl);
                        Console.WriteLine("Sport Radar Player ID : " + v.SportRadarPlayerID);
                        Console.WriteLine("Fan Duel Name : " + v.FanDuelName);
                        Console.WriteLine("Yahoo Name : " + v.YahooName);
                        Console.WriteLine("Usa Today Head Shot Url : " + v.UsaTodayHeadshotUrl);
                        Console.WriteLine("Usa Today Head Shot Updated : " + v.UsaTodayHeadshotUpdated);

                    }
                }
            }
        }
    }
}
