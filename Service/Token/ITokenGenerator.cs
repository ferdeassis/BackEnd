using Entities.Dtos;

namespace Service.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(LoginDto loginDto);
    }
}