using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
	public class TokenRequestDto
	{
		[Required]
		[Range(0000000000000000, 9999999999999999)]
		public long CardNumber { get; set; }

		[Required]
		[Range(000, 999)]
		public short Cvv { get; set; }

		//in format mm.yy may be change later
		[Required]
		public string DateExpire { get; set; }

		[Required]
		public string PlatformPublicKey { get; set; }
	}
}
