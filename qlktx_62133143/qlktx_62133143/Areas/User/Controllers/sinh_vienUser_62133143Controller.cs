using DoAnWeb.Models;
using System.Linq;
using System.Web.Mvc;

namespace DoAnWeb.Areas.User.Controllers
{
    public class sinh_vienUser_62133143Controller : Controller
    {
        private qlktx_62133143 db = new qlktx_62133143();

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
