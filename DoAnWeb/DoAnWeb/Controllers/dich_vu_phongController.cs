using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWeb.Models;

namespace DoAnWeb.Controllers
{
    public class dich_vu_phongController : Controller
    {
        private string connectionString = "Data Source=LAPTOP-4Q6MJ67F\\SQL_SEVER_TVP;Initial Catalog=qlktx_DAW;Integrated Security=True";

        public ActionResult CalculateServiceCost()
        {
            // Gọi stored procedure và lấy kết quả vào một DataTable
            var dataTable = new DataTable();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("CalculateServiceCost", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            // Truyền DataTable qua ViewBag hoặc model để hiển thị trong view
            ViewBag.ServiceCostTable = dataTable;

            return View();
        }
    }
}
