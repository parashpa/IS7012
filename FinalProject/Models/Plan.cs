using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Plan
    {
        public int ID { get; set; }

        [Display(Name = "Plan Name")]
        public string PlanName { get; set; }
        public string Day { get; set; }

        [Display(Name = "Duration in months")]
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public int TrainerID { get; set; }
        public Trainer Trainer { get; set; }

        public ICollection<Membership> Memberships { get; set; }




    }
}
