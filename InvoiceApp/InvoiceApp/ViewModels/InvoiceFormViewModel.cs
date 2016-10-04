using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvoiceApp.Models;

namespace InvoiceApp.ViewModels
{
    public class InvoiceFormViewModel
    {
        public InvoiceMaster InvoiceMaster { get; set; }
        public IEnumerable<InvoiceDetail> InvoiceDetails { get; set; }
    }
}