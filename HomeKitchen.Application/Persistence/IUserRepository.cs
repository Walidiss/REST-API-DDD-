using HomeKitchen.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKitchen.Application.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        
        void AddUser(User user);
    }
}
