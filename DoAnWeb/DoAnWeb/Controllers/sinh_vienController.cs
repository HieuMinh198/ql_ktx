using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnWeb.Models;

namespace DoAnWeb.Controllers
{
    public class sinh_vienController : Controller
    {
        private qlktx_DAWEntities1 db = new qlktx_DAWEntities1();
        [HttpGet]

        public ActionResult TimKiemNC(string MaSV = "", string HoTen = "", string GioiTinh = "", string Lop = "", string QueQuan = "", string MaPB = "")
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
        public ActionResult PrintList()
        {
            var sinh_vien = db.sinh_vien.Include(s => s.Phong);
            return View(sinh_vien.ToList());
        }
        // GET: sinh_vien
        public ActionResult Index()
        {
            var sinh_vien = db.sinh_vien.Include(s => s.Phong);
            return View(sinh_vien.ToList());
        }

        // GET: sinh_vien/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinh_vien sinh_vien = db.sinh_vien.Find(id);
            if (sinh_vien == null)
            {
                return HttpNotFound();
            }
            return View(sinh_vien);
        }

        // GET: sinh_vien/Create
        public ActionResult Create()
        {
            ViewBag.ma_phong = new SelectList(db.Phong, "ma_phong", "ten_phong");
            return View();
        }

        // POST: sinh_vien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_sv,ho_ten,gioi_tinh,anh,ngay_sinh,que_quan,lop,sdt,email,ngay_vao_o,ma_phong")] sinh_vien sinh_vien)
        {
            if (ModelState.IsValid)
            {
                db.sinh_vien.Add(sinh_vien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_phong = new SelectList(db.Phong, "ma_phong", "ten_phong", sinh_vien.ma_phong);
            return View(sinh_vien);
        }

        // GET: sinh_vien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinh_vien sinh_vien = db.sinh_vien.Find(id);
            if (sinh_vien == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_phong = new SelectList(db.Phong, "ma_phong", "ten_phong", sinh_vien.ma_phong);
            return View(sinh_vien);
        }

        // POST: sinh_vien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_sv,ho_ten,gioi_tinh,anh,ngay_sinh,que_quan,lop,sdt,email,ngay_vao_o,ma_phong")] sinh_vien sinh_vien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinh_vien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_phong = new SelectList(db.Phong, "ma_phong", "ten_phong", sinh_vien.ma_phong);
            return View(sinh_vien);
        }

        // GET: sinh_vien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinh_vien sinh_vien = db.sinh_vien.Find(id);
            if (sinh_vien == null)
            {
                return HttpNotFound();
            }
            return View(sinh_vien);
        }

        // POST: sinh_vien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            sinh_vien sinh_vien = db.sinh_vien.Find(id);
            db.sinh_vien.Remove(sinh_vien);
            db.SaveChanges();
            return RedirectToAction("Index");
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
