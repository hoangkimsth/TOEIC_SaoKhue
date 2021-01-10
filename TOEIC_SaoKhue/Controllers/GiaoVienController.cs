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
    public class GiaoVienController : Controller
    {
        // GET: GiaoVien
        public ActionResult Index()
        {            
            try
            {
                using (Entities db = new Entities())
                {
                    ViewBag.GiaoViens = db.sp_LietKeGiaoVien().ToList();

                    return View();
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
        }

        public ActionResult LichSuDay(short? giaovien, short? trang)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    ViewBag.GiaoVien = db.sp_XemGiaoVien(giaovien).FirstOrDefault();
                    if (ViewBag.GiaoVien == null)
                        return View();
                    short k = 1;
                    if (trang != null) { try { k = trang.GetValueOrDefault(); if (k < 1) { k = 1; } } catch { k = 1; } }
                    ViewBag.Lops = db.sp_XemLichSuDay(giaovien, 30, k).ToList();
                    ViewBag.KeTiep = db.sp_XemLichSuDay(giaovien, 30, (short?)(k + 1)).Count();
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
        public ActionResult Them(string ten, string sdt)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_ThemGiaoVien(ten, sdt);

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
        public ActionResult Xoa(short magv)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_XoaGiaoVien((short?)magv);

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
        public ActionResult CapNhat(short magv, string ten, string sdt)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_CapNhatGiaoVien((short?)magv, ten, sdt);
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