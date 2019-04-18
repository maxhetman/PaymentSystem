using System.Threading.Tasks;

namespace Service.Interface
{
	public interface IAccountProvider
	{
		Task<int> GetAccountIdAsync();
		Task<int> GetSellerIdAsync();
	}
}
