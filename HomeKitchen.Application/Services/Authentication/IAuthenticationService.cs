using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKitchen.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult login(string email, string password);

        AuthenticationResult register(string firstName, string lastName, string email, string password);
    }
}
