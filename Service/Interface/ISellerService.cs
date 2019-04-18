using Data.Dto;
using Service.Enum;
using System.Threading.Tasks;

namespace Service.Interface
{
	public interface ISellerService
	{
		Task<RegistrationResult> Register(SellerRegisterDto sellerDto);
		Task JoinPlatformAsync(int sellerId, int platformId);
	}
}
