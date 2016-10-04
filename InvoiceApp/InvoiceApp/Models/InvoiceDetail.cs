using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailID { get; set; }
        public InvoiceMaster InvoiceMaster { get; set; }

        [Required]
        public int InvoiceMasterID { get; set; }

        public Item Item { get; set; }
        [Required]
        public int ItemID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Rate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Qty { get; set; }

    }
}