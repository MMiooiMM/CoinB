using System.ComponentModel.DataAnnotations;

namespace CoinB.Models.Transaction
{
    public class GetTransactionRequestDto
    {
        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }
    }
}
