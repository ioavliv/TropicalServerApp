using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TropicalServerApp.Models;
using TropicalServer.BLL;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace TropicalServerApp.Controllers
{
    public class LoginController : Controller
    {
        // static user object 
        // GET: Login
        
        public ActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View(new Customer());
        }
        public ActionResult Submit(Customer obj)
        {
            obj.CustomerId = Request.Form["CustomerId"];
            obj.CustomerPassword = Request.Form["CustomerPassword"];

            if (ModelState.IsValid)
            {
                DataSet ds = new ReportsBLL().GetUsersSetting_BLL("LoginId", obj.CustomerId);
                DataTable dt = new DataTable();

                dt = ds.Tables[0];
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][1].ToString() == obj.CustomerId && dt.Rows[0][2].ToString() == obj.CustomerPassword)
                    {
                        if (Request.Form["RememberId"] == "on")
                        {
                            Session["cId"] = Request.Form["CustomerId"];
                        }
                        return RedirectToAction("Orders", "Product");
                    }
                    ViewData["AuthError"] = "Invalid credentials!";
                    return View("Login", obj);
                }

                else
                {
                    ViewData["AuthError"] = "Invalid credentials!";
                    return View("Login", obj);
                }
            }
            else
            {
                return View("Login", obj);
            }
            
        }
        public ActionResult Logout()
        {
            ViewData["Title"] = "Login";
            Session["cId"] = null;
            return View("Login", new Customer());
        }
        public ActionResult ForgotUsername()
        {
            return View(new Email());
        }
        public ActionResult ForgotPassword()
        {
            return View(new Username());
        }
        public ActionResult SubmitEmail(Email obj)
        {
            obj.CustomerEmail = Request.Form["CustomerEmail"];
            if (ModelState.IsValid)
            {
                DataSet ds = new ReportsBLL().GetUsersSetting_BLL("Email", obj.CustomerEmail);
                DataTable dt = new DataTable();

                dt = ds.Tables[0];
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][8].ToString() == obj.CustomerEmail)
                    {
                        var smtpClient = new SmtpClient("smtp.gmail.com")
                        {
                            UseDefaultCredentials = false,
                            Port = 587,
                            Credentials = new NetworkCredential("ioavlivneh@gmail.com", "s4fe.Passw0rd1"),
                            EnableSsl = true
                        };

                        smtpClient.Send("ioavlivneh@gmail.com", obj.CustomerEmail, "Tropical Cheese Username", dt.Rows[0][1].ToString());

                        ViewData["Message"] = "Email has been sent";
                    }
                    return View("ForgotUsername", obj);
                }
                else
                {
                    ViewData["Message"] = "Invalid credentials!";
                    return View("ForgotUsername", obj);
                }
                
            }
            else
            {
                return View("ForgotUsername", obj);
            }
        }
        public ActionResult SubmitUsername(Username obj)
        {
            obj.CustomerId = Request.Form["CustomerId"];
            if (ModelState.IsValid)
            {
                DataSet ds = new ReportsBLL().GetUsersSetting_BLL("LoginID", obj.CustomerId);
                DataTable dt = new DataTable();

                dt = ds.Tables[0];
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][1].ToString() == obj.CustomerId)
                    {
                        var smtpClient = new SmtpClient("smtp.gmail.com")
                        {
                            UseDefaultCredentials = false,
                            Port = 587,
                            Credentials = new NetworkCredential("ioavlivneh@gmail.com", "s4fe.Passw0rd1"),
                            EnableSsl = true
                        };

                        smtpClient.Send("ioavlivneh@gmail.com", dt.Rows[0][8].ToString(), "Tropical Cheese Password", dt.Rows[0][2].ToString());

                        ViewData["Message"] = "Email has been sent";
                    }
                    return View("ForgotPassword", obj);
                }
                else
                {
                    ViewData["Message"] = "Invalid credentials!";
                    return View("ForgotPassword", obj);
                }

            }
            else
            {
                return View("ForgotPassword", obj);
            }
        }

    }
}