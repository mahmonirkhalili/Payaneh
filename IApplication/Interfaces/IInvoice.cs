using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IApplication.Interfaces
{
    public interface IInvoice
    {
        int InsertInvoice(List< Invoice> invoice,List< InvoiceDet> invoiceDet,List< InvoicePay> invoicePay);
    }
}
