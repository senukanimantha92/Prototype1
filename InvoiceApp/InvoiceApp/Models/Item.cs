using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Models
{
    public class Item
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name="Item Type")]
        public string Type { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Cost { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Sales Price")]
        public double SalesPrice { get; set; }

        public Account Account { get; set; }

        [Required]
        [Display(Name="Account")]
        public int AccountID { get; set; } 
    }
}