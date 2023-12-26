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
    public class sinh_vienUserController : Controller
    {
        private qlktx_DAWEntities1 db = new qlktx_DAWEntities1();

        // GET: User/sinh_vienUser
        public ActionResult Index(string MaSV = "", string HoTen = "", string GioiTinh = "", string Lop = "", string QueQuan = "", string MaPB = "")
        {
            ViewBag.MaSV = MaSV;
            ViewBag.HoTen = HoTen;
            ViewBag.GioiTinh = GioiTinh;
            ViewBag.Lop = Lop;
            ViewBag.QueQuan = QueQuan;
            ViewBag.MaPB = new SelectList(db.Phong, "ma_phong", "ten_phong");
            var sinhViens = db.sinh_vien.SqlQuery("SinhVien_TimKiem'" + MaSV + "','" + HoTen + "','" + GioiTinh + "','" + Lop + "',N'" + QueQuan + "','" + MaPB + "'");
            if (sinhViens.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(sinhViens.ToList());
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
