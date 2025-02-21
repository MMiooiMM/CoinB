using System.ComponentModel.DataAnnotations;

namespace CoinB.Data.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AccountName { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
