﻿using Project2_QLSVLDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2_QLSVLDA.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap");
            }
            else
            {
                return View();
            }
        }

        public ActionResult DangNhap()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DangNhap(string user, string password)
        {
            // Check DB
            QL_PROJECTEntities1 db = new QL_PROJECTEntities1();
            int demTaiKhoan = db.USERACCOUNTs.Count(m=>m.ID.ToLower() == user.ToLower() && m.password == password);
            // Check Code 
            if (demTaiKhoan == 1  )
            {
                // lưu vào session

                if (user.ToLower() == "admin")
                {
                    Session["user"] = user;
                    ViewBag.user = user;

                    return RedirectToAction("Index");
                }
                else if (db.SINHVIENs.Any(m => m.massv == user.ToLower()))
                {
                    Session["user"] = user;
                    ViewBag.user = user;
                    return RedirectToAction("Index", "SinhVienHome",new { area = "Student"});
                }

                else if (db.GIANGVIENs.Any(m => m.magv == user.ToLower()))
                {
                    Session["user"] = user;
                    ViewBag.user = user;
                    return RedirectToAction("Index", "GiaoVienHome", new { area = "Teacher" });
                }

                else
                {
                    return View();
                }

            }
            else
            {
                TempData["error"] = "Tài khoản đăng nhập không đúng";
                return View();
            }

        }

    }
}