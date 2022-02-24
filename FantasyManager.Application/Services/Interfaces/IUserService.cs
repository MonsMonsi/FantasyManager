using FantasyManager.Application.Models.Data;

namespace FantasyManager.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> AddNew(UserModel user);

        Task<UserModel> Login(UserModel user);
    }
}
