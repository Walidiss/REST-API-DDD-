using HomeKitchen.Application.Services.Authentication;
using HomeKitchen.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace HomeKitchen.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterRequest request)
        {
            var registerationResult = _authenticationService.register(request.FirstName, request.LastName, request.Email, request.Password);

            var response = new AuthenticationResponse(
                registerationResult.Id,
                registerationResult.FirstName,
                registerationResult.LastName,
                registerationResult.Email,
                registerationResult.Token
                );
            return Ok(response);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest request)
        {
            var authenticationResult = _authenticationService.login(request.Email, request.password);

            var response = new AuthenticationResponse(
                authenticationResult.Id,
                authenticationResult.FirstName,
                authenticationResult.LastName,
                authenticationResult.Email,
                authenticationResult.Token
                );

            return Ok(response);
        }
    }
}
