using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TropicalServerApp.Models
{
    public class Email
    {
        [Required]
        [RegularExpression(@"^[0-9]+@[a-zA-Z]+\.[a-zA-Z]+$")]
        public string CustomerEmail { get; set; }
    }
}