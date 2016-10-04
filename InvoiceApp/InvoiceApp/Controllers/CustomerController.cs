using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceApp.Models;
using System.Net;

namespace InvoiceApp.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        [Route("Customers/List")]
        public ActionResult Index()
        {
            List<Customer> customers = context.Customers.ToList();

            return View("Index", customers);
        }
        public ActionResult Edit(int id)
        {
            Customer customer = context.Customers.SingleOrDefault(c => c.ID == id);

            if(customer==null)
            {
                return HttpNotFound();
            }

            return View("CustomerForm",customer);
        }
        public ActionResult New()
        {
            Customer customer = new Customer();
            return View("CustomerForm", customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(ModelState.IsValid)
            {
                if (customer.ID==0)
                {
                    context.Customers.Add(customer);
                }
                else
                {
                    Customer customerInDb = context.Customers.Single(c => c.ID == customer.ID);

                    customerInDb.Name = customer.Name;
                    customerInDb.Address = customer.Address;
                    customerInDb.Email = customer.Email;
                }

                context.SaveChanges();
            }
            else
            {
                return View("CustomerForm", customer);
            }

            return RedirectToAction("Index","Customer");
        }
        [HttpDelete]
        public HttpStatusCode Delete(int id)
        {
            Customer customerInDb = context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerInDb != null)
            {
                context.Customers.Remove(customerInDb);
                context.SaveChanges();
                return (HttpStatusCode.OK);

            }
            else
            {
                return (HttpStatusCode.NotFound);
            }
        }
    }
}