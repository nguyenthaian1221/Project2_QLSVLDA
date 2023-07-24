using Project2_QLSVLDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2_QLSVLDA.Areas.Student.Controllers
{
    public class SinhVienHomeController : Controller
    {
        // GET: Student/SinhVienHome
        QL_PROJECTEntities1 db = new QL_PROJECTEntities1();
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

        public JsonResult GetEvents()
        {




            return Json(db.CUOCHENs.AsEnumerable().Select(e => new
            {
                id = e.macuochen,
                title = "Lịch gặp sv",
                description = e.ghichu,
                start = e.thoigianbatdau.Value.ToString("MM/dd/yyyy HH:mm"),
                end = e.thoigianketthuc.Value.ToString("MM/dd/yyyy HH:mm")

            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
