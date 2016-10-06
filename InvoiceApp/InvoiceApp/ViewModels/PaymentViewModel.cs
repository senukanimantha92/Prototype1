using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvoiceApp.Models;

namespace InvoiceApp.ViewModels
{
    public class PaymentViewModel
    {
        public Payment Payment { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public List<String> PaymentMethods { get; set; }
    }
}