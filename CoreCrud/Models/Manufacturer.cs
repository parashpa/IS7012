using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Manufacturer
    {
        public int ID { get; set; }

        [Display(Name = "Publisher Name")]
        public string PublisherName { get; set; }
        public string Location { get; set; }

        [Required(ErrorMessage = "Please provide a 5 digit zipcode")]
        [RegularExpression(@"^[\d]{5}$")]
        [Display(Name = "Zip code")]
        public int Zipcode { get; set; }
        public ICollection<Collectible> Collectibles { get; set; }
    }
}
