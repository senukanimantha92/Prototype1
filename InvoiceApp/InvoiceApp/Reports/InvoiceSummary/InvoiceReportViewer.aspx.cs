using InvoiceApp.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
namespace InvoiceApp.Reports
{
    public partial class InvoiceReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                RenderReport();
            }
        }

        private void RenderReport()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var invoices = from r in context.InvoiceMaster.Include(i => i.Customer)
                    select new { InvoiceNo = r.InvoiceNo, Date = r.Date, Memo = r.Memo, Customer = r.Customer.Name, Total = r.Total };

                     

            ReportViewer1.Reset();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/InvoiceSummary/InvoiceReport.rdlc");

            
            //ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("",""));

            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", invoices));
            ReportViewer1.LocalReport.Refresh();
        }
    }
}