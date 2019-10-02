using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreCrud.Models;

namespace CoreCrud.Pages.Collectibles
{
    public class CreateModel : PageModel
    {
        private readonly CoreCrud.Models.CoreCrudContext _context;

        public CreateModel(CoreCrud.Models.CoreCrudContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ManufacturerID"] = new SelectList(_context.Set<Manufacturer>(), "ID", "PublisherName");
            return Page();
        }

        [BindProperty]
        public Collectible Collectible { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ManufacturerID"] = new SelectList(_context.Set<Manufacturer>(), "ID", "PublisherName");
                return Page();
            }

            _context.Collectible.Add(Collectible);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
