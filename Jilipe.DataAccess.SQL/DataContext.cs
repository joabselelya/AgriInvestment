using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jilipe.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("JilipeEntities")
        {

        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvestmentCycle> InvestmentCycles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
