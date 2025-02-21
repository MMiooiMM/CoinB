using System.ComponentModel.DataAnnotations;

namespace CoinB.Models.Category
{
    public class UpdateCategoryRequestDto
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
