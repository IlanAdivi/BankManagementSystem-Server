using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string IdNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime LastLoginDate { get; set; }

        public List<BankAccountModel> BankAccounts { get; set; }
    }
}
