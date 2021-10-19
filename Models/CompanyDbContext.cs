using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.ent

namespace CompanyWebSiteCore.Models
{
    public class CompanyDbContext:DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options):base(options)
        {

        }
        public DbSet<CompanyData> CompanyDatas { get; set; }
        public DbSet<ServicesData> ServicesDatas { get; set; }
        public DbSet<ProductsData> ProductsDatas { get; set; }
        public DbSet<CustomersData> CustomersDatas { get; set; }
    }
}
