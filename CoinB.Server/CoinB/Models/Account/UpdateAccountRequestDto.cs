using System.ComponentModel.DataAnnotations;

namespace CoinB.Models.Account
{
    public class UpdateAccountRequestDto
    {
        [Required]
        public string AccountName { get; set; }
    }
}