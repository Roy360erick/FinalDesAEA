using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Infraestructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name= MyContextDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesInvoce> SalesInvoces { get; set; }
        public DbSet<SalesInvoceDetail> SalesInvoceDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
