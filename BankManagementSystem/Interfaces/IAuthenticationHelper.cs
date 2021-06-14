using BankManagementSystem.Models;

namespace BankManagementSystem.Helpers
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(UserModel userModel);
    }
}