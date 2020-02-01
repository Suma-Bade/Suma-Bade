using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace EmartMVC.Models
{
    public class Seller
    {
        [Key]
        [Required]
        public int SId { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "length can be max 10")]
        public string Username { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z0-9]{7,9}", ErrorMessage = "Invalid password")]
        public string Password { get; set; }
        [Required]
        public string Companyname { get; set; }
        public int GSTIN { get; set; }
        public string AboutCompany { get; set; }
        [Required]
        public string Address { get; set; }
        public string Website { get; set; }
        [Required]
        [RegularExpression("^([a-zA-Z0-9]+)@([a-zA-Z0-9]+)\\.([a-zA-Z]{2,5})$", ErrorMessage = "Invalid")]
        public string Email { get; set; }
        [RegularExpression(@"[6-9]\d{9}", ErrorMessage = "Invalid format")]
        public long Mobileno { get; set; }
        public string PhotoPath { get; set; }
        public Seller()
        {

        }

    }
}
