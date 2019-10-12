using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Pages
{
    public class MembershipProfileModel : PageModel
    {
        private FinalProject.Models.FinalProjectContext _context;
        public MembershipProfileModel(FinalProject.Models.FinalProjectContext context)
        {
            _context = context;
        }

        public Membership Membership { get; set; }

        public ICollection<TuckShop> Tuckshops { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Membership = _context.Membership
                        .Include(est => est.TuckShops)
                        .FirstOrDefault(clt => clt.ID == id);


            if (Membership == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}