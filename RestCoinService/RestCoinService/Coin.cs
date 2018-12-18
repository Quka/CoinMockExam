using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCoinService
{
	public class Coin
	{
		public int Id { get; set; }
		public string Genstand { get; set; }
		public int Bud { get; set; } // viser pris, burde laves som decimal
		public string Navn { get; set; }

		public Coin(int id, string genstand, int bud, string navn)
		{
			Id = id;
			Genstand = genstand;
			Bud = bud;
			Navn = navn;
		}

		public Coin()
		{
			
		}
	}
}
