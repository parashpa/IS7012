using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Pages
{
    public class IndexModel : PageModel
    {
        private CoreCrud.Models.CoreCrudContext _context;
        public IndexModel(CoreCrud.Models.CoreCrudContext context)
        {
            _context = context;
        }
        public int Total_num_of_books_available;
        public int Total_num_of_publishers_available;
        public int Number_of_books_for_sale;
        public int Num_of_publishers_from_US;
        public int Num_of_publishers_from_UK;

        public void OnGet()
        {
            Total_num_of_books_available = _context.Collectible.Count();

            Total_num_of_publishers_available = _context.Manufacturer.Count();

            Number_of_books_for_sale = _context.Collectible
             .Where(x => x.Forsale == true)
             .Count();

            Num_of_publishers_from_US = _context.Manufacturer
                .Where(x => x.Location == "US").Count();

            Num_of_publishers_from_UK = _context.Manufacturer
                            .Where(x => x.Location == "UK").Count();

        }
    }
}
