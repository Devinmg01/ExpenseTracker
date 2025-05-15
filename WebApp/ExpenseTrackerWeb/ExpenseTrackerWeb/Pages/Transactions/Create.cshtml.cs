using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpenseTrackerWeb.Data;
using ExpenseTrackerWeb.Models;

namespace ExpenseTrackerWeb.Pages.Transactions
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Transaction Transaction { get; set; } = default!;

        public List<SelectListItem> CategoryOptions { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> TypeOptions { get; set; } = new List<SelectListItem>();

        public IActionResult OnGet()
        {
            PopulateDropdowns();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdowns(); // Refill dropdowns after postback error
                return Page();
            }

            _context.Transactions.Add(Transaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private void PopulateDropdowns()
        {
            CategoryOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Food", Text = "Food" },
                new SelectListItem { Value = "Rent", Text = "Rent" },
                new SelectListItem { Value = "Salary", Text = "Salary" },
                new SelectListItem { Value = "Entertainment", Text = "Entertainment" },
                new SelectListItem { Value = "Utilities", Text = "Utilities" },
                new SelectListItem { Value = "Other", Text = "Other" },
            };

            TypeOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Income", Text = "Income" },
                new SelectListItem { Value = "Expense", Text = "Expense" },
            };
        }
    }
}
