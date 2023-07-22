using Project2_QLSVLDA.Content.Custom.Class;
using Project2_QLSVLDA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2_QLSVLDA.Areas.Student.Controllers
{
    public class SV_MeetingController : Controller
    {
        // GET: Student/SV_Meeting
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
        [Route("Book/{id}")]
        public ActionResult Book(string id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "HomeAdmin", new { area = "Admin" });
            }
            else
            {
                ClassID model = new ClassID();
                model.Id = id;

                return View(model);
            }
        }



        [HttpPost]
        public ActionResult DienThongTin()
        {

            //tblFileDetail model = new tblFileDetail();
            //List<tblFileDetail> list = new List<tblFileDetail>();
            //QL_PROJECTEntities1 db = new QL_PROJECTEntities1();
            //DateTime timenow = DateTime.Now;
            //var mssv = Session["user"].ToString();
            //var mabt = id;
            //var cmt = exercise_content;
            //var _malop = (from m in db.BAITAPs
            //              where mabt.ToString() == m.mabaitap.ToString().Trim()
            //              select m.malop).First();



            //using (var dbContext = new QL_PROJECTEntities1())
            //{
            //    var fileDetails = dbContext.tblFileDetails.ToList();
            //    foreach (var fileDetail in fileDetails)
            //    {
            //        list.Add(new tblFileDetail
            //        {
            //            SQLID = fileDetail.SQLID,
            //            FILENAME = fileDetail.FILENAME,
            //            FILEURL = fileDetail.FILEURL
            //        });
            //    }
            //}

            //model.FileList = list;

            //if (file != null)
            //{
            //    var Extension = Path.GetExtension(file.FileName);
            //    var Orgininame = Path.GetFileNameWithoutExtension(file.FileName);
            //    var fileName = Orgininame + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Extension;
            //    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
            //    model.FILEURL = Url.Content(Path.Combine("~/UploadedFiles/", fileName));
            //    model.FILENAME = fileName;



            //    var path_luu_csdl = Url.Content(Path.Combine("~/UploadedFiles/", fileName));
            //    var name_luu_csdl = fileName;



            //    //Xử lý lưu


            //    db.SaveChanges();




            //}







            return RedirectToAction("Index");
        }



    }

}