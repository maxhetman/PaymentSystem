using System.Collections.Generic;

namespace Data.Model
{
	public class Seller
	{
		public int Id { get; set; }

		public int AccountId { get; set; }

		public Account Account { get; set; }

		public string PublicKey { get; set; }

		public ICollection<PlatformSeller> PlatformSellers { get; set; }
	}
}
