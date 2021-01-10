using TOEIC_SaoKhue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.SqlClient;

namespace TOEIC_SaoKhue.Controllers
{
    public class Auth : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["taikhoan"] == null)
                return false;
            using (Entities db = new Entities())
            {
                var taikhoan = (TAIKHOAN)HttpContext.Current.Session["taikhoan"];
                if (taikhoan != null)
                {
                    if (this.Roles == "NhanVien")
                    {
                        return true;
                    }
                    if (this.Roles == "QuanLy")
                    {
                        if (taikhoan.LoaiTK == "A")
                            return true;
                        return false;
                    }
                    else if (this.Roles == "TuVan")
                    {
                        if (taikhoan.LoaiTK == "B")
                            return true;
                        return false;
                    }
                    else if (this.Roles == "GiaoVien")
                    {
                        if (taikhoan.LoaiTK == "C")
                            return true;
                        return false;
                    }
                }
            }
            HttpContext.Current.Session["admin"] = null;
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var context = HttpContext.Current;
            filterContext.Result = new RedirectToRouteResult(
            new RouteValueDictionary{
                { "action", "DangNhap" },
                { "controller", "TaiKhoan" },
            });
        }
    }

    public class TaiKhoanController : Controller
    {
        [Auth(Roles = "QuanLy")]
        // GET: TaiKhoan
        public ActionResult Index()
        {
            using (Entities db = new Entities())
            {
                ViewBag.TaiKhoans = db.sp_LietKeTaiKhoan().ToList();
                return View();
            }
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap_2(string username, string password)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    TAIKHOAN taikhoan = db.sp_DangNhap(username, password).FirstOrDefault();
                    if (taikhoan == null)
                        return Json(new { success = false, msg = "Sai thông tin đăng nhập" }, JsonRequestBehavior.DenyGet);
                    HttpContext.Session["taikhoan"] = taikhoan;
                    return Json(new { success = true }, JsonRequestBehavior.DenyGet);
                }
            }
            catch
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }            
        }

        public ActionResult DangXuat()
        {
            HttpContext.Session["taikhoan"] = null;
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        [HttpPost]
        public ActionResult Them(string username, string password, string loai)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_TaoTaiKhoan(username, password, loai);
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
        public ActionResult Xoa(short matk)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_XoaTaiKhoan(matk);
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
        public ActionResult DoiMatKhau(short matk, string password)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    try
                    {
                        db.sp_ThayDoiMatKhau(matk, password);
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