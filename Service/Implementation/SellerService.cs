using Data.DbContext;
using Data.Dto;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Service.Enum;
using Service.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementation
{
	public class SellerService : ISellerService
	{
		private readonly PaymentSystemContext _context;
		private readonly IHashingService _hashingService;

		public SellerService(
			PaymentSystemContext context,
			IHashingService hashingService)
		{
			_context = context;
			_hashingService = hashingService;
		}

		public async Task<RegistrationResult> Register(SellerRegisterDto sellerDto)
		{
			if (await IsEmailExistAsync(sellerDto.Email))
			{
				return RegistrationResult.EmailAlreadyExist;
			}

			var account = new Account
			{
				Email = sellerDto.Email,
				PasswordHash = _hashingService.CreateMD5(sellerDto.Password)
			};

			await _context.Accounts.AddAsync(account);
			await _context.SaveChangesAsync();

			var secretKey = new SecretKey
			{
				Value = "SellerSecretKey" + account.Id,
				AccountId = account.Id
			};

			var seller = new Seller
			{
				AccountId = account.Id,
				PublicKey = "SellerPublicKey" + account.Id,
			};

			await _context.SecretKeys.AddAsync(secretKey);
			await _context.Sellers.AddAsync(seller);
			await _context.SaveChangesAsync();

			return RegistrationResult.Success;
		}

		public async Task JoinPlatformAsync(int sellerId, int platformId)
		{
			if (await _context
				.Sellers
				.AnyAsync(s => s.Id == sellerId
					&& s.PlatformSellers.Any(x => x.PlatformId == platformId)))
			{
				return; //already joined
			}

			_context.Set<PlatformSeller>().Add(new PlatformSeller {PlatformId = platformId, SellerId = sellerId});
			_context.SaveChanges();
		}

		private async Task<bool> IsEmailExistAsync(string email)
		{
			return await _context.Accounts.AnyAsync(a => string.Equals(email, a.Email, StringComparison.CurrentCultureIgnoreCase));
		}
	}
}
