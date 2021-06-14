using BankManagementSystem.Interfaces;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BankManagementSystem.Dal
{
    public class UserDal : IUserDal
    {
        private BankManagementSystemDbContext _context;

        public UserDal(BankManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> FindUserAsync(LoginModel loginModel)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.IdNumber == loginModel.IdNumber&& e.Password == loginModel.Password);
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<UserModel> UpdateUserById(UpdateUserModel updateUserModel, int id)
        {
            UserModel updateUser = await _context.Users.FindAsync(id);
            updateUser.PhoneNumber = updateUserModel.PhoneNumber;
            updateUser.Email = updateUserModel.Email;
            updateUser.CompanyName = updateUserModel.CompanyName;
            updateUser.CompanyNumber = updateUserModel.CompanyNumber;
            updateUser.DateOfBirth = updateUserModel.DateOfBirth;
            updateUser.LastLoginDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return updateUser;
        }
    }
}
