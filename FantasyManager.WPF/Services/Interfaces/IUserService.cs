using FantasyManager.WPF.Models.Data;
using System.Threading.Tasks;

namespace FantasyManager.WPF.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> AddNew(UserModel user);

        Task<UserModel> Login(UserModel user);
    }
}
