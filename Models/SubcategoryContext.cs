using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EmartMVC.Models
{
    public class SubcategoryContext : DbContext
    {
        public SubcategoryContext(DbContextOptions<SubcategoryContext> options) : base(options)
        {

        }
        public DbSet<SubCategory> subcategories { get; set; }
    }
}
