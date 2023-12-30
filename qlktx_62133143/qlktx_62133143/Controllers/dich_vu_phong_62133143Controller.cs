using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace DoAnWeb.Controllers
{
    public class dich_vu_phong_62133143Controller : Controller
    {
        private string connectionString = "data source=MSI\\HOAMADAO;initial catalog=qlktx_62133143;integrated security=True;MultipleActiveResultSets=True;";

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
