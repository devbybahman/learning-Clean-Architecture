namespace clean_arch.Application.JWT;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}