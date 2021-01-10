using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOEIC_SaoKhue.Models;

namespace TOEIC_SaoKhue.Controllers
{
    [Auth(Roles = "NhanVien")]
    public class ChuongTrinhController : Controller
    {
        // GET: ChuongTrinh
        public ActionResult Index()
        {
            try
            {
                using (Entities db = new Entities())
                {
                    ViewBag.ChuongTrinhs = db.sp_LietKeChuongTrinh().ToList();
                    
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
        }

        [Auth(Roles = "QuanLy")]
        [HttpPost]
        public ActionResult Them(string mact, string tenct, string thoigianhoc, double hocphi)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_ThemChuongTrinh(mact, tenct, thoigianhoc, hocphi);
                        
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

        [Auth(Roles = "QuanLy")]
        [HttpPost]
        public ActionResult CapNhat(string mact, string tenct, string thoigianhoc, double hocphi)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_CapNhatChuongTrinh(mact, tenct, thoigianhoc, hocphi);
                        
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