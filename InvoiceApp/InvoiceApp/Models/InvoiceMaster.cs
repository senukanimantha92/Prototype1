using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace InvoiceApp.Models
{
    public class InvoiceMaster
    {
        public int InvoiceMasterID { get; set; }

        [Required]
        public string InvoiceNo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Memo { get; set; }
        public Customer Customer { get; set; }
        public double Total { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetail { get; set; }
    }
}