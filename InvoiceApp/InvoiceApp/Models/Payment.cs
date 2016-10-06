using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvoiceApp.Models;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }

        [Required(ErrorMessage="Select a customer")]
        public int CustomerID { get; set; }
        public double Balance { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Payment Date")]
        public DateTime PaymentDate { get; set; }

    }
}