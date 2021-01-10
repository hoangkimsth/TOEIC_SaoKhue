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
    public class CaHocController : Controller
    {
        // GET: CaHoc
        public ActionResult Index()
        {
            try
            {
                using (Entities db = new Entities())
                {
                    ViewBag.CaHocs = db.sp_LietKeCaHoc().ToList();                    
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
        public ActionResult Them(string giohoc, string ngayhoc)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_ThemCaHoc(giohoc, ngayhoc);
                        
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
        public ActionResult Xoa(short mach)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_XoaCaHoc((short?)mach);
                        
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
        public ActionResult CapNhat(short mach, string giohoc, string ngayhoc)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_CapNhatCaHoc(mach, giohoc, ngayhoc);
                        
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