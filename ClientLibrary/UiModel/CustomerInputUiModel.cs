using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.UiModel
{
    public class CustomerInputUiModel
    {
        [Required(ErrorMessage = "Customer code is required.")]
        [StringLength(10, ErrorMessage = "Customer code cannot exceed 10 characters.")]
        public string CustomerCode { get; set; } = null!;

        [Required(ErrorMessage = "Customer name is required.")]
        public string CustomerName { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Contact info cannot exceed 100 characters.")]
        public string? ContactInfo { get; set; }

        public string? Address { get; set; }
    }
}
