using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System.Threading.Tasks;

namespace Api.Controllers
{
	[Route("api/platform")]
	[ApiController]
	public class PlatformController: ControllerBase
	{
		private readonly IPlatformService _platformService;

		public PlatformController(IPlatformService platformService)
		{
			_platformService = platformService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(PlatformRegisterDto platformDto)
		{
			var result = await _platformService.Register(platformDto);
			return Ok(result);
		}

	}
}
