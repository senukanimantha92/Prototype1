using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace InvoiceApp.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Address { get; set; }

        [EmailAddress(ErrorMessage="Invalid Email Address")]
        public string Email { get; set; }

    }
}