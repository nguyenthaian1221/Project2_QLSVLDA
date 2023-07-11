using Project2_QLSVLDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2_QLSVLDA.Areas.Teacher.Controllers
{
    public class GVClassController : Controller
    {
        // GET: Teacher/GVClass
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "HomeAdmin", new { area = "Admin" });
            }
            else
            {
                QL_PROJECTEntities1 db = new QL_PROJECTEntities1();
                var session = Session["user"].ToString();
                List<LOPMONHOC> lop = db.LOPMONHOCs.Where(m => m.magv == session).ToList();
               


                return View(lop);
            }
        }


        public ActionResult Detail(string id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "HomeAdmin", new { area = "Admin" });
            }
            else
            {

                QL_PROJECTEntities1 db = new QL_PROJECTEntities1();
                
                List<SINHVIENMONHOC> lop = db.SINHVIENMONHOCs.Where(m => m.malop == id.Trim()).ToList();
                return View(lop);
            }
        }

    }
}