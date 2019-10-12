using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages.TuckShops
{
    public class EditModel : PageModel
    {
        private readonly FinalProject.Models.FinalProjectContext _context;

        public EditModel(FinalProject.Models.FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TuckShop TuckShop { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TuckShop = await _context.TuckShop
                .Include(t => t.Membership).FirstOrDefaultAsync(m => m.ID == id);

            if (TuckShop == null)
            {
                return NotFound();
            }
           ViewData["MembershipID"] = new SelectList(_context.Membership, "ID", "FirstName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["MembershipID"] = new SelectList(_context.Membership, "ID", "FirstName");
                return Page();
            }

            _context.Attach(TuckShop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TuckShopExists(TuckShop.ID))
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

        private bool TuckShopExists(int id)
        {
            return _context.TuckShop.Any(e => e.ID == id);
        }
    }
}
