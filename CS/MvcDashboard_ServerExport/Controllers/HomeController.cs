using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using System;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Xml;

namespace MvcDashboard_ServerExport.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult ExportDashboardToPdf(string DashboardID, string DashboardState) {
            using (MemoryStream stream = new MemoryStream()) {
                string dashboardID = DashboardID;
                DashboardState dashboardState = new DashboardState();
                
                dashboardState.LoadFromJson(DashboardState);

                DashboardPdfExportOptions pdfOptions = new DashboardPdfExportOptions();
                pdfOptions.ExportFilters = true;
                pdfOptions.DashboardStatePosition = DashboardStateExportPosition.Below;

                string dateTimeNow = DateTime.Now.ToString("yyyyMMddHHmmss");
                string serverPath = Server.MapPath(@"~/App_Data/Export");
                if(!Directory.Exists(serverPath)) {
                    Directory.CreateDirectory(serverPath);
                }
                string filePath = Path.Combine(serverPath, dashboardID);
                string uniqueId = "_" + dateTimeNow + ".pdf";
                var exporter = new WebDashboardExporter(DashboardConfigurator.Default);
                exporter.ExportToPdf(dashboardID, stream, new System.Drawing.Size(1024, 768), dashboardState, pdfOptions);
                SaveFile(stream, filePath + uniqueId);

                ContentResult result = new ContentResult();
                result.Content = filePath + uniqueId;
                return result;
            }
        }

        private void SaveFile(MemoryStream stream, string path) {
            var fileStream = System.IO.File.Create(path);
            stream.WriteTo(fileStream);
            fileStream.Close();
        }
    }
}