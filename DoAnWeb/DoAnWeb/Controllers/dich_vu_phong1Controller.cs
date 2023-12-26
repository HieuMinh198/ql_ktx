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
    public class dich_vu_phong1Controller : Controller
    {
        private qlktx_DAWEntities1 db = new qlktx_DAWEntities1();

        // GET: dich_vu_phong1
        public ActionResult Index()
        {
            var dich_vu_phong = db.dich_vu_phong.Include(d => d.dich_vu).Include(d => d.Phong);
            return View(dich_vu_phong.ToList());
        }

        // GET: dich_vu_phong1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dich_vu_phong dich_vu_phong = db.dich_vu_phong.Find(id);
            if (dich_vu_phong == null)
            {
                return HttpNotFound();
            }
            return View(dich_vu_phong);
        }

        // GET: dich_vu_phong1/Create
        public ActionResult Create()
        {
            ViewBag.ma_dich_vu = new SelectList(db.dich_vu, "ma_dich_vu", "ten_dich_vu");
            ViewBag.ma_phong = new SelectList(db.Phong, "ma_phong", "ten_phong");
            return View();
        }

        // POST: dich_vu_phong1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_dich_vu_phong,so_luong,ma_dich_vu,ma_phong")] dich_vu_phong dich_vu_phong)
        {
            if (ModelState.IsValid)
            {
                db.dich_vu_phong.Add(dich_vu_phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_dich_vu = new SelectList(db.dich_vu, "ma_dich_vu", "ten_dich_vu", dich_vu_phong.ma_dich_vu);
            ViewBag.ma_phong = new SelectList(db.Phong, "ma_phong", "ten_phong", dich_vu_phong.ma_phong);
            return View(dich_vu_phong);
        }

        // GET: dich_vu_phong1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dich_vu_phong dich_vu_phong = db.dich_vu_phong.Find(id);
            if (dich_vu_phong == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_dich_vu = new SelectList(db.dich_vu, "ma_dich_vu", "ten_dich_vu", dich_vu_phong.ma_dich_vu);
            ViewBag.ma_phong = new SelectList(db.Phong, "ma_phong", "ten_phong", dich_vu_phong.ma_phong);
            return View(dich_vu_phong);
        }

        // POST: dich_vu_phong1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_dich_vu_phong,so_luong,ma_dich_vu,ma_phong")] dich_vu_phong dich_vu_phong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dich_vu_phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_dich_vu = new SelectList(db.dich_vu, "ma_dich_vu", "ten_dich_vu", dich_vu_phong.ma_dich_vu);
            ViewBag.ma_phong = new SelectList(db.Phong, "ma_phong", "ten_phong", dich_vu_phong.ma_phong);
            return View(dich_vu_phong);
        }

        // GET: dich_vu_phong1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dich_vu_phong dich_vu_phong = db.dich_vu_phong.Find(id);
            if (dich_vu_phong == null)
            {
                return HttpNotFound();
            }
            return View(dich_vu_phong);
        }

        // POST: dich_vu_phong1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            dich_vu_phong dich_vu_phong = db.dich_vu_phong.Find(id);
            db.dich_vu_phong.Remove(dich_vu_phong);
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
