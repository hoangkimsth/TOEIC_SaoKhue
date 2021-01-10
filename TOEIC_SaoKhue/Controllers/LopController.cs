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
    public class LopController : Controller
    {
        // GET: Lop
        public ActionResult Index(short? loc, string chuongtrinh, short? trang)
        {
            try
            {
                using (Entities db = new Entities())
                {      
                    if (chuongtrinh == null)
                        chuongtrinh = "";
                    short k = 1;
                    if (trang != null) { try { k = trang.GetValueOrDefault(); if (k < 1) { k = 1; } } catch { k = 1; } }
                    ViewBag.ChuongTrinhs = db.sp_LietKeChuongTrinh().ToList();
                    ViewBag.Lops = db.sp_TimLop(chuongtrinh, loc, 20, k).ToList();
                    ViewBag.KeTiep = db.sp_TimLop(chuongtrinh, loc, 20, (short?)(k + 1)).Count();
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }           
        }

        public ActionResult Xem(string lop)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    ViewBag.Lop = db.sp_XemLop(lop).FirstOrDefault();
                    if (ViewBag.Lop == null)
                    {
                        return View();
                    }
                    ViewBag.GiaoViens = db.sp_LietKeGiaoVien().ToList();
                    ViewBag.HocViens = db.sp_XemDanhSachLop(lop).ToList();
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }            
        }

        [Auth(Roles = "QuanLy")]
        public ActionResult Them()
        {
            try
            {
                using (Entities db = new Entities())
                {
                    ViewBag.ChuongTrinhs = db.sp_LietKeChuongTrinh().ToList();
                    ViewBag.CaHocs = db.sp_LietKeCaHoc().ToList();
                    ViewBag.GiaoViens = db.sp_LietKeGiaoVien().ToList();
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
        public ActionResult Them_2(string chuongtrinh, int cahoc, int giaovien, int gioihan, DateTime? khaigiang, DateTime? ketthuc)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_ThemLop(chuongtrinh, (short?)cahoc, (short?)giaovien, (short?)gioihan, khaigiang, ketthuc);
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
        public ActionResult Xoa(string lop)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_HuyLop(lop);
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
        public ActionResult Tim(string malop)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    LOP lop = db.sp_XemLop(malop).FirstOrDefault();
                    if (lop == null)
                        return Json(new { success = false }, JsonRequestBehavior.DenyGet);
                    string thoigianhoc = lop.NgayKhaiGiang.ToShortDateString() + " - " + lop.NgayKetThuc.ToShortDateString();
                    return Json(new { success = true, malop = lop.MaLop, thoigianhoc, hocphi = lop.HocPhiCT }, JsonRequestBehavior.DenyGet);
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
        }

        [Auth(Roles = "GiaoVien")]
        public ActionResult ChamDiem(string lop)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    ViewBag.Lop = db.sp_XemLop(lop).ToList();
                    ViewBag.HocViens = db.sp_DanhSachChamDiem(lop).ToList();
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
        }

        [Auth(Roles = "GiaoVien")]
        [HttpPost]
        public ActionResult ChamDiem_2(int? mahd, string malop, string diemchuyencan, string diemcuoiky)
        {
            short chuyencan, cuoiky;
            try
            {
                chuyencan = short.Parse(diemchuyencan);
                cuoiky = short.Parse(diemcuoiky);
            }
            catch {
                return Json(new { success = false, msg = "Điểm không hợp lệ" }, JsonRequestBehavior.DenyGet);
            }
            try
            {
                using (Entities db = new Entities())
                {
                    try                    {
                        db.sp_ChamDiem(mahd, malop, chuyencan, cuoiky);
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
        public ActionResult BoTriGiaoVien(string malop, short magv)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_BoTriGiaoVien(malop, magv);
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