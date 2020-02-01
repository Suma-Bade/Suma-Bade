using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmartMVC.Models
{
    public class Item
    {
        [Key]
        [Required]
        public int ItemId { get; set; }
        [Required]
        public float Price { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int StockNumber { get; set; }
        public string Remarks { get; set; }


    }
}
