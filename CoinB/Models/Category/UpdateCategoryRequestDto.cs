using System.ComponentModel.DataAnnotations;

namespace CoinB.Models.Category
{
    public class UpdateCategoryRequestDto
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
