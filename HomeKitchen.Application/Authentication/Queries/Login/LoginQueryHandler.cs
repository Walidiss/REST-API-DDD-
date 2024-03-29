using ErrorOr;
using HomeKitchen.Application.Common.Interfaces.Authentication;
using HomeKitchen.Application.Persistence;
using HomeKitchen.Domain.Entities;
using HomeKitchen.Domain.Common.Errors;
using MediatR;
using HomeKitchen.Application.Common;
using HomeKitchen.Domain.Users;

namespace HomeKitchen.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwTokenGenerator _jwTokenGenerator;
        public LoginQueryHandler(IUserRepository userRepository,IJwTokenGenerator jwTokenGenerator)
        {
            _userRepository = userRepository;
            _jwTokenGenerator = jwTokenGenerator;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserByEmail(request.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentails;
            }

            if(user.Password !=  request.Password)
            {
                return new[] { Errors.Authentication.InvalidCredentails };
            }

            var token = _jwTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(
                user,
                token);

        }
    }
}
