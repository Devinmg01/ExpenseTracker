using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWeb.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        public string Type { get; set; } 

        [Required]
        public string Category { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string? Notes { get; set; }
    }
}
