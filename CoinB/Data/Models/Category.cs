using System.ComponentModel.DataAnnotations;

namespace CoinB.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
