using System;
using System.Collections.Generic;
using System.Text;

namespace RestCoinConsumer
{
	public class Coin
	{
		public int Id { get; set; }
		public string Genstand { get; set; }
		public int Bud { get; set; }
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

		public override string ToString()
		{
			return "id: " + Id + " genstand: " + Genstand + " Bud: " + Bud + " navn: " + Navn;
		}
	}
}
