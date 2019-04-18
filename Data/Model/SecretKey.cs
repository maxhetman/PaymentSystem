namespace Data.Model
{
	public class SecretKey
	{
		public int AccountId { get; set; }

		public Account Account { get; set; }

		public string Value { get; set; }
	}
}
