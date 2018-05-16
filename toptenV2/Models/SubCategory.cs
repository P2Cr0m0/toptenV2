using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace toptenV2.Models
{
    public class SubCategory
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
    }
}
