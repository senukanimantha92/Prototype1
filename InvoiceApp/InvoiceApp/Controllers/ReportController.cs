using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceApp.Controllers
{
     [Authorize]
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult InvoiceSummary()
        {
            ViewBag.ReportURL = "../Reports/InvoiceSummary/InvoiceReportViewer.aspx";

            return View("Index");
        }
        public ActionResult InvoiceDetail()
        {
            ViewBag.ReportURL = "../Reports/InvoiceDetail/InvoiceDetailReportViewer.aspx";

            return View("Index");
        }
    }
}