using HomeKitchen.Application.Abstractions;
using HomeKitchen.Application.Common.Interfaces.Authentication;
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

        public AuthenticationService(IJwTokenGenerator jwTokenGenerator)
        {
            _jwTokenGenerator = jwTokenGenerator;
        }

        public AuthenticationResult login(string email, string password)
        {

            return new AuthenticationResult(
                Guid.NewGuid(), 
                "firstName",
                "lastName",
                email,
                "token");
        }

        public AuthenticationResult register(string firstName, string lastName, string email, string password)
        {
             var userId = Guid.NewGuid();
             var token = _jwTokenGenerator.GenerateToken(userId, firstName, lastName);

            return new AuthenticationResult(
                Guid.NewGuid(), 
                firstName,
                lastName,
                email,
                token);
        }
    }
}
