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

namespace thesis_UI1
{
    public partial class Main_Form : Form
    {
        volatile static public bool isGenerate = false;
        public SelectionRange selectionRangeForData = new SelectionRange(new DateTime(),new DateTime());
        public SelectionRange selectionRangeForQuestion = new SelectionRange(new DateTime(), new DateTime());
        public SelectionRange selectionRangeForParameter = new SelectionRange(new DateTime(), new DateTime());

        public Main_Form()
        {
            InitializeComponent();
            toolStripContainer1.Hide();
            toolStripContainer2.Hide();

            new Database();

            /*foreach (List<string> parameterType in Database.generatingParameterTypes)
            {
                newParameterTypeBox.Items.Add(parameterType[0]);
            }*/

            questionSelectionListBox.ValueMember = "ID";
            questionSelectionListBox.DisplayMember = "Question";
            questionSelectionListBox.DataSource = Database.questionTable;

            newDataTypeSelectionBox.DataSource = Database.instanceOfAllData;
            newDataTypeSelectionBox.DisplayMember = "Name";

            newParameterTypeBox.DataSource = Database.generatingParameterTypes;
            newParameterTypeBox.DisplayMember = "Name";
            newParameterTypeBox.SelectedIndex = -1;
            selectParameterBox.SelectedIndex = -1;
            newDataTypeSelectionBox.SelectedIndex = -1;
            
            dataTypesGrid.AllowUserToAddRows = false;
            assignedQuestionsToBeAskedDataGrid.AllowUserToAddRows = false;
            parametersGrid.AllowUserToAddRows = false;
            personsGrid.AllowUserToAddRows = false;

            sleepingParameterComboBox.DataSource =  Enum.GetValues(typeof(HeartRate.GeneratingParameterSleep));

            updatePatientGrid();
            updateSensorsGrid();
            updateAssignedQuestionListBox();
        }


        //Patients
        private void addPatient_Click(object sender, EventArgs e)
        {
            new Add_Person(this).ShowDialog();
        }
        private void deletePatient_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("[dbo].[SPdeletePatient]", sqlConnection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = (int)personsGrid.Rows[personsGrid.CurrentCell.RowIndex].Cells[0].Value;

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            updatePatientGrid();
        }
        public void updatePatientGrid()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
            SqlCommand cmd = new SqlCommand("SELECT id as Id, name as Name, surname as Surname, birthdate as Birthdate FROM dbo.users", sqlConnection);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable usersTable = new DataTable();
            sqlConnection.Open();
            da.Fill(usersTable);
            personsGrid.DataSource = usersTable;
            sqlConnection.Close();

            /* UI based solution
            Database.persons.Clear();
            for (int i = 0; i < usersTable.Rows.Count; i++)
            {
                Database.persons.Add(new Person((int)personsGrid.Rows[i].Cells[0].Value, (String)personsGrid.Rows[i].Cells[1].Value,
                                                (String)personsGrid.Rows[i].Cells[2].Value, (DateTime)personsGrid.Rows[i].Cells[3].Value));
            }*/

        }
        private void patientsGrid_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                updateSensorsGrid();
                updateAssignedQuestionListBox();
                updateGeneratingParameters();
            }
            catch
            { }
        }


        //Sensors
        private void addNewSensor_Click(object sender, EventArgs e)
        {
            try
            {
                int increment = 0;
                if (minHourDataComboBox.SelectedIndex == 0)
                {
                    increment = Int16.Parse(minHourDataTextBox.Text) * 60;
                }
                else if (minHourDataComboBox.SelectedIndex == 1)
                {
                    increment = Int16.Parse(minHourDataTextBox.Text) * 60 * 60;
                }

                Sensor newSensor = null;

                if (selectInputDataComboBox.SelectedIndex == 0)
                {
                    newSensor = ((Sensor)newDataTypeSelectionBox.SelectedItem).newSensorInstance(new TimeSimulator(new TimeSpan(0, 0, increment)), this);
                }
                else if (selectInputDataComboBox.SelectedIndex == 1)
                {
                    newSensor = ((Sensor)newDataTypeSelectionBox.SelectedItem).newSensorInstance(new TimeSimulator(selectionRangeForData, new TimeSpan(0, 0, increment)), this);
                }
                else if (selectInputDataComboBox.SelectedIndex == 2)
                {
                    newSensor = ((Sensor)newDataTypeSelectionBox.SelectedItem).newSensorInstance(new TimeSimulator(selectionRangeForData, Int16.Parse(dataCountForDataTextBox.Text)), this);
                }

                if (newSensor != null)
                {
                    Holder holder = new Holder();
                    holder.sensor = newSensor;

                    string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(holder.sensor);

                    //Write sensor to Sensors
                    SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
                    SqlCommand cmd1 = new SqlCommand("[dbo].[SPcreateSensor]", sqlConnection1);

                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.Add("@sensor", SqlDbType.NText).Value = jsonString;
                    cmd1.Parameters.Add("@userId", SqlDbType.Int).Value = (int)personsGrid.Rows[personsGrid.CurrentCell.RowIndex].Cells[0].Value;

                    sqlConnection1.Open();
                    //cmd1.ExecuteNonQuery();
                    int IdOfNewObject = (int)cmd1.ExecuteScalar();
                    sqlConnection1.Close();

                    // This solution was cancelled //Assign the created sensor to patient 
                    /*System.Data.SqlClient.SqlConnection sqlConnection2 = new System.Data.SqlClient.SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
                    System.Data.SqlClient.SqlCommand cmd2 = new System.Data.SqlClient.SqlCommand("[dbo].[SPassignSensorToPatient]", sqlConnection2);

                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.Add("@patientId", SqlDbType.Int).Value = (int)personsGrid.Rows[personsGrid.CurrentCell.RowIndex].Cells[0].Value;
                    cmd2.Parameters.Add("@sensorId", SqlDbType.Int).Value = IdOfNewObject;

                    sqlConnection2.Open();
                    cmd2.ExecuteNonQuery();
                    sqlConnection2.Close();*/

                    /* UI Based Solution
                    if (selectInputDataComboBox.SelectedIndex == 0)
                    {
                        Database.persons[personsGrid.CurrentCell.RowIndex].addNewDataType(((Sensor)newDataTypeSelectionBox.SelectedItem).newSensorInstance(new TimeSimulator(new TimeSpan(0, 0, increment))));
                    }
                    else if (selectInputDataComboBox.SelectedIndex == 1)
                    {
                        Database.persons[personsGrid.CurrentCell.RowIndex].addNewDataType(((Sensor)newDataTypeSelectionBox.SelectedItem).newSensorInstance(new TimeSimulator(selectionRangeForData, new TimeSpan(0, 0, increment))));
                    }
                    else if (selectInputDataComboBox.SelectedIndex == 2)
                    {
                        Database.persons[personsGrid.CurrentCell.RowIndex].addNewDataType(((Sensor)newDataTypeSelectionBox.SelectedItem).newSensorInstance(new TimeSimulator(selectionRangeForData, Int16.Parse(dataCountForDataTextBox.Text))));
                    }*/
                }
                updateSensorsGrid();
            }
            catch
            {
                MessageBox.Show(sender.ToString() + e.ToString(), "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void sensorDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataTypesGrid.CurrentCell != null)
                {
                    SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
                    SqlCommand cmd = new SqlCommand("[dbo].[SPdeleteSensor]", sqlConnection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = (int)dataTypesGrid.Rows[dataTypesGrid.CurrentCell.RowIndex].Cells[0].Value;

                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    //UI Based Solution
                    //Database.persons[personsGrid.CurrentCell.RowIndex].removeDataType(dataTypesGrid.CurrentCell.RowIndex);
                    updateSensorsGrid();
                }
            }
            catch { MessageBox.Show(sender.ToString() + e.ToString(), "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void updateSensorsGrid()
        {
            try
            {
                if (dataTypesGrid.Rows.Count != 0)
                {
                    dataTypesGrid.DataSource = null;
                }

                if (personsGrid.CurrentCell != null)
                {
                    SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getAssignedSensors(@user_id)", sqlConnection);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = (int)personsGrid.Rows[personsGrid.CurrentCell.RowIndex].Cells[0].Value;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable sensorsTable = new DataTable();
                    sqlConnection.Open();
                    dataAdapter.Fill(sensorsTable);
                    dataTypesGrid.DataSource = sensorsTable;
                    sqlConnection.Close();
                }
            }
            catch { }

            //UI Based Solution
            /*foreach (Data dataType in Database.persons[personsGrid.CurrentCell.RowIndex].dataTypesToBeGenerated)
            {
                dataTypesGrid.Rows.Add(dataType.getName());
            }*/
        }
        private void dataTypesGrid_SelectionChanged(object sender, EventArgs e)
        {
            updateGeneratingParameters();
            if (dataTypesGrid.CurrentCell == null || dataTypesGrid.CurrentCell.Selected == false)
            {
                parametersToolStripContainer.Enabled = false;
            }
            else
            {
                parametersToolStripContainer.Enabled = true;
            }

            sleepingParameterComboBox.SelectedIndex = Newtonsoft.Json.JsonConvert.DeserializeObject<Sensor>((string)dataTypesGrid.Rows[dataTypesGrid.CurrentCell.RowIndex].Cells[1].Value).sleepingParameter;
        }

        //Sensor Parameters
        private void addParameterButton_Click(object sender, EventArgs e)
        {
            //Database.persons[personsGrid.CurrentCell.RowIndex].generatingParameters.Add(selectParameterBox.Text);
            try
            {
                if (dataTypesGrid.Rows.Count != 0)
                {
                    if (personsGrid.CurrentCell != null)
                    {
                        SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
                        SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.sensors where @sensorId=Id", sqlConnection);

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@sensorId", SqlDbType.Int).Value = (int)dataTypesGrid.Rows[dataTypesGrid.CurrentCell.RowIndex].Cells[0].Value;

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable sensorsTable = new DataTable();
                        sqlConnection.Open();
                        dataAdapter.Fill(sensorsTable);

                        Holder holder = new Holder();
                        holder.sensor = Newtonsoft.Json.JsonConvert.DeserializeObject<Sensor>((String)sensorsTable.Rows[0][1]);
                        holder.sensor.addGeneratingParameter(new GeneratingParameterReadyToAssign(selectionRangeForParameter, ((GeneratingParameterDayLight)newParameterTypeBox.SelectedItem).newExerciseIntensityInstance((int)selectParameterBox.SelectedItem)));

                        SqlCommand cmd2 = new SqlCommand("[dbo].[SPupdateSensor]", sqlConnection);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@sensorId", SqlDbType.Int).Value = (int)dataTypesGrid.Rows[dataTypesGrid.CurrentCell.RowIndex].Cells[0].Value;
                        cmd2.Parameters.Add("@sensor", SqlDbType.NText).Value = Newtonsoft.Json.JsonConvert.SerializeObject(holder.sensor);
                        cmd2.ExecuteNonQuery();

                        sqlConnection.Close();
                    }
                }
            }
            catch { MessageBox.Show(sender.ToString() + e.ToString(), "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            updateSensorsGrid();
        }
        private void parameterDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Database.persons[personsGrid.CurrentCell.RowIndex].generatingParameters.RemoveAt(parametersGrid.CurrentCell.RowIndex);

                if (dataTypesGrid.Rows.Count != 0)
                {
                    if (personsGrid.CurrentCell != null)
                    {
                        SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
                        SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.sensors where @sensorId=Id", sqlConnection);

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@sensorId", SqlDbType.Int).Value = (int)dataTypesGrid.Rows[dataTypesGrid.CurrentCell.RowIndex].Cells[0].Value;

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable sensorsTable = new DataTable();
                        sqlConnection.Open();
                        dataAdapter.Fill(sensorsTable);

                        Holder holder = new Holder();
                        holder.sensor = Newtonsoft.Json.JsonConvert.DeserializeObject<Sensor>((String)sensorsTable.Rows[0][1]);

                        holder.sensor.deleteGeneratingParameter(parametersGrid.CurrentCell.RowIndex);
                        
                        SqlCommand cmd2 = new SqlCommand("[dbo].[SPupdateSensor]", sqlConnection);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@sensorId", SqlDbType.Int).Value = (int)dataTypesGrid.Rows[dataTypesGrid.CurrentCell.RowIndex].Cells[0].Value;
                        cmd2.Parameters.Add("@sensor", SqlDbType.NText).Value = Newtonsoft.Json.JsonConvert.SerializeObject(holder.sensor);
                        cmd2.ExecuteNonQuery();

                        sqlConnection.Close();
                    }
                }                

                updateGeneratingParameters();
                updateSensorsGrid();
            }
            catch { MessageBox.Show("Runtime Exception", "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void updateGeneratingParameters()
        {
            try
            {
                parametersGrid.Rows.Clear();
                sleepingParameterComboBox.Hide();
                sleepingParameterLabel.Hide();

                if (personsGrid.CurrentCell != null)
                {
                    if (dataTypesGrid.CurrentCell != null)
                    {
                        SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
                        SqlCommand cmd = new SqlCommand("SELECT * FROM sensors where @sensorId=Id", sqlConnection);

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@sensorId", SqlDbType.Int).Value = (int)dataTypesGrid.Rows[dataTypesGrid.CurrentCell.RowIndex].Cells[0].Value;

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable sensorsTable = new DataTable();
                        sqlConnection.Open();
                        dataAdapter.Fill(sensorsTable);
                        sqlConnection.Close();

                        Holder holder = new Holder();
                        holder.sensor = Newtonsoft.Json.JsonConvert.DeserializeObject<Sensor>((String)sensorsTable.Rows[0][1]);

                        if (holder.sensor.getGeneratingParametersList() != null)
                        {
                            foreach (GeneratingParameterReadyToAssign gpra in holder.sensor.getGeneratingParametersList())
                            {
                                parametersGrid.Rows.Add(gpra.generatingParameter.Name, gpra.generatingParameter.Value);
                            }
                        }
                        if(holder.sensor.GetType() == typeof(HeartRate))
                        {
                            sleepingParameterComboBox.Show();
                            sleepingParameterLabel.Show();
                        }
                    }
                }
            }
            catch { }

            /*UI Based Solution
            foreach (string parameter in Database.persons[personsGrid.CurrentCell.RowIndex].generatingParameters)
            {
                parametersGrid.Rows.Add(parameter);
            }*/
        }
        private void newParameterTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* UI Based Solution
            selectParameterBox.Items.Clear();
            string search = newParameterTypeBox.SelectedItem.ToString();
            for (int i = 0; i < Database.generatingParameterTypes.Count; i++)
            {
                if (search == Database.generatingParameterTypes[i][0])
                {
                    for (int j = 1; j < Database.generatingParameterTypes[i].Count; j++)
                    {
                        selectParameterBox.Items.Add(Database.generatingParameterTypes[i][j]);
                    }
                }
            }*/

            if (newParameterTypeBox.SelectedIndex != -1 && newParameterTypeBox.SelectedItem != null)
            {
                selectInputDataComboBox.SelectedIndex = -1;
                newDataTypeSelectionBox.SelectedIndex = -1;
                minHourDataComboBox.SelectedIndex = -1;
                dateIntervalForDataTextLabel.Text = "None";

                if (newParameterTypeBox.SelectedItem.GetType() == typeof(ExerciseIntensity))
                {
                    selectParameterBox.DataSource = Database.exerciseIntensityValues;
                    new CalendarForm(this, selectionRangeForParameter).ShowDialog();
                }
            }
        }
        private void sleepingParameterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataTypesGrid.Rows.Count != 0)
                {
                    if (personsGrid.CurrentCell != null)
                    {
                        SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
                        SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.sensors where @sensorId=Id", sqlConnection);

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@sensorId", SqlDbType.Int).Value = (int)dataTypesGrid.Rows[dataTypesGrid.CurrentCell.RowIndex].Cells[0].Value;

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable sensorsTable = new DataTable();
                        sqlConnection.Open();
                        dataAdapter.Fill(sensorsTable);

                        Holder holder = new Holder();
                        holder.sensor = Newtonsoft.Json.JsonConvert.DeserializeObject<Sensor>((String)sensorsTable.Rows[0][1]);
                        holder.sensor.sleepingParameter = (int)sleepingParameterComboBox.SelectedItem;

                        SqlCommand cmd2 = new SqlCommand("[dbo].[SPupdateSensor]", sqlConnection);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@sensorId", SqlDbType.Int).Value = (int)dataTypesGrid.Rows[dataTypesGrid.CurrentCell.RowIndex].Cells[0].Value;
                        cmd2.Parameters.Add("@sensor", SqlDbType.NText).Value = Newtonsoft.Json.JsonConvert.SerializeObject(holder.sensor);
                        cmd2.ExecuteNonQuery();

                        sqlConnection.Close();
                    }
                }
            }
            catch { MessageBox.Show(sender.ToString() + e.ToString(), "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        //Questions
        private void addQuestionToPersonButton_Click(object sender, EventArgs e)
        {
            try
            {
                int interval = 0;
                if (minHourQuComboBox.SelectedIndex == 0)
                {
                    interval = Int16.Parse(minHourInputQuTextBox.Text) * 60;
                }
                else if (minHourQuComboBox.SelectedIndex == 1)
                {
                    interval = Int16.Parse(minHourInputQuTextBox.Text) * 60 * 60;
                }
                /* UI based solution
                if (selectInputQuComboBox.SelectedIndex == 0)
                {
                    Database.persons[personsGrid.CurrentCell.RowIndex].addNewQuestion(new Question(questionSelectionListBox.SelectedIndex + 1, new TimeSimulator(new TimeSpan(0, 0, interval))));
                }
                else if (selectInputQuComboBox.SelectedIndex == 1)
                {
                    Database.persons[personsGrid.CurrentCell.RowIndex].addNewQuestion(new Question(questionSelectionListBox.SelectedIndex + 1, new TimeSimulator(selectionRangeForQuestion, new TimeSpan(0, 0, interval))));
                }
                else if (selectInputQuComboBox.SelectedIndex == 2)
                {
                    Database.persons[personsGrid.CurrentCell.RowIndex].addNewQuestion(new Question(questionSelectionListBox.SelectedIndex + 1, new TimeSimulator(selectionRangeForQuestion, Int16.Parse(dataCountForQuTextBox.Text))));
                }
                */

                Question newQuestion = null;

                if (selectInputQuComboBox.SelectedIndex == 0)
                {
                    newQuestion = new Question(questionSelectionListBox.SelectedIndex + 1, new TimeSimulator(new TimeSpan(0, 0, interval)));
                }
                else if (selectInputQuComboBox.SelectedIndex == 1)
                {
                    newQuestion = new Question(questionSelectionListBox.SelectedIndex + 1, new TimeSimulator(selectionRangeForQuestion, new TimeSpan(0, 0, interval)));
                }
                else if (selectInputQuComboBox.SelectedIndex == 2)
                {
                    newQuestion = new Question(questionSelectionListBox.SelectedIndex + 1, new TimeSimulator(selectionRangeForQuestion, Int16.Parse(dataCountForQuTextBox.Text)));
                }

                if (newQuestion != null)
                {
                    /*Newtonsoft.Json.JsonSerializerSettings set = new Newtonsoft.Json.JsonSerializerSettings();
                    set.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All;
                    set.Converters.Add(new KeysJsonConverter(typeof(Question), typeof(TimeSimulator), typeof(DateTime), typeof(SelectionRange), typeof(TimeSpan)));*/
                    string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(newQuestion);
                    //string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(newQuestion, new KeysJsonConverter(typeof(Question), typeof(TimeSimulator), typeof(DateTime), typeof(SelectionRange),typeof(TimeSpan)));

                    //Write sensor to Sensors
                    System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
                    System.Data.SqlClient.SqlCommand cmd1 = new System.Data.SqlClient.SqlCommand("[dbo].[SPassignQuestionToPatient]", sqlConnection1);

                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@questionId", SqlDbType.Int).Value = questionSelectionListBox.SelectedIndex + 1;
                    cmd1.Parameters.Add("@userId", SqlDbType.Int).Value = (int)personsGrid.Rows[personsGrid.CurrentCell.RowIndex].Cells[0].Value;
                    cmd1.Parameters.Add("@questionJSON", SqlDbType.NVarChar).Value = jsonString;

                    sqlConnection1.Open();
                    cmd1.ExecuteNonQuery();
                    sqlConnection1.Close();
                }

                updateAssignedQuestionListBox();
            }
            catch
            {
                MessageBox.Show("Runtime Exception", "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void deleteQuestionButton_Click(object sender, EventArgs e)
        {
            try
            {
                //UI based solution
                //Database.persons[personsGrid.CurrentCell.RowIndex].removeQuestion(assignedQuestionslistBox.SelectedIndex);
                if (dataTypesGrid.CurrentCell != null)
                {
                    System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("[dbo].[SPdeleteQuestionToBeAsked]", sqlConnection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = (int)personsGrid.Rows[personsGrid.CurrentCell.RowIndex].Cells[0].Value;
                    cmd.Parameters.Add("@questionId", SqlDbType.Int).Value = (int)assignedQuestionsToBeAskedDataGrid.Rows[assignedQuestionsToBeAskedDataGrid.CurrentCell.RowIndex].Cells[0].Value;

                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    //UI Based Solution
                    //Database.persons[personsGrid.CurrentCell.RowIndex].removeDataType(dataTypesGrid.CurrentCell.RowIndex);
                    updateAssignedQuestionListBox();
                }
            }
            catch { MessageBox.Show("Runtime Exception", "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void updateAssignedQuestionListBox()
        {
            if (assignedQuestionsToBeAskedDataGrid.Rows.Count != 0)
            {
                assignedQuestionsToBeAskedDataGrid.DataSource = null;
            }

            try
            {
                if (personsGrid.CurrentCell != null)
                {
                    SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
                    SqlCommand cmd = new SqlCommand("SELECT FK_questionId FROM dbo.questionsToBeAskedToEachPerson where @user_id = FK_userId", sqlConnection);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = (int)personsGrid.Rows[personsGrid.CurrentCell.RowIndex].Cells[0].Value;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable questionsToBeAskedTable = new DataTable();
                    sqlConnection.Open();
                    dataAdapter.Fill(questionsToBeAskedTable);

                    DataTable questionsToBeAskedTable2 = new DataTable();
                    for (int i = 0; i < questionsToBeAskedTable.Rows.Count; i++)
                    {
                        cmd = new SqlCommand("SELECT * FROM dbo.questions where @questionId=Id", sqlConnection);

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@questionId", SqlDbType.Int).Value = (int)questionsToBeAskedTable.Rows[i][0];

                        SqlDataAdapter dataAdapter2 = new SqlDataAdapter(cmd);
                        dataAdapter2.Fill(questionsToBeAskedTable2);

                        //assignedQuestionslistBox.Items.Add(questionsToBeAskedTable2.Rows[0][0]);
                    }
                    assignedQuestionsToBeAskedDataGrid.DataSource = questionsToBeAskedTable2;
                    sqlConnection.Close();
                }
            }
            catch { }

            /* UI based solution
            foreach (Question question in Database.persons[personsGrid.CurrentCell.RowIndex].questions)
            {
                assignedQuestionslistBox.Items.Add(question.getQuestionString(question.questionId));
            }*/
        }



        private void minHourDataSelectedIndexChanged(object sender, EventArgs e)
        {
            minOrHourLabel.Text = minHourDataComboBox.Text;
            minHourDataTextBox.Enabled = true;
        }

        private void assignSomethingToPersonBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addSomethingToPersonBox.SelectedIndex == 0)
            {
                toolStripContainer2.Hide();
                toolStripContainer2.SendToBack();
                toolStripContainer1.Show();

            }
            else if (addSomethingToPersonBox.SelectedIndex == 1)
            {
                toolStripContainer1.Hide();
                toolStripContainer1.SendToBack();
                toolStripContainer2.Show();
            }
        }

        private void generate_Click_1(object sender, EventArgs e)
        {
            isGenerate = true;
            DataGenerator dataGenerator = new DataGenerator(this);

            dataGenerator.createNewThreadForEachSensorInDataBase();
            dataGenerator.createNewThreadForEachPersonForQuestion();
            //UI based solution
            //dataGenerator.createNewThreadForEachPerson(Database.persons);
        }

        private void stopButton_Click_1(object sender, EventArgs e)
        {
            isGenerate = false;
        }

        //GUI related
        private void selectInputDataComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectInputDataComboBox.SelectedIndex != -1)
            {
                newParameterTypeBox.SelectedIndex = -1;
                selectParameterBox.SelectedIndex = -1;
            }


            if (selectInputDataComboBox.SelectedIndex == 0)
            {
                minHourDataComboBox.Enabled = true;
                timeLabal.Enabled = true;
                label1.Enabled = true;
                minHourDataTextBox.Enabled = true;
                enterDataCountLabel.Enabled = false;
                dataCountForDataTextBox.Enabled = false;
                /*dateIntervalForDataTimeLabel.ForeColor = Color.DarkGray;
                dateIntervalForDataTextLabel.ForeColor = Color.DarkGray;*/
            }
            else if (selectInputDataComboBox.SelectedIndex == 1)
            {
                label1.Enabled = true;
                timeLabal.Enabled = true;
                minHourDataTextBox.Enabled = true;
                minHourDataComboBox.Enabled = true;
                enterDataCountLabel.Enabled = false;
                dataCountForDataTextBox.Enabled = false;
                dateIntervalForDataTextLabel.Enabled = true;
                dateIntervalForDataTimeLabel.Enabled = true;
                new CalendarForm(this, selectionRangeForData).ShowDialog();
            }
            else if (selectInputDataComboBox.SelectedIndex == 2)
            {
                label1.Enabled = false;
                timeLabal.Enabled = false;
                minHourDataTextBox.Enabled = false;
                enterDataCountLabel.Enabled = true;
                minHourDataComboBox.Enabled = false;
                dataCountForDataTextBox.Enabled = true;
                dateIntervalForDataTextLabel.Enabled = true;
                dateIntervalForDataTimeLabel.Enabled = true;
                new CalendarForm(this, selectionRangeForData).ShowDialog();
            }
        }

        private void selectInputQuComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectInputQuComboBox.SelectedIndex == 0)
            {
                minHourQuComboBox.Enabled = true;
                askingRateLabel.Enabled = true;
                minHourInputQuTextBox.Enabled = true;
                dataCountForQuLabel.Enabled = false;
                dataCountForQuTextBox.Enabled = false;
                /*dateIntervalForQuTimeLabel.ForeColor = Color.DarkGray;
                dateIntervalForQuTextLabel.ForeColor = Color.DarkGray;*/
            }
            else if (selectInputQuComboBox.SelectedIndex == 1)
            {
                askingRateLabel.Enabled = true;
                minHourInputQuTextBox.Enabled = true;
                minHourQuComboBox.Enabled = true;
                dataCountForQuLabel.Enabled = false;
                dataCountForQuTextBox.Enabled = false;
                dateIntervalForQuTimeLabel.Enabled = true;
                dateIntervalForQuTextLabel.Enabled = true;
                new CalendarForm(this, selectionRangeForQuestion).ShowDialog();
            }
            else if (selectInputQuComboBox.SelectedIndex == 2)
            {
                askingRateLabel.Enabled = false;
                minHourQuComboBox.Enabled = false;
                dataCountForQuLabel.Enabled = true;
                minHourDataComboBox.Enabled = false;
                dataCountForQuTextBox.Enabled = true;
                dateIntervalForQuTextLabel.Enabled = true;
                dateIntervalForQuTimeLabel.Enabled = true;
                minHourInputQuTextBox.Enabled = false;
                new CalendarForm(this, selectionRangeForQuestion).ShowDialog();
            }
        }

        private void minHourComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            minHourInputQuTextBox.Enabled = true;
        }

        private void questionCountTextBox_Enter(object sender, EventArgs e)
        {
            if (dataCountForQuTextBox.Text == "Count")
            {              
                dataCountForQuTextBox.Clear();
                dataCountForQuTextBox.ForeColor = Color.Black;
            }
        }

        private void questionCountTextBox_Leave(object sender, EventArgs e)
        {
            if (dataCountForQuTextBox.Text == "")
            {
                dataCountForQuTextBox.ForeColor = Color.Gray;
                dataCountForQuTextBox.Text = "Count";
            }
        }

        private void dataCountForDataTextBox_Enter(object sender, EventArgs e)
        {
            if (dataCountForDataTextBox.Text == "Count")
            {
                dataCountForDataTextBox.Clear();
                dataCountForDataTextBox.ForeColor = Color.Black;
            }
        }

        private void dataCountForDataTextBox_Leave(object sender, EventArgs e)
        {
            if (dataCountForDataTextBox.Text == "")
            {
                dataCountForDataTextBox.ForeColor = Color.Gray;
                dataCountForDataTextBox.Text = "Count";
            }
        }
    }
}
