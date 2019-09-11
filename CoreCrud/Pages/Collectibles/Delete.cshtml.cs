using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Pages.Collectibles
{
    public class DeleteModel : PageModel
    {
        private readonly CoreCrud.Models.CoreCrudContext _context;

        public DeleteModel(CoreCrud.Models.CoreCrudContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Collectible Collectible { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Collectible = await _context.Collectible
                .Include(c => c.Manufacturer).FirstOrDefaultAsync(m => m.ID == id);

            if (Collectible == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Collectible = await _context.Collectible.FindAsync(id);

            if (Collectible != null)
            {
                _context.Collectible.Remove(Collectible);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
