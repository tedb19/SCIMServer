
using SCIMServer.Domain.Models;

namespace SCIMServer.Domain.Services
{
    public interface ITokenService
    {
        BearerToken GenerateToken();
    }
}
