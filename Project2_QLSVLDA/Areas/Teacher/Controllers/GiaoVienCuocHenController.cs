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

        public ActionResult DanhSachHen()
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


        [HttpPost]
        public ActionResult ActionName_Nhanxet(string id_meeting,string gv_comment)
        {
            var ses = Session["user"].ToString();
            using (QL_PROJECTEntities1 db = new QL_PROJECTEntities1())
            {

                var cuochen = db.CUOCHENs.FirstOrDefault(s => s.macuochen.ToString() == id_meeting.Trim() && ses == s.magiaovien.Trim() && s.tinhtrang != 1);

                if (cuochen != null)
                {
                    // Thực hiện sửa giá trị cần thay đổi
                    // Thay thế "Ten" bằng tên cột cần sửa và "New Name" bằng giá trị mới.
                    cuochen.ghichu = gv_comment;
                    // Lưu thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();
                    TempData["Message"] = "Successfully save";
                }
                else { TempData["Message"] = "Failed! Check ID!"; }

            }

            
            return Redirect("~/Teacher/GiaoVienCuocHen/DanhSachHen");

        }


    }
}