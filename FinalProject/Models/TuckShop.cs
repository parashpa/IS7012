using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class TuckShop
    {
        public int ID { get; set; }
        [Display(Name = "Apparel ID")]
        public int ApparelID { get; set; }
        [Display(Name = "Apparel Name")]
        public string ApparelName { get; set; }

        [CustomValidation(typeof(TuckShop), "CheckPrice")]
        public decimal Price { get; set; }
        public int MembershipID { get; set; }
        public Membership Membership { get; set; }

        public static ValidationResult CheckPrice(decimal Price, ValidationContext context)
        {
            if (Price < 1000)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Please enter price less than 1000 ");
        }

    }
}
