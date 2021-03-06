﻿using AgriInvestment.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jilipe.DataAccess.SQLRepository
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("JilipeDBConnection")
        {

        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvestmentCycle> InvestmentCycles { get; set; }
    }
}
