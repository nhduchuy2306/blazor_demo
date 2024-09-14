using ServerLibrary.Dtos;

namespace ServerLibrary.Services;

public interface ISalesInvoiceService
{
    SalesInvoiceDTO GetById(int salesInvoiceId);
    IEnumerable<SalesInvoiceDTO> GetAll();
    void Delete(int salesInvoiceId);
    void Update(int salesInvoiceId, SalesInvoiceInputDTO salesInvoiceInputDTO);
    void Create(SalesInvoiceInputDTO salesInvoiceInputDTO);
    IEnumerable<InvoiceDetailDTO> GetInvoiceDetailsByInvoiceId(int invoiceId);
    IEnumerable<SalesInvoiceDTO> GetSalesByCustomerId(int customerId);
    IEnumerable<SalesPerMonthDto> GetSalesPerMonths();
    IEnumerable<SalesInvoiceDTO> GetSalesInvoicesData(DateOnly fromDate, DateOnly toDate);
    byte[] GenerateExcelReport(IEnumerable<SalesInvoiceDTO> salesInvoices);
}