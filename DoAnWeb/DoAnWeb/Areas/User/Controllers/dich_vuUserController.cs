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
    public class dich_vuUserController : Controller
    {
        private qlktx_DAWEntities1 db = new qlktx_DAWEntities1();

        // GET: User/dich_vuUser
        public ActionResult Index()
        {
            return View(db.dich_vu.ToList());
        }

        // GET: User/dich_vuUser/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dich_vu dich_vu = db.dich_vu.Find(id);
            if (dich_vu == null)
            {
                return HttpNotFound();
            }
            return View(dich_vu);
        }

        // GET: User/dich_vuUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/dich_vuUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_dich_vu,ten_dich_vu,gia_dich_vu")] dich_vu dich_vu)
        {
            if (ModelState.IsValid)
            {
                db.dich_vu.Add(dich_vu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dich_vu);
        }

        // GET: User/dich_vuUser/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dich_vu dich_vu = db.dich_vu.Find(id);
            if (dich_vu == null)
            {
                return HttpNotFound();
            }
            return View(dich_vu);
        }

        // POST: User/dich_vuUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_dich_vu,ten_dich_vu,gia_dich_vu")] dich_vu dich_vu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dich_vu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dich_vu);
        }

        // GET: User/dich_vuUser/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dich_vu dich_vu = db.dich_vu.Find(id);
            if (dich_vu == null)
            {
                return HttpNotFound();
            }
            return View(dich_vu);
        }

        // POST: User/dich_vuUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            dich_vu dich_vu = db.dich_vu.Find(id);
            db.dich_vu.Remove(dich_vu);
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
