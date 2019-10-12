using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Pages
{
    public class ChangePlanModel : PageModel
    {
        private FinalProject.Models.FinalProjectContext _context;
        public ChangePlanModel(FinalProject.Models.FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChangePlanForm ChangePlanForm { get; set; }

        public Membership Membership { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Membership = await _context.Membership
                .Include(m => m.Plan).FirstOrDefaultAsync(m => m.ID == id);
            Membership = _context.Membership.Find(id);

            if (Membership == null)
            {
                return NotFound();
            }


            ChangePlanForm = new ChangePlanForm();
            ChangePlanForm.MemberId = Membership.ID;
            ChangePlanForm.PlanID = Membership.PlanID;
            ViewData["PlanID"] = new SelectList(_context.Plan, "ID", "ID");
            return Page();
        }
        public IActionResult OnPost()
        {
            Membership = _context.Membership.Find(ChangePlanForm.MemberId);
            

            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Membership).State = EntityState.Modified;
            // UPDATE THE MEMBER RETRIEVED FROM THE DATABASE
            Membership.PlanID = ChangePlanForm.PlanID;
            // TELL THE DATABASE TO SAVE WHATEVER CHANGES WE MADE
            _context.SaveChanges();
            return RedirectToPage("/Memberships/details", new { id = Membership.PlanID });
        }
    }
}