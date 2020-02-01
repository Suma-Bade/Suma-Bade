using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmartMVC.Models
{
    public class Category
    {
        [Key]
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }
        public string Details { get; set; }
    }
}
