using Project2_QLSVLDA.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2_QLSVLDA.Areas.Teacher.Controllers
{
    public class GiaoVienCuocHenController : Controller
    {
        // GET: Teacher/GiaoVienCuocHen

        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "HomeAdmin", new { area = "Admin" });
            }
            else
            {
                var session = Session["user"].ToString();
                QL_PROJECTEntities1 db = new QL_PROJECTEntities1();

               
               
                List<CUOCHEN> ketqua = (from cuochen in db.CUOCHENs
                              where cuochen.magiaovien.Trim() == session
                                        select cuochen
                              ).ToList();

   

                return View(ketqua);
            }

        }

        [HttpPost]
        public ActionResult ActionName(string ngay, string giobatdau, string gioketthuc, string diadiem)
        {

            QL_PROJECTEntities1 db = new QL_PROJECTEntities1();

            string combinedDateTimeString = ngay + " " + giobatdau;
            DateTime start_time = DateTime.ParseExact(combinedDateTimeString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            combinedDateTimeString = ngay + " " + gioketthuc;
            DateTime end_time = DateTime.ParseExact(combinedDateTimeString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            string location = diadiem.Trim();
            string mgv = Session["user"].ToString();

            db.CUOCHENs.Add(
                new CUOCHEN
                {
                    thoigianbatdau = start_time,
                    thoigianketthuc = end_time,
                    diadiem = location,
                    magiaovien = mgv,
                    tinhtrang = 1, // mặc định set bằng 1 vì mới tạo

                }) ;
            
            db.SaveChanges();





            return RedirectToAction("Index", "GiaoVienCuocHen", new { area = "Teacher" });
        }
    }
}