using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
	public class SellerRegisterDto
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MinLength(5)]
		public string Password { get; set; }
	}
}
