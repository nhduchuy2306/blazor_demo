using ServerLibrary.Dtos;

namespace ServerLibrary.Services;

public interface ITokenService
{
    string GenerateToken(AccountDTO accountDTO);
}
