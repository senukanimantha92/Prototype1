using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvoiceApp.Models;

namespace InvoiceApp.ViewModels
{
    public class ItemFormViewModel
    {
        public Item Item { get; set; }
        public IEnumerable< Account> Accounts { get; set; }
    }
}