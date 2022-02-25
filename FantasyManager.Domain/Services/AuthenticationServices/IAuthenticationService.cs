using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Domain.Services
{
    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string userName, string password, string confirmPassword, string email);

        Task<User> Login(string userName, string password);
    }
}
