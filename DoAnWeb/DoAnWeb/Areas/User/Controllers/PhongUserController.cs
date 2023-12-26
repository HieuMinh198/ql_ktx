using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnWeb.Models;

namespace DoAnWeb.Areas.User.Controllers
{
    public class PhongUserController : Controller
    {
        private qlktx_DAWEntities1 db = new qlktx_DAWEntities1();

        // GET: User/PhongUser
        public ActionResult Index(string maPhong = "", string tenPhong = "", string giaMin = "", string giaMax = "")
        {

            string min = giaMin, max = giaMax;
            ViewBag.maPhong = maPhong;
            ViewBag.tenPhong = tenPhong;
            if (giaMin == "")
            {
                ViewBag.giaMin = "";
                min = "0";
            }
            else
            {
                ViewBag.giaMin = giaMin;
                min = giaMin;
            }
            if (max == "")
            {
                max = Int32.MaxValue.ToString();
                ViewBag.giaMax = "";// Int32.MaxValue.ToString(); 
            }
            else
            {
                ViewBag.giaMax = giaMax;
                max = giaMax;
            }
            var phongs = db.Phong.SqlQuery("Phong_TimKiem'" + maPhong + "','" + tenPhong + "','" + min + "','" + max + "'");
            if (phongs.Count() == 0)
                ViewBag.TB = "Không có thông tin cần tìm.";
            return View(phongs.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
