using Project2_QLSVLDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2_QLSVLDA.Areas.Student.Controllers
{
    public class SubmitAssignmentController : Controller
    {
        // GET: Student/SubmitAssignment
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


        [HttpGet]
        [Route("DetailAndSubmit/{id}")]
        public ActionResult DetailAndSubmit(string id)
        {


            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "HomeAdmin", new { area = "Admin" });
            }
            else
            {
                QL_PROJECTEntities1 db = new QL_PROJECTEntities1();
                var noidung_baitap = (from m in db.BAITAPs
                                     where id == m.mabaitap.ToString().Trim()
                                     select m.noidung).First();
                ViewBag.noidung = noidung_baitap;
               
                return View();
            }

        }
    }
}