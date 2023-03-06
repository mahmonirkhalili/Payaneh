using Domain;
using IApplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext()
          
        {

            
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDet> InvoiceDet { get; set; }
        public virtual DbSet<InvoicePay> InvoicePay { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasKey(c => c.Id);

            modelBuilder.Entity<Invoice>().HasKey(c=> c.Id);
            modelBuilder.Entity<InvoiceDet>().HasKey(c => c.Id);
            modelBuilder.Entity<InvoicePay>().HasKey(c => c.Id);
            base.OnModelCreating(modelBuilder);
          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = @"data source=10.44.5.83;initial catalog=Payane;user id=Payanelog;password=123456;multipleactiveresultsets=True;application name=Payaneh;Encrypt=False";

            optionsBuilder.UseSqlServer(ConnectionString);

        }
    }
}
