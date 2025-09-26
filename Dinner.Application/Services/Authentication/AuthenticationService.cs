


using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Application.Services.Authentication;
using Dinner.Domain.Entities;


public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private string token;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;

    }
    public AuthenticationResult Login(string email, string password)
    {
        throw new Exception("invalid password");
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //validate user does not exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
        }
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        //----------------------------------------------------------
        //Check if user already exists
        //Create user (generate unique ID)
        //Create Jwt Token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
//properties of users in pasacal case always
          user,
            token
            );
    }

    public AuthenticationResult Login(User user)
    {
        return new AuthenticationResult(

        user, token);

    }

    
}
