using System.Threading.Tasks;
using Data.Dto;

namespace Service.Interface
{
	public interface ITokenService
	{
		Task<string> CreateTokenAsync(TokenRequestDto tokenRequestDto);
	}
}
