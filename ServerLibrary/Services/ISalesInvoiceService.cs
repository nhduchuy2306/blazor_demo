using ServerLibrary.Dtos;

public interface ISalesInvoiceService
{
    SalesInvoiceDTO GetById(int salesInvoiceId);
    IEnumerable<SalesInvoiceDTO> GetAll();
    void Delete(int salesInvoiceId);
    void Update(int salesInvoiceId, SalesInvoiceInputDTO salesInvoiceInputDTO);
    void Create(SalesInvoiceInputDTO salesInvoiceInputDTO);
}