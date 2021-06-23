# Dashboard for MVC - How to implement server-side export


This example demonstrates how to export a dashboard displayed using the <a href="https://docs.devexpress.com/Dashboard/16977/Building-the-Designer-and-Viewer-Applications">ASP.NET MVC Dashboard extension</a> on the server side using the <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.WebDashboardExporter">WebDashboardExporter</a> class. The following API is used:

* The <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.Scripts.ASPxClientDashboard.BeforeRender">ASPxClientDashboard.BeforeRender</a> event is handled to obtain the client-side <a href="https://docs.devexpress.com/Dashboard/js-DevExpress.Dashboard.DashboardControl">DashboardControl</a> with the <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.Scripts.ASPxClientDashboard.GetDashboardControl">ASPxClientDashboard.GetDashboardControl</a> method.
* The AJAX request is used to send the dashboard identifier and state to the server side. On the server side, these values are received as action method parameters and passed to the <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.WebDashboardExporter.ExportToPdf.overloads">WebDashboardExporter.ExportToPdf</a> method.
