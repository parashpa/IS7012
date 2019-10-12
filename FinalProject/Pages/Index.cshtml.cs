using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Models.FinalProjectContext _context;

        public IndexModel(FinalProject.Models.FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IndexForm IndexForm { get; set; }

        public Membership Membership { get; set; }

        public async Task<IActionResult> OnGet()
        {

            await PopulateSelectListsAsync();
                     

            if (Membership == null)
            {
                return NotFound();
            }

            IndexForm = new IndexForm();
            IndexForm.MemberId = Membership.ID;
            
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            Membership = _context.Membership.Find(IndexForm.MemberId);
            if (!ModelState.IsValid)
            {
                await PopulateSelectListsAsync();
                return Page();
            }
            
            return RedirectToPage("/ChangePlan", new { id = Membership.ID });
        }

        private async Task PopulateSelectListsAsync()
        {
            Membership = await _context.Membership
                .Include(m => m.Plan).FirstOrDefaultAsync();
            ViewData["MemberId"] = new SelectList(_context.Membership, "ID", "ID");
        }



        }
}
