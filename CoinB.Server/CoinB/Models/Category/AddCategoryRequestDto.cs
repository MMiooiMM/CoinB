using System.ComponentModel.DataAnnotations;

namespace CoinB.Models.Category
{
    public class AddCategoryRequestDto
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
