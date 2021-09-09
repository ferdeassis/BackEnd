using Entities.Dtos;

namespace Application.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(LoginDto loginDto);
    }
}