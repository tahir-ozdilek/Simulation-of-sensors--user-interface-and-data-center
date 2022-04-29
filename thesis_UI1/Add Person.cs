using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesis_UI1
{
    public partial class Add_Person : Form
    {
        Main_Form mainForm;

        public Add_Person(Main_Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okay_Click(object sender, EventArgs e)
        {
            try
            { 
                /* UI based Solution
                Database.persons.Add(new Person(mainForm.personsGrid.Rows.Count,nameText.Text, surnameText.Text, dateTimePickerPersonBirthDate.Value));
                mainForm.personsGrid.Rows.Add(nameText.Text, surnameText.Text, dateTimePickerPersonBirthDate.Value);*/
                
                System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("[dbo].[SPaddPerson]", sqlConnection);
                
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@name", SqlDbType.NChar).Value = nameText.Text;
                cmd.Parameters.Add("@surname", SqlDbType.NChar).Value = surnameText.Text.ToCharArray();
                cmd.Parameters.Add("@birthdate", SqlDbType.DateTime).Value = dateTimePickerPersonBirthDate.Value;

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();

                mainForm.updatePatientGrid();
            }
            catch { }

            this.Close();
        }
    }
}
