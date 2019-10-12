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
    public class TrainerProfileModel : PageModel
    {
        private FinalProject.Models.FinalProjectContext _context;
        public TrainerProfileModel(FinalProject.Models.FinalProjectContext context)
        {
            _context = context;
        }

        public Trainer Trainer { get; set; }

        public ICollection<Plan> Plans { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trainer = _context.Trainer
                        .Include(est => est.Plans)
                        .FirstOrDefault(clt => clt.ID == id);


            if (Trainer == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}