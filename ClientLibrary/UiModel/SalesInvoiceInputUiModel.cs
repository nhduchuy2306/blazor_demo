using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.UiModel
{
    public class SalesInvoiceInputUiModel
    {
        [Required(ErrorMessage = "Customer is required.")]
        public int CustomerId { get; set; }

        public decimal? TotalAmount { get; set; }

        public List<InvoiceDetailUiModel> InvoiceDetails { get; set; } = new List<InvoiceDetailUiModel>();

    }
}
