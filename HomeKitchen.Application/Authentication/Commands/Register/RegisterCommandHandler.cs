using ErrorOr;
using HomeKitchen.Application.Common;
using HomeKitchen.Application.Common.Interfaces.Authentication;
using HomeKitchen.Application.Persistence;
using HomeKitchen.Domain.Common.Errors;
using HomeKitchen.Domain.Entities;
using MediatR;

namespace HomeKitchen.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwTokenGenerator _jwTokenGenerator;

        public RegisterCommandHandler(IUserRepository userRepository, IJwTokenGenerator jwTokenGenerator)
        {
            _userRepository = userRepository;
            _jwTokenGenerator = jwTokenGenerator;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // 1.Validate user dosen't exist   
            if(_userRepository.GetUserByEmail(request.Email) is not null)
            {
                return  Errors.User.DuplicateEmail;
            }

            // 2.Create user 
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };
            _userRepository.AddUser(user);

            // 3.Generate jwt token
            var token = _jwTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
