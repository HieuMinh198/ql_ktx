using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace DoAnWeb.Controllers
{
    public class dich_vu_phong_62133178Controller : Controller
    {
        //private string connectionString = "Data Source=MSI\\HOAMADAO;Initial Catalog=qlktx_62133178;Integrated Security=True;Trust Server Certificate=True";
        private string connectionString = "data source=MSI\\HOAMADAO;initial catalog=qlktx_62133178;integrated security=True;multipleactiveresultsets=True;";

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
