using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject.Models;

namespace FinalProject.Pages.Plans
{
    public class CreateModel : PageModel
    {
        private readonly FinalProject.Models.FinalProjectContext _context;

        public CreateModel(FinalProject.Models.FinalProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TrainerID"] = new SelectList(_context.Trainer, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Plan Plan { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["TrainerID"] = new SelectList(_context.Trainer, "ID", "ID");
                return Page();
            }

            _context.Plan.Add(Plan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}