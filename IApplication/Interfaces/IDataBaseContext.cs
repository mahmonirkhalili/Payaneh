using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IApplication.Interfaces
{
    public interface IDataBaseContext
    {
        DbSet<Invoice> Invoice { get; set; }
        DbSet<InvoiceDet> InvoiceDet { get; set; }
        DbSet<InvoicePay> InvoicePay { get; set; }
        DbSet<Users> Users { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
