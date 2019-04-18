using System.Threading.Tasks;
using Data.DbContext;
using Data.Dto;
using Service.Interface;

namespace Service.Implementation
{
	public class TokenService : ITokenService
	{
		private readonly PaymentSystemContext _context;

		public TokenService(PaymentSystemContext context)
		{
			_context = context;
		}

		public Task<string> CreateTokenAsync(TokenRequestDto tokenRequestDto)
		{
			//todo(max): check public key; check if card credentials are valid (https://developer.visa.com/capabilities/pav/docs-how-to#section1)

			return Task.FromResult("token");
		}
	}
}
