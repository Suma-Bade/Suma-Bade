using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Configuration;
using EmartMVC.Models;

namespace EmartMVC.Models
{
    public class BuyerContext : DbContext
    {
        public BuyerContext(DbContextOptions<BuyerContext> options) : base(options)
        {

        }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<EmartMVC.Models.Seller> Seller { get; set; }
    }
}
