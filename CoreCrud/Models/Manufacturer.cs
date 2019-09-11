using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Manufacturer
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public string Location { get; set; }
        public ICollection<Collectible> Collectibles { get; set; }
    }
}
