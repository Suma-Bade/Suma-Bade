using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace EmartMVC.Models
{
    public class Buyer
    {
        [Key]
        [Required]
        public int BId { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "length can be max 10")]
        public string Username { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z0-9]{7,9}", ErrorMessage = "Invalid password")]
        public string Password { get; set; }
        [Required]
        [RegularExpression("^([a-zA-Z0-9]+)@([a-zA-Z0-9]+)\\.([a-zA-Z]{2,5})$", ErrorMessage = "Invalid")]
        public string Email { get; set; }
        [RegularExpression(@"[6-9]\d{9}", ErrorMessage = "Invalid format")]
        public long Mobileno { get; set; }
        public Buyer()
        {

        }
        

    }
   
}
