using System.Threading.Tasks;
using Data.Dto;
using Service.Enum;

namespace Service.Interface
{
	public interface IPlatformService
	{
		Task<RegistrationResult> Register(PlatformRegisterDto sellerDto);
	}
}
