using DoAnWeb.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
namespace DoAnWeb.Controllers
{
    public class quan_tri_62133178Controller : Controller
    {
        private qlktx_62133178 db = new qlktx_62133178();
        public bool CheckUser(string username, string password)
        {
            var kq = db.quan_tri.Where(x => x.Email == username && x.Password == password).ToList();
            //string hoTen = kq.First().HoTen;
            if (kq.Count() > 0)
            {
                Session["HoTen"] = kq.First().HoTen;
                return true;
            }
            else
            {
                Session["HoTen"] = null;
                return false;
            }
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(quan_tri qt)
        {
            if (ModelState.IsValid)
            {
                if (CheckUser(qt.Email, qt.Password))
                {
                    FormsAuthentication.SetAuthCookie(qt.Email, true);
                    return RedirectToAction("Index", "sinh_vien/Index");
                }
                else
                    ModelState.AddModelError("", "Tên đăng nhập hoặc tài khoản không đúng.");
            }
            return View(qt);
        }
        // GET: quan_tri
        public ActionResult Index()
        {
            return View(db.quan_tri.ToList());
        }

        // GET: quan_tri/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quan_tri quan_tri = db.quan_tri.Find(id);
            if (quan_tri == null)
            {
                return HttpNotFound();
            }
            return View(quan_tri);
        }

        // GET: quan_tri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: quan_tri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Admin,HoTen,Password")] quan_tri quan_tri)
        {
            if (ModelState.IsValid)
            {
                db.quan_tri.Add(quan_tri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quan_tri);
        }

        // GET: quan_tri/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quan_tri quan_tri = db.quan_tri.Find(id);
            if (quan_tri == null)
            {
                return HttpNotFound();
            }
            return View(quan_tri);
        }

        // POST: quan_tri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,Admin,HoTen,Password")] quan_tri quan_tri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quan_tri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quan_tri);
        }

        // GET: quan_tri/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quan_tri quan_tri = db.quan_tri.Find(id);
            if (quan_tri == null)
            {
                return HttpNotFound();
            }
            return View(quan_tri);
        }

        // POST: quan_tri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            quan_tri quan_tri = db.quan_tri.Find(id);
            db.quan_tri.Remove(quan_tri);
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
