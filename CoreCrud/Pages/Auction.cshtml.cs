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
    public class AuctionModel : PageModel
    {
        private CoreCrud.Models.CoreCrudContext _context;
        public AuctionModel(CoreCrud.Models.CoreCrudContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }

        public ICollection<Collectible> Collectibles { get; set; }

        public void OnGet()
        {
            Collectibles = _context.Collectible
                            .Include(est => est.Manufacturer)
                            .OrderBy(clt => clt.Title)
                            .ToList();


        }
    }
}