using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmartMVC.Models
{
    public class SubCategory
    {
        [Key]
        public int SubId { get; set; }
        public string SubName { get; set; }
        public string SubDetails { get; set; }
        public int SubGst { get; set; }
        public SubCategory()
        {

        }
    }

}
