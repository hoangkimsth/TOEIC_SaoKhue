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
    public class HocVienController : Controller
    {
        // GET: HocVien
        public ActionResult Index(string sdt, short? trang)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    if (sdt == null)
                        sdt = "";
                    short k = 1;
                    if (trang != null) { try { k = trang.GetValueOrDefault(); if (k < 1) { k = 1; } } catch { k = 1; } }
                    ViewBag.HocViens = db.sp_TimHocVien(sdt, 20, k).ToList();
                    ViewBag.KeTiep = db.sp_TimHocVien(sdt, 20, (short?)(k + 1)).Count();
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
        public ActionResult Them(string hoten, string sdt, string email)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_ThemHocVien(hoten, sdt, email);
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

        public ActionResult Xem(int? hocvien)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    int mahv = 0;
                    try { mahv = hocvien.GetValueOrDefault(); } catch { }
                    ViewBag.HocVien = db.sp_XemHocVien(hocvien).FirstOrDefault();
                    if (ViewBag.HocVien == null)
                    {
                        return View();
                    }
                    ViewBag.LichSuHocs = db.sp_XemLichSuHoc(hocvien).ToList();
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
        }

        [HttpPost]
        public ActionResult Tim(int? mahv)
        {            
            try
            {
                using (Entities db = new Entities())
                {
                    HOCVIEN hocvien = db.sp_XemHocVien(mahv).FirstOrDefault();
                    if (hocvien == null)
                        return Json(new { success = false }, JsonRequestBehavior.DenyGet);
                    return Json(new { success = true, tenhv = hocvien.TenHV, sdt = hocvien.SDTHV }, JsonRequestBehavior.DenyGet);
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
        }
    }
}