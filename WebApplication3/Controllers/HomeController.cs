using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Index()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getAssignedQuestions(@user_id)", sqlConnection);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = 3;    

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            //cmd.ExecuteScalar();
            //SqlDataReader reader = cmd.ExecuteReader();
            /*Object obj = new Object();
            obj = reader.GetValue(0); //cmd.ExecuteScalar();
            obj = obj.ToString();*/
            int a = da.Fill(dt);
            sqlConnection.Close();

            return View(dt.AsEnumerable()); 
        }
    }
}
