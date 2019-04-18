using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
	public class PlatformRegisterDto
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MinLength(5)]
		public string Password { get; set; }
	}
}
