using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TropicalServerApp.Models;

namespace TropicalServerApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Load()
        {
            // This will come from database
            Customer obj =
                new Customer
                {
                    CustomerId = "1",
                    CustomerPassword = "Ioav"
                };
            return View("Customer",obj);
        }
    }
}