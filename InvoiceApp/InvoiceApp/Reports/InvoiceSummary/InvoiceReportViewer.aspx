<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceReportViewer.aspx.cs" Inherits="InvoiceApp.Reports.InvoiceReportViewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
       <div style="height:35px;width:100%;background-color:azure;margin-bottom:15px">
           <div style="margin-top:10px">
               <label>From</label>
               <input type="text" id="fromDate" />
               <label>To</label>
               <input type="text" id="toDate" />
               <input type="button" value="Refresh" id="refresh" />
           </div>
       </div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" Width="99%" Height="1200px"></rsweb:ReportViewer>
    </div>
    </form>
</body>

    <script>
        $(document).ready(function () {

            $("#fromDate").datepicker({
                dateFormat: "yy-mm-dd"
            })
        })
    </script>
</html>
