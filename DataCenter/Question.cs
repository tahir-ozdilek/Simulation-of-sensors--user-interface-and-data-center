using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis_UI1
{
    public class Question
    {
        public int questionId;

        [Newtonsoft.Json.JsonProperty(ItemIsReference = true)]
        TimeSimulator timeSimulator;

        public Question(int id, TimeSimulator timeSimulator)
        {
            questionId = id;
            this.timeSimulator = timeSimulator;
        }

        public string getQuestionString(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getQuestionById(@questionId", sqlConnection);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@questionId", SqlDbType.Int).Value = id;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable questionTable = new DataTable();
            sqlConnection.Open();
            dataAdapter.Fill(questionTable);
            sqlConnection.Close();

            return (String)questionTable.Rows[0][1];
            // UI based solution
            //return Database.questionTable.Select("ID =" + id.ToString())[0]["Question"].ToString();
        }

        public TimeSimulator getTimeSimulator()
        {
            return timeSimulator;
        }
    }
}
