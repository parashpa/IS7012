using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Pages
{
    public class ManufacturerProfileModel : PageModel
    {

        private CoreCrud.Models.CoreCrudContext _context;
        public ManufacturerProfileModel(CoreCrud.Models.CoreCrudContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }

        public ICollection<Collectible> Collectibles { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = _context.Manufacturer
                        .Include(est => est.Collectibles)
                        .FirstOrDefault(clt => clt.ID == id);


            if (Manufacturer == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}