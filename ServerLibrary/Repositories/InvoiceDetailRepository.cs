using ServerLibrary.Models;

namespace ServerLibrary.Repositories
{
    public class InvoiceDetailRepository : AbstractRepository<InvoiceDetail, int>
    {
        public InvoiceDetailRepository(ManagementdbContext context) : base(context)
        {
        }
    }
}
