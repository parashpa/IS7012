using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Pages
{
    public class SearchModel : PageModel
    {

        private FinalProject.Models.FinalProjectContext _context;
        public SearchModel(FinalProject.Models.FinalProjectContext context)
        {
            _context = context;
        }



        public void OnGet()
        {
            SearchCompleted = false;
        }

        // THE 'BindProperty' Search will receive the value from the form
        // Note: The name attribute of the input in the HTML matches this name
        [BindProperty]

        public string Search { get; set; }

        // WE WILL USE THIS PROPERTY TO TRACK IF A SEARCH HAS BEEN PERFORMED
        public bool SearchCompleted { get; set; }

        // WE WILL STORE THE RESULTS IN THIS PROPERTY

        public ICollection<TuckShop> TuckShops { get; set; }
        public Membership SearchResults { get; set; }

        public void OnPost()
        {
            // PERFORM SEARCH
            if (string.IsNullOrWhiteSpace(Search))
            {
                // EXIT EARLY IF THERE IS NO SEARCH TERM PROVIDED
                return;
            }
            TuckShops = _context.TuckShop
                                    .Include(x => x.Membership)
                                    .Where(x => x.ApparelName.ToLower().Contains(Search.ToLower()))
                                    .ToList();
            SearchCompleted = true;
        }
    }
}