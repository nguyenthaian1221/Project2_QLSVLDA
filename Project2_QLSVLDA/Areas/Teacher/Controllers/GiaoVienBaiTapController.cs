using Project2_QLSVLDA.Content.Custom.Class;
using Project2_QLSVLDA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;


namespace Project2_QLSVLDA.Areas.Teacher.Controllers
{
    public class GiaoVienBaiTapController : Controller
    {
        // GET: Teacher/GiaoVienBaiTap

        public ActionResult Index()
        {

            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "HomeAdmin", new { area = "Admin" });
            }
            else
            {

                return View();
            }
        }



    }
}
