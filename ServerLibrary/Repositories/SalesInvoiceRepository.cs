using Microsoft.EntityFrameworkCore;
using ServerLibrary.Dtos;
using ServerLibrary.Models;

namespace ServerLibrary.Repositories;

public class SalesInvoiceRepository : Repository<SalesInvoice, int>
{
    public SalesInvoiceRepository(ManagementdbContext context) : base(context)
    {
    }

    public IEnumerable<InvoiceDetail> GetInvoiceDetailsByInvoiceId(int invoiceId)
    {
        return _context.InvoiceDetails
            .Include(i => i.WarehouseProduct.Product)
            .Include(i => i.WarehouseProduct.Warehouse)
            .Where(i => i.InvoiceId == invoiceId);
    }

    public new SalesInvoice? GetById(int id)
    {
        return _context.Set<SalesInvoice>()
            .Include(s => s.Customer)
            .SingleOrDefault(s => s.InvoiceId == id);
    }

    public IEnumerable<SalesInvoice> GetSalesByCustomerId(int customerId)
    {
        return _context.SalesInvoices
            .Include(s => s.Customer)
            .Where(s => s.CustomerId == customerId);
    }

    public IEnumerable<SalesPerMonthDto> GetSalesPerMonths()
    {
        return _context.SalesInvoices
            .GroupBy(s => new { s.InvoiceDate.Year, s.InvoiceDate.Month })
            .Select(s => new SalesPerMonthDto
            {
                Year = s.Key.Year,
                Month = s.Key.Month,
                TotalSales = s.Sum(s => s.TotalAmount ?? 0)
            })
            .OrderBy(s => s.Year).ThenBy(s => s.Month)
            .ToList();
    }

    public IEnumerable<SalesInvoice> GetSalesInvoicesData(DateOnly fromDate, DateOnly toDate)
    {
        return _context.SalesInvoices
            .Include(s => s.Customer)
            .Where(s => s.InvoiceDate >= fromDate && s.InvoiceDate <= toDate)
            .ToList();
    }

    public new SalesInvoice Create(SalesInvoice salesInvoice)
    {
        _context.Add(salesInvoice);
        _context.SaveChanges();
        return salesInvoice;
    }
}

