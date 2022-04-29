using clientQuestionsWeb.NetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace clientQuestionsWeb.NetCore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PersonModel person)
        { 
            Questions(person.PersonId);
            return View("Questions");
        }

        [HttpGet]
        public IActionResult Questions(int personId)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
            //SqlConnection sqlConnection = new SqlConnection(@"server=tcp:192.168.1.101,1433; database=thesisDB; User ID=sa;Password=123qweQWE");

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getAssignedQuestions(@user_id)", sqlConnection);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = personId;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            //cmd.ExecuteScalar();
            //SqlDataReader reader = cmd.ExecuteReader();
            /*Object obj = new Object();
            obj = reader.GetValue(0); //cmd.ExecuteScalar();
            obj = obj.ToString();*/
            da.Fill(dt);
            sqlConnection.Close();

            return View(dt.AsEnumerable());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
