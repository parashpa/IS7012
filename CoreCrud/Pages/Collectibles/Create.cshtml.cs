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
        ViewData["ManufacturerID"] = new SelectList(_context.Manufacturer, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Collectible Collectible { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Collectible.Add(Collectible);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}