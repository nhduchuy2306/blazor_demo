using ServerLibrary.Models;

namespace ServerLibrary.Repositories;

public class InvoiceDetailRepository : Repository<InvoiceDetail, int>
{
    public InvoiceDetailRepository(ManagementdbContext context) : base(context)
    {
    }

    public IEnumerable<InvoiceDetail> GetInvoiceDetailsByProductId(int productId)
    {
        return _context.InvoiceDetails.Where(i => i.ProductId == productId).ToList();
    }
}
