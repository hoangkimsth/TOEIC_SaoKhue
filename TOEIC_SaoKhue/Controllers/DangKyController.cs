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
    public class DangKyController : Controller
    {
        // GET: DangKy
        public ActionResult Index(string sdt, int? loc, short? trang)
        {            
            try
            {
                short k = 1;
                if (trang != null) { try { k = trang.GetValueOrDefault(); if (k < 1) { k = 1; } } catch { k = 1; } }
                if (sdt == null)
                {
                    sdt = "";
                }
                loc = loc.GetValueOrDefault();
                using (Entities db = new Entities())
                {
                    ViewBag.DangKys = db.sp_TimDangKy(sdt, (short?)loc, 20, (short?)k).ToList();
                    ViewBag.KeTiep = db.sp_TimDangKy(sdt, (short?)loc, 20, (short?)(k + 1)).Count();
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
        }

        [HttpPost]
        public ActionResult DangKy(string sdt, string ten, string lop)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_DangKy(lop, sdt, ten);
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
        public ActionResult Huy(int madk)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_HuyDangKy(madk);
                        
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
        public ActionResult Tim(string madk)
        {
            int _madk = 0;
            try { _madk = int.Parse(madk); } catch { return Json(new { success = false }, JsonRequestBehavior.DenyGet); }
            LOP lop;
            try
            {
                using (Entities db = new Entities())
                {
                    lop = db.sp_XemLopDK(_madk).FirstOrDefault();
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            if (lop == null)
                return Json(new { success = false }, JsonRequestBehavior.DenyGet);
            string thoigianhoc = lop.NgayKhaiGiang.ToShortDateString() + " - " + lop.NgayKetThuc.ToShortDateString();
            return Json(new { success = true, malop = lop.MaLop, thoigianhoc, hocphi = lop.HocPhiCT }, JsonRequestBehavior.DenyGet);
        }
    }
}