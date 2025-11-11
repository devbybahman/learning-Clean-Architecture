using clean_arch.Application.JWT;

namespace clean_arch.Application.Authentication;

public class AuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public string Login(string email, string password)
    {
        // 1. کاربر را پیدا کنید
        var user = _userRepository.GetUserByEmail(email);
        if (user is null)
        {
            throw new Exception("User not found.");
        }

        // 2. رمز عبور را بررسی کنید (در اینجا به سادگی مقایسه شده، شما باید از مکانیزم هش استفاده کنید)
        if (user.PasswordHash != password) // اینجا باید Password Hashing را چک کنید
        {
            throw new Exception("Invalid password.");
        }

        // 3. توکن تولید کنید
        var token = _jwtTokenGenerator.GenerateToken(user);

        return token;
    }
}