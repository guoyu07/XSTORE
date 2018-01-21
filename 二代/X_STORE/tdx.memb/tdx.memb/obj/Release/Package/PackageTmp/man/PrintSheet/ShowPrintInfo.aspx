<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowPrintInfo.aspx.cs" Inherits="tdx.memb.man.PrintSheet.ShowPrintInfo" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register assembly="DevExpress.XtraReports.v14.1.Web, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
           <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" Text="打印">
            <ClientSideEvents Click="function(s, e) {
	viewer.SaveToDisk('PDF');
	viewer.Print();
}" />
         </dx:ASPxButton>
           <dx:ReportViewer ID="ReportViewer" runat="server" ClientInstanceName="viewer"></dx:ReportViewer> 
       </div>
    </form>
</body>
</html>
