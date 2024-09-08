using Microsoft.EntityFrameworkCore;
using ServerLibrary.Models;

namespace ServerLibrary.Repositories
{
    public class SalesInvoiceRepository : Repository<SalesInvoice, int>
    {
        public SalesInvoiceRepository(ManagementdbContext context) : base(context)
        {
        }

        public IEnumerable<InvoiceDetail> GetInvoiceDetailsByInvoiceId(int invoiceId)
        {
            return _context.InvoiceDetails.Where(i => i.InvoiceId == invoiceId);
        }

        public new SalesInvoice? GetById(int id)
        {
            return _context.Set<SalesInvoice>()
                .Include(s => s.Customer)
                .SingleOrDefault(s => s.InvoiceId == id);
        }
    }
}
