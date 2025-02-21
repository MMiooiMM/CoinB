using System.ComponentModel.DataAnnotations;

namespace CoinB.Models.Account
{
    public class AddAccountRequestDto
    {

        [Required]
        public string AccountName { get; set; }
    }
}