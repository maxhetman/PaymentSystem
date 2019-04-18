using System.Linq;
using System.Threading.Tasks;
using Data.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

namespace Api.Service
{
	public class AccountProvider : IAccountProvider
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly PaymentSystemContext _context;

		//todo(max): add caching
		public AccountProvider(IHttpContextAccessor accessor, PaymentSystemContext context)
		{
			_httpContextAccessor = accessor;
			_context = context;
		}

		public async Task<int> GetAccountIdAsync()
		{
			var authHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

			if (string.IsNullOrEmpty(authHeader)
			    || !authHeader.StartsWith("Bearer"))
			{
				//todo(max): log error. should never be here!!
				return -1;
			}

			var headerKey = authHeader.Split(" ")[1];

			var secretKeyObj = await _context.SecretKeys.FirstOrDefaultAsync(x => x.Value == headerKey);

			return secretKeyObj?.AccountId ?? -1;
		}

		public async Task<int> GetSellerIdAsync()
		{
			var accountId = await GetAccountIdAsync();

			if (accountId == -1)
				return -1;

			return (await _context.Sellers.FirstOrDefaultAsync(s => s.AccountId == accountId))?.Id ?? -1;;
		}
	}
}
