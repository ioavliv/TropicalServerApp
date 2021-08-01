using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TropicalServerApp.Models
{
    public class Customer
    {
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public string CustomerPassword { get; set; }
        
    }
}