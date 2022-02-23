using FantasyManager.Services.Models.Data;

namespace FantasyManager.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> AddNew(UserModel user);

        Task<UserModel> Login(UserModel user);
    }
}
