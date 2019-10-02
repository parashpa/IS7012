using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Collectible
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        public string Title { get; set; }


        [CustomValidation(typeof(Collectible), "ReleaseDateInThePast")]
        [Display(Name = "Release Date")]

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [CustomValidation(typeof(Collectible), "ChooseGenre")]
        public string Genre { get; set; }

        [Display(Name = "For Sale")]
        public bool Forsale { get; set; }

        [Range(1, 20)]
        public decimal Price { get; set; }
        public string Author { get; set; }

        [Display(Name = "Manufacturer ID")]
        public int ManufacturerID { get; set; }

        public Manufacturer Manufacturer { get; set; }

        // READONLY PROPERTIES
        [NotMapped]
        public bool IsDateAvailable
        {
            // TRUE/FALSE: TRUE IF DATE IS AVAILABLE
            get { return ReleaseDate != null; }
        }



        public static ValidationResult ReleaseDateInThePast(DateTime? ReleaseDate, ValidationContext context)
        {
            if (ReleaseDate == null)
            {
                return ValidationResult.Success;
            }
            if (ReleaseDate < DateTime.Today)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Release Date must be in the past");
        }


        public static ValidationResult ChooseGenre(string Genre, ValidationContext context)
        {
            if (Genre == null)
            {
                return ValidationResult.Success;
            }

            var names = new List<string> { "Fiction", "Horror", "Romance" };
            if (names.Contains(Genre))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Please enter Genre as Horror/Fiction/Romance");
        }
    }
}
