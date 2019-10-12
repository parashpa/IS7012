using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ChangePlanForm
    {
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Please select a PlanID")]
        public int PlanID { get; set; }

    }
}
