namespace Data.Model
{
	public class PlatformSeller
	{
		public int PlatformId { get; set; }
		public Platform Platform { get; set; }

		public int SellerId { get; set; }
		public Seller Seller { get; set; }
	}
}
