using BankAccountManagement.Interfaces;
using BankManagementSystem;
using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountManagement.Dal
{
    public class BankAccountDal : IBankAccountDal
    {
        private BankManagementSystemDbContext _context;

        public BankAccountDal(BankManagementSystemDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BankAccountModel> GetAllBankAccountsByUserId(int userId)
        {
            return _context.BankAccounts.Where(x => x.UserId == userId);
        }

        public async Task<BankAccountModel> CreateBankAccount(BankAccountModel bankAccountModel, int userId)
        {
            UserModel userModel = await _context.Users.FindAsync(userId);

            BankAccountModel newBankAccount = new BankAccountModel()
            {
                AccountNumber = bankAccountModel.AccountNumber,
                Branch = bankAccountModel.Branch,
                Name = bankAccountModel.Name,
                UserId = userId,
                User = userModel
            };

            _context.BankAccounts.Add(newBankAccount);
            await _context.SaveChangesAsync();
            return newBankAccount;
        }

        public async Task<IEnumerable<BankAccountModel>> LoanBankAccount(LoanModel loanModel, int userId)
        {
            IEnumerable<BankAccountModel> bankAccounts = GetAllBankAccountsByUserId(userId).ToList();

            foreach (BankAccountModel bankAccount in bankAccounts)
            {
                bankAccount.LoanAmount = loanModel.LoanAmount;
                bankAccount.LoanPeriod = loanModel.LoanPeriod;
            }

            await _context.SaveChangesAsync();
            return bankAccounts;
        }

        public async Task<BankAccountModel> DeleteBankAccount(int id)
        {
            BankAccountModel bankAccountModel = await _context.BankAccounts.FindAsync(id);

            _context.BankAccounts.Remove(bankAccountModel);
            await _context.SaveChangesAsync();

            return bankAccountModel;
        }
    }
}
