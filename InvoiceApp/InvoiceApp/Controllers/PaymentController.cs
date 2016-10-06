using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceApp.Models;
using InvoiceApp.ViewModels;
using System.Data.SqlClient;

namespace InvoiceApp.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        public ActionResult Index()
        {
            PaymentViewModel viewModel = new PaymentViewModel();

            var customers = context.Customers.ToList();

            List<string> paymentMethods = new List<string>();
            paymentMethods.Add("Cash");
            paymentMethods.Add("Credit Card");
            paymentMethods.Add("Cheque");

            viewModel.Customers = customers;
            viewModel.PaymentMethods = paymentMethods;

            return View("PaymentForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(PaymentViewModel  p)
        {
            if (ModelState.IsValid)
            {
                context.Payments.Add(p.Payment);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetOpeningBalance(int customerid)
        {
            double balance = context.Database.SqlQuery<double>("EXEC GETOpeningBalance @customer", new SqlParameter("@customer", customerid)).FirstOrDefault<double>();

            return new JsonResult { Data = new { balance = balance }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}