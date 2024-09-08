using ServerLibrary.Models;

namespace ServerLibrary.Repositories
{
    public class SalesInvoiceRepository : AbstractRepository<SalesInvoice, int>
    {
        public SalesInvoiceRepository(ManagementdbContext context) : base(context)
        {
        }
    }
}
