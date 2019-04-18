using System.Linq;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System.Threading.Tasks;
using Api.Filters;
using Data.DbContext;

namespace Api.Controllers
{
	[Route("api/seller")]
	[ApiController]
	public class SellerController : ControllerBase
	{
		private readonly ISellerService _sellerService;
		private readonly IAccountProvider _accountProvider;
		private readonly PaymentSystemContext _context;

		public SellerController(
			ISellerService sellerService,
			PaymentSystemContext context,
			IAccountProvider accountProvider)
		{
			_sellerService = sellerService;
			_context = context;
			_accountProvider = accountProvider;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(SellerRegisterDto sellerDto)
		{
			var result = await _sellerService.Register(sellerDto);
			return Ok(result);
		}

		/// <summary>
		/// Used when seller wants to join marketplace
		/// </summary>
		[ApiAuthorize]
		[HttpPost("join")]
		public async Task<IActionResult> Join(SellerJoinDto joinDto)
		{
			if (!_context.Platforms.Any(p => p.Id == joinDto.PlatformId))
				return BadRequest();

			int sellerId = await _accountProvider.GetSellerIdAsync();
			if (sellerId == -1)
				return BadRequest();

			await _sellerService.JoinPlatformAsync(sellerId, joinDto.PlatformId);
			return Ok();
		}
	}
}
