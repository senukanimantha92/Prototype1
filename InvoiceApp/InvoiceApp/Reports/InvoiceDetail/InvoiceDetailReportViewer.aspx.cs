using InvoiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.Reporting.WebForms;

namespace InvoiceApp.Reports.InvoiceDetail
{
    public partial class InvoiceDetailReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderReport();
            }
        }
        private void RenderReport()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var invoices = from r in context.InvoiceDetail.Include(i => i.Item).Include(i=>i.InvoiceMaster)
                           select new { InvoiceNo = r.InvoiceMaster.InvoiceNo,Customer = r.InvoiceMaster.Customer.Name,Date = r.InvoiceMaster.Date, Item = r.Item.Name, Rate = r.Rate, Qty = r.Qty, Amount = r.Amount };



            ReportViewer1.Reset();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/InvoiceDetail/InvoiceDetailReport.rdlc");


            //ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("",""));

            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", invoices));
            ReportViewer1.LocalReport.Refresh();
        }
    }
}