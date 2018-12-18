using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestCoinConsumer
{
	class Program
	{
		private static string URI = "https://restcoinservice20181102095913.azurewebsites.net/api/Coin";	
		static void Main(string[] args)
		{
			// Hent alle mønter
			Console.WriteLine("Hent alle mønter");
			foreach (Coin coin in GetCoinsAsync().Result)
			{
				Console.WriteLine(coin);
			}

			Console.WriteLine("\n\rHent én møned med id 1");
			// Hent én mønt, sender id 1 med for at hente specifikke mønt
			Console.WriteLine( GetCoinAsync(1).Result );

			Console.WriteLine("\n\rPost customer til webservice");
			Coin newCoin = new Coin(0, "Gold FR 2220", 3300, "Arlind U.");

			Console.WriteLine(PostCustomersAsync(newCoin).Result);

			Console.ReadKey();
		}

		public static async Task<List<Coin>> GetCoinsAsync()
		{
			using (HttpClient client = new HttpClient())
			{
				string content = await client.GetStringAsync(URI);

				List<Coin> cList = JsonConvert.DeserializeObject<List<Coin>>(content);
				return cList;
			}
		}

		public static async Task<Coin> GetCoinAsync(int id)
		{
			using (HttpClient client = new HttpClient())
			{
				string content = await client.GetStringAsync(URI + "/" + id);

				Coin coin = JsonConvert.DeserializeObject<Coin>(content);
				return coin;
			}
		}

		public static async Task<Coin> PostCustomersAsync(Coin c)
		{
			using (HttpClient client = new HttpClient())
			{
				// Serialize objectet fra C# objekt til Json objekt
				string cJson = JsonConvert.SerializeObject(c);

				// Lav ny http string med encoding og type (json/application)
				StringContent content = new StringContent(cJson, Encoding.UTF8, "application/json");

				// Post objekt til service og gem resultatet
				HttpResponseMessage res = await client.PostAsync(URI, content);
				string resStr = await res.Content.ReadAsStringAsync();

				return JsonConvert.DeserializeObject<Coin>(resStr);
			}
		}
	}
}
