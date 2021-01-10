using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOEIC_SaoKhue.Controllers;
using TOEIC_SaoKhue.Models;

namespace TOEIC_SaoKhue.Reports
{
    public partial class DanhSachLop : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            string malop = Request.QueryString["lop"];
            try
            {
                using (Entities db = new Entities())
                {
                    var data = db.sp_XemDanhSachLop(malop).ToList();
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource datasource = new ReportDataSource("DataSetDanhSachLop", data);
                    ReportViewer1.LocalReport.DataSources.Add(datasource);

                    ReportViewer1.LocalReport.Refresh();
                }
            }
            catch
            {
                ReportViewer1.Visible = false;
            }
            
        }
    }
}