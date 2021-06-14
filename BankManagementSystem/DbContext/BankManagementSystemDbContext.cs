using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    public class BankManagementSystemDbContext : DbContext
    {
        public BankManagementSystemDbContext(DbContextOptions
            <BankManagementSystemDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<BankAccountModel> BankAccounts { get; set; }
    }
}
