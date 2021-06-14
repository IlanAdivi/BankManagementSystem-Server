using BankAccountManagement.Interfaces;
using BankManagementSystem.Helpers;
using BankManagementSystem.Interfaces;
using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountManagement.Logic
{
    public class BankAccountLogic : IBankAccountLogic
    {
        private readonly IBankAccountDal _bankAccountDal;
        private readonly IUserLogic _userLogic;
        public BankAccountLogic(IBankAccountDal bankAccountDal, IUserLogic userLogic)
        {
            _bankAccountDal = bankAccountDal;
            _userLogic = userLogic;
        }

        public IEnumerable<BankOptionsModel> GetAllBanks()
        {
            BankHelper bankHelper = new BankHelper();
            if(bankHelper == null)
            {
                throw new ArgumentException("Invalid Request");
            }

            return bankHelper.BankOptions;
        }

        public async Task<List<BankAccountModel>> GetAllBankAccountsByUserId(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("ID is not valid.");

            List<BankAccountModel> bankAccounts = _bankAccountDal.GetAllBankAccountsByUserId(userId).ToList();

            foreach (BankAccountModel bankAccount in bankAccounts)
            {
                UserModel userModel = await _userLogic.GetUserById(bankAccount.UserId);
                bankAccount.User = userModel;
            }

            return bankAccounts;
        }

        public async Task<BankAccountModel> CreateBankAccount(BankAccountModel bankAccountModel, int userId)
        {
            if (bankAccountModel == null ||
                string.IsNullOrEmpty(bankAccountModel.Name) ||
                string.IsNullOrEmpty(bankAccountModel.AccountNumber) ||
                string.IsNullOrEmpty(bankAccountModel.Branch))
            {
                throw new Exception("חשבון הבנק לא נוצר בהצלחה");
            }

            return await _bankAccountDal.CreateBankAccount(bankAccountModel, userId);
        }

        public async Task<IEnumerable<BankAccountModel>> LoanBankAccount(LoanModel loanModel, int userId)
        {
            if(loanModel == null || !validLoanPeriod(loanModel.LoanPeriod) || !validLoanAmount(loanModel.LoanAmount)) throw new Exception("הלוואה אינה תקינה");
            return await _bankAccountDal.LoanBankAccount(loanModel, userId);
        }

        public async Task<BankAccountModel> DeleteBankAccount(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID is not valid.");

            return await _bankAccountDal.DeleteBankAccount(id);
        }

        private bool validLoanPeriod(int loanPeriod)
        {
            bool isValid = false;
            if (loanPeriod >= 4 && loanPeriod <= 8)
            {
                isValid = true;
            }

            return isValid;
        }

        private bool validLoanAmount(int loanAmount)
        {
            bool isValid = false;
            if (loanAmount >= 100000 && loanAmount <= 1000000)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
