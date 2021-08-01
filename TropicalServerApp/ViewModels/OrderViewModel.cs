using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TropicalServerApp.Models;

namespace TropicalServerApp.ViewModels
{
    public class OrderViewModel
    {
        public Order order { get; set; }
        public List<Order> orders { get; set; }
    }
}