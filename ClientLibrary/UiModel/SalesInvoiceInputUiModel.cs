using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.UiModel;

public class SalesInvoiceInputUiModel
{
    [Required(ErrorMessage = "Customer is required.")]
    public int CustomerId { get; set; }

    public decimal? TotalAmount { get; set; }

    public List<InvoiceDetailUiModel> InvoiceDetails { get; set; } = new List<InvoiceDetailUiModel>();

}
