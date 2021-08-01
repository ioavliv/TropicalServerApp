using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TropicalServerApp.Models
{
    public class Order
    {
        public string OrderId { get; internal set; }
        public string TrackingNum { get; set; }
        public string OrderDate { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string RouteNum { get; set; }
    }
}