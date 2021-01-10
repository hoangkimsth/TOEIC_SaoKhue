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
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        public ActionResult Index(string sdt, short? trang)
        {
            short k = 1;
            if (trang != null) { try { k = trang.GetValueOrDefault(); if (k < 1) { k = 1; } } catch { k = 1; } }
            if (sdt == null)
            {
                sdt = "";
            }
            try
            {
                using (Entities db = new Entities())
                {
                    ViewBag.HoaDons = db.sp_TimHoaDon(sdt, 20, k).ToList();
                    ViewBag.KeTiep = db.sp_TimHoaDon(sdt, 20, (short?)(k + 1)).Count();
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
        }

        [Auth(Roles = "TuVan")]
        public ActionResult LapHoaDon()
        {
            return View();
        }
        
        public ActionResult Xem(int? hoadon)
        {            
            try
            {
                using (Entities db = new Entities())
                {
                    HOADON _hoadon = db.sp_XemHoaDon(hoadon).FirstOrDefault();
                    if (_hoadon == null)
                    {
                        return View();
                    }
                    ViewBag.HoaDon = _hoadon;
                    ViewBag.Lops = db.sp_XemCacLopHoaDon(hoadon).ToList();
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
        }

        [Auth(Roles = "TuVan")]
        [HttpPost]
        public ActionResult LapHoaDon_2(int? hocvien, string lops, string dks)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        lops = lops.Replace(" ", "");
                        int? mahd = db.sp_DongHocPhi(hocvien, lops, dks).FirstOrDefault();
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