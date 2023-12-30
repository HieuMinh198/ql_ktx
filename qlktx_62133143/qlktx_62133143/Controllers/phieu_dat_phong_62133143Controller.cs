using DoAnWeb.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DoAnWeb.Controllers
{
    public class phieu_dat_phong_62133143Controller : Controller
    {
        private qlktx_62133143 db = new qlktx_62133143();

        // GET: phieu_dat_phong
        public ActionResult Index()
        {
            var phieu_dat_phong = db.phieu_dat_phong.Include(p => p.Phong);
            return View(phieu_dat_phong.ToList());
        }

        // GET: phieu_dat_phong/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieu_dat_phong phieu_dat_phong = db.phieu_dat_phong.Find(id);
            if (phieu_dat_phong == null)
            {
                return HttpNotFound();
            }
            return View(phieu_dat_phong);
        }

        // GET: phieu_dat_phong/Create
        public ActionResult Create()
        {
            ViewBag.ma_phong = new SelectList(db.Phong, "ma_phong", "ten_phong");
            return View();
        }

        // POST: phieu_dat_phong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_phieu_dat_phong,ngay_dat,ngay_bat_dau,ngay_ket_thuc,tong_tien,ma_phong")] phieu_dat_phong phieu_dat_phong)
        {
            if (ModelState.IsValid)
            {
                db.phieu_dat_phong.Add(phieu_dat_phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_phong = new SelectList(db.Phong, "ma_phong", "ten_phong", phieu_dat_phong.ma_phong);
            return View(phieu_dat_phong);
        }

        // GET: phieu_dat_phong/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieu_dat_phong phieu_dat_phong = db.phieu_dat_phong.Find(id);
            if (phieu_dat_phong == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_phong = new SelectList(db.Phong, "ma_phong", "ten_phong", phieu_dat_phong.ma_phong);
            return View(phieu_dat_phong);
        }

        // POST: phieu_dat_phong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_phieu_dat_phong,ngay_dat,ngay_bat_dau,ngay_ket_thuc,tong_tien,ma_phong")] phieu_dat_phong phieu_dat_phong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieu_dat_phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_phong = new SelectList(db.Phong, "ma_phong", "ten_phong", phieu_dat_phong.ma_phong);
            return View(phieu_dat_phong);
        }

        // GET: phieu_dat_phong/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieu_dat_phong phieu_dat_phong = db.phieu_dat_phong.Find(id);
            if (phieu_dat_phong == null)
            {
                return HttpNotFound();
            }
            return View(phieu_dat_phong);
        }

        // POST: phieu_dat_phong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            phieu_dat_phong phieu_dat_phong = db.phieu_dat_phong.Find(id);
            db.phieu_dat_phong.Remove(phieu_dat_phong);
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
