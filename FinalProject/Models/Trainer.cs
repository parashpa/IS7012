using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Trainer
    {
        public int ID { get; set; }
        [Display(Name = "Trainer Name")]
        public string TrainerName { get; set; }

        [Display(Name = "Years of Experience")]
        [CustomValidation(typeof(Trainer), "MinimumExperience")]
        public int YearsofExp { get; set; }

        // READONLY PROPERTIES
        [NotMapped]
        public string IsTrainerExperienced
        {
            get
            {
                if (YearsofExp > 4)

                { return "Experienced"; }
                return "Fresher";

            }
        }


        public static ValidationResult MinimumExperience(int YearsofExp, ValidationContext context)
        {
            if (YearsofExp > 2)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Trainer experience should be more than 2 years ");
        }
        public ICollection<Plan> Plans { get; set; }

    }
}
