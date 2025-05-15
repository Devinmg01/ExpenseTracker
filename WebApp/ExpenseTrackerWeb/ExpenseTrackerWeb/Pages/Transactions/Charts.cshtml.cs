using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerWeb.Data;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseTrackerWeb.Pages.Transactions
{
    public class ChartsModel : PageModel
    {
        private readonly AppDbContext _context;

        public ChartsModel(AppDbContext context)
        {
            _context = context;
        }

        public List<string> CategoryLabels { get; set; } = new();
        public List<float> CategoryValues { get; set; } = new();

        public class CategoryStat
        {
            public string Category { get; set; } = "";
            public float Amount { get; set; }
            public float Percentage { get; set; }
        }

        public List<CategoryStat> Stats { get; set; } = new();


        public void OnGet()
        {
            var expenseGroups = _context.Transactions
                .Where(t => t.Type == "Expense")
                .GroupBy(t => t.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(t => t.Amount)
                })
                .ToList();

            float grandTotal = expenseGroups.Sum(g => g.Total);

            Stats = expenseGroups.Select(g => new CategoryStat
            {
                Category = g.Category,
                Amount = g.Total,
                Percentage = grandTotal > 0 ? (g.Total / grandTotal * 100) : 0
            }).ToList();

            CategoryLabels = Stats.Select(s => s.Category).ToList();
            CategoryValues = Stats.Select(s => s.Amount).ToList();
        }

    }
}
