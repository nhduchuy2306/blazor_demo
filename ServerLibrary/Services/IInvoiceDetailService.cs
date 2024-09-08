using ServerLibrary.Dtos;

public interface IInvoiceDetailService
{
    InvoiceDetailDTO GetById(int invoiceDetailId);
    IEnumerable<InvoiceDetailDTO> GetAll();
    void Delete(int invoiceDetailId);
    void Update(int invoiceDetailId, InvoiceDetailInputDTO invoiceDetailInputDTO);
    void Create(InvoiceDetailInputDTO invoiceDetailInputDTO);
}