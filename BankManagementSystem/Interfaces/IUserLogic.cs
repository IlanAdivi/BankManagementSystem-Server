using BankManagementSystem.Models;
using System.Threading.Tasks;

namespace BankManagementSystem.Interfaces
{
    public interface IUserLogic
    {
        Task<LoginResultModel> LoginUser(LoginModel loginModel);
        Task<UserModel> GetUserById(int id);
        Task<UserModel> UpdateUserById(UpdateUserModel updateUserModel, int id);
    }
}
