using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace Api.Controllers
{
	[Route("/api/token")]
	[ApiController]
	public class TokenController : Controller
	{
		private readonly ITokenService _tokenService;

		public TokenController(ITokenService tokenService)
		{
			_tokenService = tokenService;
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateToken(TokenRequestDto tokenRequestDto)
		{
			var token = await _tokenService.CreateTokenAsync(tokenRequestDto);

			return Json(token);
		}
	}
}
