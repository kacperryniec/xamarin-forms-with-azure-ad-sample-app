using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace adal_sample
{
	public interface IAuthenticationService
	{
		Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri);
	}
}
