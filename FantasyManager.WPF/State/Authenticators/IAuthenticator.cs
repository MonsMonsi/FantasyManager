using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Enums;
using System.Threading.Tasks;

namespace FantasyManager.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        User CurrentUser { get; }
        bool IsLoggedIn { get; }
        Task<RegistrationResult> Register(string userName, string password, string confirmPassword, string email);
        Task<bool> Login(string userName, string password);
        void Logout();
    }
}
