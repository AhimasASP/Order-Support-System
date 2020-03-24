using OSS.Domain.Common.Models.Api.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace OSS.Domain.Interfaces.Services
{
	public interface IAuthorizationService
	{
		Task<string> AuthorizeAsync(LoginRequest request, CancellationToken cancellationToken);
	}
}