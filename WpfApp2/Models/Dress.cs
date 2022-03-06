using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
	public class Dress
	{
		public int Id { get; set; }
		public string material { get; set; }
		public int size { get; set; }
		public double price { get; set; }

		public Dress(string material, int size, double price)
		{
			this.material = material;
			this.size = size;
			this.price = price;
		}
	}
}
