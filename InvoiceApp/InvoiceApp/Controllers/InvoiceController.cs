using InvoiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceApp.ViewModels;
using System.Data.Entity;
using Newtonsoft.Json;

namespace InvoiceApp.Controllers
{
     [Authorize]
    public class InvoiceController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        public ActionResult Create()
        {
            ViewBag.Status = "Create";
            return View("InvoiceForm");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Status = "Edit";
            ViewBag.InvoiceID = id;
            return View("InvoiceForm");
        }
        public ActionResult GetCustomerData()
        {
            var customers = context.Customers.OrderBy(c => c.Name).ToList();

            JsonResult jsonData = new JsonResult();
            jsonData.Data = customers;
            jsonData.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return jsonData;
        }
        public ActionResult GetItemData()
        {
            var items = context.Items.OrderBy(i => i.Name).ToList();

            JsonResult jsonData = new JsonResult();
            jsonData.Data = items;
            jsonData.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return jsonData;
        }
        public ActionResult InvoiceList()
        {
            return View("InvoiceList");
        }
        public ActionResult GetInvoiceList()
        {
            var invoiceList = context.InvoiceMaster.Include(i => i.Customer).ToList();

            JsonResult jsonData = new JsonResult();
            jsonData.Data = invoiceList;
            jsonData.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return jsonData;
        }
        [HttpPost]
        public ActionResult Save(InvoiceFormViewModel invoiceViewModel)
        {
            bool status = false;

            try
            {
                if (invoiceViewModel.InvoiceMaster.InvoiceMasterID == 0)
                {
                    context.InvoiceMaster.Add(invoiceViewModel.InvoiceMaster);

                    foreach (InvoiceDetail detail in invoiceViewModel.InvoiceDetails)
                    {
                        context.InvoiceDetail.Add(detail);
                    }
                }
                else
                {
                    var invoiceMaterInDB = context.InvoiceMaster.Single(i => i.InvoiceMasterID == invoiceViewModel.InvoiceMaster.InvoiceMasterID);

                    var invoiceDetailInDB = context.InvoiceDetail.Where(i => i.InvoiceMasterID == invoiceViewModel.InvoiceMaster.InvoiceMasterID);
                    
                    if(invoiceMaterInDB!=null)
                    {
                        invoiceMaterInDB.CustomerID = invoiceViewModel.InvoiceMaster.CustomerID;
                        invoiceMaterInDB.Date = invoiceViewModel.InvoiceMaster.Date;
                        invoiceMaterInDB.Memo = invoiceViewModel.InvoiceMaster.Memo;
                        invoiceMaterInDB.Total = invoiceViewModel.InvoiceMaster.Total;

                        context.InvoiceDetail.RemoveRange(invoiceDetailInDB);

                        foreach (InvoiceDetail detail in invoiceViewModel.InvoiceDetails)
                        {
                            detail.InvoiceMasterID = invoiceViewModel.InvoiceMaster.InvoiceMasterID;
                            context.InvoiceDetail.Add(detail);
                        }
                    }

                }

                context.SaveChanges();

                status = true;
            }
            catch (Exception)
            {             
                status = false;
            }

            return new JsonResult { Data = new { status = status } };
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            bool status = false;

            try 
	        {	        
		        var invoiceInDB = context.InvoiceMaster.Single(i => i.InvoiceMasterID == id);

                if (invoiceInDB != null)
                {
                    context.InvoiceMaster.Remove(invoiceInDB);

                    context.SaveChanges();

                    status = true;
                }

	        }
	        catch (Exception)
	        {
                status = false;
	        }

            return new JsonResult { Data = new { status = status } };
        }
        public ActionResult InvoiceDetails(int id)
        {
            InvoiceFormViewModel vm = new InvoiceFormViewModel();

            vm.InvoiceMaster = context.InvoiceMaster.SingleOrDefault(i => i.InvoiceMasterID == id);

            vm.InvoiceDetails = context.InvoiceDetail.Where(i => i.InvoiceMasterID == id);

            var jsonData = JsonConvert.SerializeObject(vm,
                            Formatting.None,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                            });

            return Content(jsonData, "application/json");
        }

        public ActionResult GetItemRate(int itemID)
        {
            Item itemInDB = context.Items.SingleOrDefault(i => i.ID == itemID);

            return new JsonResult { Data = new { rate = itemInDB.Cost },JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult GetInvoiceNo()
        {
            string invoiceNo;

            var maxID = context.InvoiceMaster.OrderByDescending(i => i.InvoiceNo).FirstOrDefault();

             if (maxID == null)
             {
                 invoiceNo = "1";
             }
             else
             {
                 int id;
                 Int32.TryParse(maxID.InvoiceNo.ToString(),out id);
                 invoiceNo = (id += 1).ToString();
             }

             return new JsonResult { Data = new { InvoiceNo = invoiceNo }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}