using security_system.Models;

namespace security_system.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);

    }
}
