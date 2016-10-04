using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceApp.Models;
using InvoiceApp.ViewModels;
using System.Data.Entity;
using System.Net;

namespace InvoiceApp.Controllers
{
     [Authorize]
    public class ItemController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        [Route("Items/List")]
        public ActionResult Index()
        {
            List<Item> items = context.Items.ToList();

            return View("Index",items);
        }
        public ActionResult New()
        {                 
            ItemFormViewModel viewModel = new ItemFormViewModel();
            viewModel.Item = new Item();
            viewModel.Accounts = context.Accounts.ToList();

            return View("ItemForm",viewModel);
        }
        public ActionResult Edit(int id)
        {
            Item item = context.Items.Include(a => a.Account).SingleOrDefault(i => i.ID == id);

            if (item == null)
            {
                return HttpNotFound();
            }

            ItemFormViewModel viewModel = new ItemFormViewModel();
            viewModel.Item = item;
            viewModel.Accounts = context.Accounts.ToList();

            return View("ItemForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Item item)
        {
            if (ModelState.IsValid)
            {
                if (item.ID == 0)
                {
                    context.Items.Add(item);
                }
                else
                {
                    Item itemInDb = context.Items.Single(i => i.ID == item.ID);

                    itemInDb.Name = item.Name;
                    itemInDb.Type = item.Type;
                    itemInDb.Cost = item.Cost;
                    itemInDb.SalesPrice = item.SalesPrice;
                    itemInDb.Cost = item.Cost;
                    itemInDb.AccountID = item.AccountID;
                }

                context.SaveChanges();
            }
            else
            {
                ItemFormViewModel viewModel = new ItemFormViewModel();
                viewModel.Item = item;
                viewModel.Accounts = context.Accounts.ToList();

                return View("ItemForm", viewModel);
            }

            return RedirectToAction("Index", "Item");
        }
        [HttpDelete]
        public HttpStatusCode Delete(int id)
        {
            Item itemInDb = context.Items.SingleOrDefault(i => i.ID == id);

            if (itemInDb != null)
            {
                context.Items.Remove(itemInDb);
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