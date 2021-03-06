using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountManagement.Interfaces
{
    public interface IBankAccountDal
    {
        IEnumerable<BankAccountModel> GetAllBankAccountsByUserId(int userId);
        Task<BankAccountModel> CreateBankAccount(BankAccountModel bankAccountModel, int userId);
        Task<BankAccountModel> DeleteBankAccount(int id);
        Task<IEnumerable<BankAccountModel>> LoanBankAccount(LoanModel loanModel, int userId);
    }
}
