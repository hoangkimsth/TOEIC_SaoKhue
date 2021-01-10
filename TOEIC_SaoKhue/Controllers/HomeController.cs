using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOEIC_SaoKhue.Models;

namespace TOEIC_SaoKhue.Controllers
{
    [Auth(Roles = "NhanVien")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TAIKHOAN taikhoan = (TAIKHOAN)Session["taikhoan"];
            if (taikhoan.LoaiTK == "A")
            {
                return RedirectToAction("Index", "TaiKhoan");
            }
            else if(taikhoan.LoaiTK == "B")
            {
                return RedirectToAction("Index", "Lop");
            }
            else
            {
                return RedirectToAction("Index", "GiaoVien");
            }
        }
    }
}