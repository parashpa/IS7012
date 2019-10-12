using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject.Models;

namespace FinalProject.Pages.Memberships
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
        ViewData["PlanID"] = new SelectList(_context.Plan, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Membership Membership { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["PlanID"] = new SelectList(_context.Plan, "ID", "ID");
                return Page();
            }

            _context.Membership.Add(Membership);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}