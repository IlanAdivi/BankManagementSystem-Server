using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankManagementSystem.Models
{
    public class BankAccountModel
    {
        [Key]
        public int BankAccountId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Branch { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }

        public UserModel User { get; set; }

        public int LoanAmount { get; set; }

        public int LoanPeriod { get; set; }
    }
}
