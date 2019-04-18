using System;

namespace Data.Model
{
	public class Account
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public DateTime? DateVerified { get; set; }
		public SecretKey SecretKey { get; set; }
	}
}
