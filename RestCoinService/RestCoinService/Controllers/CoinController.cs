using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestCoinService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
		private static List<Coin> coinList = new List<Coin>
		{
			new Coin(0, "Gold DK 1640", 2500, "Mike"),
			new Coin(1, "Gold NL 1764", 5000, "Anbo"),
			new Coin(2, "Gold FR 1644", 35000, "Hammer"),
			new Coin(3, "Gold FR 1644", 0, "Auction"),
			new Coin(4, "Gold GR 1333", 2500, "Mike")
		};

	    private static int nextId = coinList.Count;

        // GET: api/Coin
        [HttpGet]
        public List<Coin> Get()
        {
	        return coinList;
        }

        // GET: api/Coin/5
        [HttpGet("{id}", Name = "Get")]
        public Coin Get(int id)
        {
	        Coin c = null;

	        try
	        {
		        c = coinList.Find(coin => coin.Id.Equals(id));
	        }
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
	        }

	        return c;
        }

        // POST: api/Coin
        [HttpPost]
        public Coin Post([FromBody] Coin coin)
        {
	        coin.Id = nextId;
			coinList.Add(coin);

	        nextId++;

	        return coin;
        }

        // PUT: api/Coin/5
        [HttpPut("{id}")]
        public Coin Put(int id, [FromBody] Coin coin)
        {
	        try
	        {
		        int i = coinList.FindIndex(c => c.Id.Equals(id));
		        coinList[i] = coin;
	        }
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
		        return null;
			}

	        return coin;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Coin Delete(int id)
        {
	        Coin coin = coinList.Find(c => c.Id.Equals(id));
	        coinList.Remove(coin);

	        return coin;
		}
    }
}
