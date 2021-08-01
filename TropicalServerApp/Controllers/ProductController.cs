using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TropicalServer.BLL;
using TropicalServerApp.Models;
using TropicalServerApp.ViewModels;

namespace TropicalServerApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product(Customer obj)
        {
            ViewData["Title"] = "Product";
            return View(obj);
        }

        public ActionResult Orders(OrderViewModel vm)
        {
            //OrderViewModel vm = new OrderViewModel();
            
            DataSet ds = new ReportsBLL().GetOrders_BLL();
            DataTable dt = new DataTable();

            dt = ds.Tables[0];

            var listOfOrders = new List<Order>();
            foreach (DataRow tr in dt.Rows)
            {
                //create new instance of order object
                var order = new Order();
                order.OrderId = tr[0].ToString();
                order.TrackingNum = tr[1].ToString();
                order.OrderDate = tr[11].ToString();
                order.CustomerId = tr[3].ToString();
                order.CustomerName = tr[21].ToString();
                order.Address = tr[22].ToString();
                order.RouteNum = tr[2].ToString();

                listOfOrders.Add(order);
            }

            vm.orders = listOfOrders;
            Order o = new Order();
            o.OrderDate = "";
            o.CustomerId = "";
            o.CustomerName = "";
            vm.order = o;

            ViewData["Title"] = "Orders";
            return View(vm);
        }

        public ActionResult Filter()
        {
            OrderViewModel vm = new OrderViewModel();
            DataSet ds = new ReportsBLL().GetFilteredOrders_BLL("OrderDate > Convert(datetime, '2010')"); // Displays all orders

            //OrderDate Filter
            if (Request.Form["OrderDate"] == "1")
            {
                string today = DateTime.Today.ToString("MM/dd/yyyy");
                ds = new ReportsBLL().GetFilteredOrders_BLL("OrderDate > Convert(datetime, '"+today+"')");
            }
            else if (Request.Form["OrderDate"] == "2")
            {
                string week = DateTime.Today.AddDays(-7).ToString("MM/dd/yyyy");
                ds = new ReportsBLL().GetFilteredOrders_BLL("OrderDate > Convert(datetime, '"+ week +"')");
            }
            else if (Request.Form["OrderDate"] == "3")
            {
                string month = DateTime.Today.AddMonths(-1).ToString("MM/dd/yyyy");
                ds = new ReportsBLL().GetFilteredOrders_BLL("OrderDate > Convert(datetime, '"+ month +"')");
            }
            else if (Request.Form["OrderDate"] == "4")
            {
                string months = DateTime.Today.AddMonths(-6).ToString("MM/dd/yyyy");
                ds = new ReportsBLL().GetFilteredOrders_BLL("OrderDate > Convert(datetime, '"+ months +"')");
            }

            //CustomerID Filter
            if (Request.Form["CustomerId"] != "")
            {
                ds = new ReportsBLL().GetFilteredOrders_BLL("OrderCustomerNumber like '"+ Request.Form["CustomerId"] + "%'");
            }

            //CustomerName Filter
            if (Request.Form["CustomerName"] != "")
            {
                ds = new ReportsBLL().GetFilteredOrders_BLL("CustName like '"+ Request.Form["CustomerName"] + "%'");
            }

            DataTable dt = new DataTable();
                dt = ds.Tables[0];
                var listOfOrders = new List<Order>();
                foreach (DataRow tr in dt.Rows)
                {
                    //create new instance of order object
                    var order = new Order();
                    order.OrderId = tr[0].ToString();
                    order.TrackingNum = tr[1].ToString();
                    order.OrderDate = tr[11].ToString();
                    order.CustomerId = tr[3].ToString();
                    order.CustomerName = tr[21].ToString();
                    order.Address = tr[22].ToString();
                    order.RouteNum = tr[2].ToString();

                    listOfOrders.Add(order);
                }

            vm.orders = listOfOrders;
            Order o = new Order();
            o.OrderDate = Request.Form["OrderDate"];
            o.CustomerId = Request.Form["CustomerId"];
            o.CustomerName = Request.Form["CustomerName"];
            vm.order = o;

            ViewData["Title"] = "Orders";
            return View("Orders", vm);

        }
    }
}