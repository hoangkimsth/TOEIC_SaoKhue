using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOEIC_SaoKhue.Models;

namespace TOEIC_SaoKhue.Controllers
{
    [Auth(Roles = "TuVan")]
    public class ChuyenLopController : Controller
    {
        // GET: ChuyenLop
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeuCauChuyen(int hocvien, string lop_cu, string lop_moi)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_ChuyenLop(hocvien, lop_cu, lop_moi);
                        
                        return Json(new { success = true }, JsonRequestBehavior.DenyGet);
                    }
                    catch (Exception e)
                    {
                        
                        SqlException sqlex = e.InnerException as SqlException;
                        return Json(new { success = false, msg = sqlex.Message }, JsonRequestBehavior.DenyGet);
                    }
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
        }
    }
}