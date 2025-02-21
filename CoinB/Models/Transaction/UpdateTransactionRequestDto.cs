﻿using System.ComponentModel.DataAnnotations;

namespace CoinB.Models.Transaction
{
    public class UpdateTransactionRequestDto
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}