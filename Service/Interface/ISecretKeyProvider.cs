using Data.Model;

namespace Service.Interface
{
	interface ISecretKeyProvider
	{
		SecretKey GetSecretKey();
	}
}
