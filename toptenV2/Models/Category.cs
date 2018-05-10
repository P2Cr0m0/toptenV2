using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace toptenV2.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
