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
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        public string Genre { get; set; }
        public bool Forsale { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public int ManufacturerID { get; set; }

        public Manufacturer Manufacturer { get; set; }

        // READONLY PROPERTIES
        [NotMapped]
        public bool IsDateAvailable
        {
            // TRUE/FALSE: TRUE IF DATE IS AVAILABLE
            get { return ReleaseDate != null; }
        }
    }
}
