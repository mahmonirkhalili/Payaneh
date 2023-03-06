using Domain;
using IApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IApplication.Services
{
    public class InvoiceService:IInvoice
    {
        private readonly IDataBaseContext _context;
        public InvoiceService(IDataBaseContext context)
        {
            _context = context;
        }

        public int InsertInvoice(List<Invoice> invoice, List<InvoiceDet> invoiceDet, List<InvoicePay> invoicePay)
        {

            _context.Invoice.AddRange(invoice);
            _context.SaveChanges();


            _context.InvoiceDet.AddRange(invoiceDet);
            _context.InvoicePay.AddRange(invoicePay);

            return _context.SaveChanges();

        }




    }
}
