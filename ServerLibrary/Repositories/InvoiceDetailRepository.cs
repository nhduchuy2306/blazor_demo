using ServerLibrary.Models;

namespace ServerLibrary.Repositories
{
    public class InvoiceDetailRepository : Repository<InvoiceDetail, int>
    {
        public InvoiceDetailRepository(ManagementdbContext context) : base(context)
        {
        }
    }
}
