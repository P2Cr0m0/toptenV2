using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace toptenV2.Models
{
    public class Listing
    {
        public int ID { get; set; }
        public int SubCategoryID { get; set; }
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Creator { get; set; }
        public virtual SubCategory SubCategory { get; set; }

    }
}
