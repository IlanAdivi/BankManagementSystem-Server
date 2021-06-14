using BankManagementSystem.Models;
using System.Threading.Tasks;

namespace BankManagementSystem.Interfaces
{
    public interface IUserDal
    {
        Task<UserModel> FindUserAsync(LoginModel loginModel);
        Task<UserModel> GetUserById(int id);
        Task<UserModel> UpdateUserById(UpdateUserModel updateUserModel, int id);
    }
}
