using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class askedQuestions : Form
    {
        public askedQuestions()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.questions' table. You can move, or remove it, as needed.
            //this.questionsTableAdapter.Fill(this.databaseDataSet.questions);

            SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getAssignedQuestions(@user_id)", sqlConnection);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = 1;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlConnection.Open();

            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();

        }
    }
}
