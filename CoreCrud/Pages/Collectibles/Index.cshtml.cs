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
    public class IndexModel : PageModel
    {
        private readonly CoreCrud.Models.CoreCrudContext _context;

        public IndexModel(CoreCrud.Models.CoreCrudContext context)
        {
            _context = context;
        }

        public IList<Collectible> Collectible { get;set; }

        public async Task OnGetAsync()
        {
            Collectible = await _context.Collectible
                .Include(c => c.Manufacturer).ToListAsync();
        }
    }
}
