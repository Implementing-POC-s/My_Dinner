

using Dinner.Application.Common.Interfaces.Authentication;
using  Dinner.Application.Services.Authentication;


public  class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;

    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {

        //Check if user already exists
        //Create user (generate unique ID)
        //Create Jwt Token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId.ToString(), firstName, lastName);
        return new AuthenticationResult(
            
            userId,
            "FirstName",
            "LastName",
            email,
            token//passed variable name as a token
            );
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(

      Guid.NewGuid(),
      "FirstName",
      "LastName",
        email,
       "Token");

    }

}      
