using ErrorOr;
using HomeKitchen.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using HomeKitchen.Domain.Common.Errors;
using MediatR;
using HomeKitchen.Application.Authentication.Commands.Register;
using HomeKitchen.Application.Authentication.Queries.Login;
using HomeKitchen.Application.Common;
using MapsterMapper;

namespace HomeKitchen.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        public AuthenticationController(ISender sender,IMapper mapper)
        {   
            _sender = sender;
            _mapper = mapper;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> registerationResult = await _sender.Send(command);

            //if(registerationResult.IsError && registerationResult.FirstError == Errors.User.DuplicateEmail)
            //{
            //    return Problem(statusCode: StatusCodes.Status401Unauthorized, title: registerationResult.FirstError.Description);
            //}
           return registerationResult.Match(            
               registerationResult => Ok(_mapper.Map<AuthenticationResponse>(registerationResult)),
                errors => Problem(errors)
                );
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            //var query = _mapper.Map<LoginQuery>(request);
            ErrorOr<AuthenticationResult> authenticationResult = await _sender.Send(query);

            if(authenticationResult.IsError && authenticationResult.FirstError == Errors.Authentication.InvalidCredentails)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authenticationResult.FirstError.Description);
            }
            return authenticationResult.Match (
                authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authenticationResult)),
                errors => Problem(errors)
                ) ;
        }
    }
}
