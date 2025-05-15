using ExpenseTrackerWeb.Data;
using ExpenseTrackerWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerWeb.Pages.Transactions
{
    public class IndexModel : PageModel
    {

        public float TotalIncome { get; set; }
        public float TotalExpense { get; set; }
        public float Balance => TotalIncome - TotalExpense;

        [BindProperty(SupportsGet = true)]
        public string? FilterCategory { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? EndDate { get; set; }

        public List<SelectListItem> CategoryOptions { get; set; } = new();


        private readonly ExpenseTrackerWeb.Data.AppDbContext _context;

        public IndexModel(ExpenseTrackerWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Transaction> Transaction { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var query = _context.Transactions.AsQueryable();

            // Apply category filter
            if (!string.IsNullOrEmpty(FilterCategory))
            {
                query = query.Where(t => t.Category == FilterCategory);
            }

            // Apply date range filter
            if (StartDate.HasValue)
            {
                query = query.Where(t => t.Date >= StartDate.Value);
            }
            if (EndDate.HasValue)
            {
                query = query.Where(t => t.Date <= EndDate.Value);
            }

            Transaction = await query.ToListAsync();

            // Populate filter dropdown
            CategoryOptions = new List<SelectListItem>
{
            new("All", "") { Selected = string.IsNullOrEmpty(FilterCategory) },
            new("Food", "Food"),
            new("Rent", "Rent"),
            new("Salary", "Salary"),
            new("Entertainment", "Entertainment"),
            new("Utilities", "Utilities"),
            new("Other", "Other"),
        };


            TotalIncome = Transaction
                .Where(t => t.Type == "Income")
                .Sum(t => t.Amount);

            TotalExpense = Transaction
                .Where(t => t.Type == "Expense")
                .Sum(t => t.Amount);

        }
    }
}
