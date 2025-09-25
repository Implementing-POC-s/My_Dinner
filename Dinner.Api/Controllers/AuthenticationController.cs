 using Dinner.Contract.Authentication;
using Dinner.Application.Services.Authentication;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers;
[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationservice)
    {
               _authenticationService = authenticationservice;
    }
    
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)

    {
        var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        //map the value to the api reponse that is authentication response
        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult =_authenticationService.Login(request.Email, request.Password);
        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token);
        return Ok(response);

    }
}
