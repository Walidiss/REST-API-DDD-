using HomeKitchen.Application.Abstractions;
using HomeKitchen.Application.Common.Interfaces.Authentication;
using HomeKitchen.Application.Persistence;
using HomeKitchen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKitchen.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwTokenGenerator _jwTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwTokenGenerator jwTokenGenerator, IUserRepository userRepository)
        {
            _jwTokenGenerator = jwTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult login(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exist");
            }

            if(user.Password != password)
            {
                throw new Exception("Invalid password");
            }
            var token = _jwTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
            return new AuthenticationResult(
                user.Id,
                user.FirstName,
                user.LastName,
                email, 
                token);
        }

        public AuthenticationResult register(string firstName, string lastName, string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email already exist");
            }
            var user = new User
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password
            };
            _userRepository.AddUser(user);
            var token = _jwTokenGenerator.GenerateToken(user.Id,firstName,lastName);

            return new AuthenticationResult(
                Guid.NewGuid(),
                firstName,
                lastName,
                email,
                token);
        }
    }
}
