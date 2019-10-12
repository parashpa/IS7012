using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Membership

    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please provide first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please provide last name")]
        public string LastName { get; set; }

        [Display(Name = "Member From")]

        [DataType(DataType.Date)]

        [CustomValidation(typeof(Membership), "MembershipDateInThePast")]
        public DateTime MemberFrom { get; set; }

        [Display(Name = "Active Member")]
        public bool ActiveMember{ get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public interface IWeight : IUnit { }
        public class Pounds : IWeight { }

        [Display(Name = "Plan Start Date")]

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public int PlanID { get; set; }
        // READONLY PROPERTIES
        [NotMapped]
        public string MemberisAnAdult
        {
            get
            {
                if (Age>18)

                { return "Adult"; }
                return "Minor";

            }
        }

        [NotMapped]
        public string IfNotActive
        {
            get
            {
                if (!ActiveMember)

                { return "Active Member";}
                return "Inactive Member";
                

            }
        }
        public Plan Plan { get; set; }
        public ICollection<TuckShop> TuckShops { get; set; }

        public static ValidationResult MembershipDateInThePast(DateTime? MemberFrom, ValidationContext context)
        {
            if (MemberFrom >= DateTime.Today)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Membership Date should not be in the past");
        }

    }
}
