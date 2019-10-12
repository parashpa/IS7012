using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages.Plans
{
    public class EditModel : PageModel
    {
        private readonly FinalProject.Models.FinalProjectContext _context;

        public EditModel(FinalProject.Models.FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Plan Plan { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plan = await _context.Plan
                .Include(p => p.Trainer).FirstOrDefaultAsync(m => m.ID == id);

            if (Plan == null)
            {
                return NotFound();
            }
           ViewData["TrainerID"] = new SelectList(_context.Trainer, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["TrainerID"] = new SelectList(_context.Trainer, "ID", "ID");
                return Page();
            }

            _context.Attach(Plan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanExists(Plan.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlanExists(int id)
        {
            return _context.Plan.Any(e => e.ID == id);
        }
    }
}
