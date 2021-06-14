using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class UpdateUserModel
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
