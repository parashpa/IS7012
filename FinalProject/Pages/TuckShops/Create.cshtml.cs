using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject.Models;

namespace FinalProject.Pages.TuckShops
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
        ViewData["MembershipID"] = new SelectList(_context.Membership, "ID", "FirstName");
            return Page();
        }

        [BindProperty]
        public TuckShop TuckShop { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["MembershipID"] = new SelectList(_context.Membership, "ID", "FirstName");
                return Page();
            }

            _context.TuckShop.Add(TuckShop);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}