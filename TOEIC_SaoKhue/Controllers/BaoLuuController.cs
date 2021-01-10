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
    public class BaoLuuController : Controller
    {
        // GET: BaoLuu
        public ActionResult Index()
        {
            try
            {
                using (Entities db = new Entities())
                {
                    ViewBag.BaoLuus = db.sp_LietKeBaoLuu().ToList();
                    
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
        }

        [HttpPost]
        public ActionResult YeuCauBaoLuu(int? hocvien, string lop)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_BaoLuu(hocvien, lop);
                        
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

        [HttpPost]
        public ActionResult Huy(int? mahd, string lop)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_HuyBaoLuu(mahd, lop);
                        
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