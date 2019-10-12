using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace FinalProject.Pages
{
    public class DashboardModel : PageModel
    {
        private FinalProjectContext _context;
        public int NumberofmembersassignedtoGarima;
        public int NumberofmembersassignedtoKomal;
        public int NumberofmembersassignedtoPrerna;
        public int NumberofmembersassignedtoAbhishek;
        public int NumberofmembersassignedtoAnubhav;

        public DashboardModel(FinalProjectContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            NumberofmembersassignedtoGarima = _context.Membership
                .Where(x => x.Plan.Trainer.TrainerName == "Garima")
                .Count();
            NumberofmembersassignedtoKomal = _context.Membership
                .Where(x => x.Plan.Trainer.TrainerName == "Komal")
                .Count();
            NumberofmembersassignedtoPrerna = _context.Membership
                .Where(x => x.Plan.Trainer.TrainerName == "Prerna")
                .Count();
            NumberofmembersassignedtoAbhishek = _context.Membership
                .Where(x => x.Plan.Trainer.TrainerName == "Abhishek")
                .Count();
            NumberofmembersassignedtoAnubhav = _context.Membership
                .Where(x => x.Plan.Trainer.TrainerName == "Anubhav")
                .Count();

        }
    }



}
    
