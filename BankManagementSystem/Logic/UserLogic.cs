using BankManagementSystem.Helpers;
using BankManagementSystem.Interfaces;
using BankManagementSystem.Models;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankManagementSystem.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDal _userDal;
        private readonly IAuthenticationHelper _authenticationHelper;

        public UserLogic(IUserDal userDal, IAuthenticationHelper authenticationHelper)
        {
            _userDal = userDal;
            _authenticationHelper = authenticationHelper;
        }

        public async Task<LoginResultModel> LoginUser(LoginModel loginModel)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.IdNumber) || string.IsNullOrEmpty(loginModel.Password))
                throw new ArgumentException("נא להשלים את כל השדות");

            UserModel userModel = await _userDal.FindUserAsync(loginModel);

            if(userModel == null) throw new Exception("משתמש אינו קיים");

            string token = _authenticationHelper.GenerateToken(userModel);
            LoginResultModel userWithGeneratedToken = new LoginResultModel
            {
                UserModel = userModel,
                Token = token
            };
            return userWithGeneratedToken;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID is not valid.");

            return await _userDal.GetUserById(id);
        }

        public async Task<UserModel> UpdateUserById(UpdateUserModel updateUserModel, int id) 
        {
            if (id <= 0 || isUpdateUserEmpty(updateUserModel))
                throw new ArgumentException("נא למלא את כל השדות");

            if(!string.IsNullOrEmpty(updateUserModel.PhoneNumber) && !validPhoneNumber(updateUserModel.PhoneNumber)) throw new ArgumentException("מספר פלאפון אינו תקין");

            return await _userDal.UpdateUserById(updateUserModel, id);
        }

        private bool isUpdateUserEmpty(UpdateUserModel updateUserModel)
        {
            bool isEmpty = true;
            if(updateUserModel != null &&
                !string.IsNullOrEmpty(updateUserModel.Email) &&
                !string.IsNullOrEmpty(updateUserModel.CompanyName) &&
                !string.IsNullOrEmpty(updateUserModel.CompanyNumber) &&
                validDate(updateUserModel.DateOfBirth))
            {
                isEmpty = false;
            }
            return isEmpty;
        }

        private bool validDate(DateTime date)
        {
            bool isValid = false;

            if (date != DateTime.MinValue)
            {
                isValid = true;
            }

            return isValid;
        }

        private bool validPhoneNumber(string phoneNumber)
        {
            bool isValid = Regex.Match(phoneNumber, @"^\d{10}$").Success;
            return isValid;
        }
    }
}
