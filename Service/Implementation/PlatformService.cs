using System;
using System.Threading.Tasks;
using Data.DbContext;
using Data.Dto;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Service.Enum;
using Service.Interface;

namespace Service.Implementation
{
	public class PlatformService : IPlatformService
	{
		private readonly PaymentSystemContext _context;
		private readonly IHashingService _hashingService;

		public PlatformService(
			PaymentSystemContext context,
			IHashingService hashingService)
		{
			_context = context;
			_hashingService = hashingService;
		}

		public async Task<RegistrationResult> Register(PlatformRegisterDto platformDto)
		{
			if (await IsEmailExistAsync(platformDto.Email))
			{
				return RegistrationResult.EmailAlreadyExist;
			}

			var account = new Account
			{
				Email = platformDto.Email,
				PasswordHash = _hashingService.CreateMD5(platformDto.Password)
			};

			await _context.Accounts.AddAsync(account);
			await _context.SaveChangesAsync();

			var secretKey = new SecretKey
			{
				Value = "PlatformSecretKey" + account.Id,
				AccountId = account.Id
			};

			var platform = new Platform
			{
				AccountId = account.Id,
				PublicKey = "PlatformPublicKey" + account.Id,
			};

			await _context.SecretKeys.AddAsync(secretKey);
			await _context.Platforms.AddAsync(platform);
			await _context.SaveChangesAsync();

			return RegistrationResult.Success;
		}

		private async Task<bool> IsEmailExistAsync(string email)
		{
			return await _context.Accounts.AnyAsync(a => string.Equals(email, a.Email, StringComparison.CurrentCultureIgnoreCase));
		}

	}
}
