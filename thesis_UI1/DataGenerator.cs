using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
//using Newtonsoft.Json;


namespace thesis_UI1
{
    public class DataGenerator
    {
        //Generator.SelectedGeneratingParameters generatingParameters;
        Main_Form mainForm;

        public DataGenerator(Main_Form mainForm)
        {
            this.mainForm = mainForm;
        }

        /*UI based solution
        public void createNewThreadForEachPerson(List<Person> persons)
        {
            foreach (Person person in persons)
            {
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += new DoWorkEventHandler(this.createNewThreadForEachDataGenerating);
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.WorkerReportsProgress = true;
                backgroundWorker.RunWorkerAsync(argument: person);

                BackgroundWorker backgroundWorkerQuestion = new BackgroundWorker();
                backgroundWorkerQuestion.DoWork += new DoWorkEventHandler(createNewThreadForEachPersonForQeustion);
                backgroundWorkerQuestion.WorkerSupportsCancellation = true;
                backgroundWorkerQuestion.WorkerReportsProgress = true;
                backgroundWorkerQuestion.RunWorkerAsync(argument: person);
            }
        }

        private void createNewThreadForEachDataGenerating(object sender, DoWorkEventArgs e)
        {
            Person person = (Person)e.Argument;

            foreach (Sensor dataType in person.dataTypesToBeGenerated)
            {
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += new DoWorkEventHandler(this.generateData);
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.WorkerReportsProgress = true;

                List<object> arguments = new List<object>();
                arguments.Add(person);
                arguments.Add(dataType);

                backgroundWorker.RunWorkerAsync(argument: arguments);
            }
        }*/

        public void createNewThreadForEachSensorInDataBase()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
            SqlCommand cmd = new SqlCommand("SELECT * FROM sensors", sqlConnection);

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter dataAdaptor = new SqlDataAdapter(cmd);
            DataTable sensorsTable = new DataTable();
            sqlConnection.Open();
            dataAdaptor.Fill(sensorsTable); 

            for (int i = 0; i < sensorsTable.Rows.Count; i++)
            {
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += new DoWorkEventHandler(this.generateData);
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.WorkerReportsProgress = true;

                Holder holder = new Holder();
                holder.sensor = Newtonsoft.Json.JsonConvert.DeserializeObject<Sensor>((String)sensorsTable.Rows[i][1]);

                SqlConnection sqlConnectionUser = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
                SqlCommand cmdUser = new SqlCommand("SELECT * FROM users where id=" + ((int)sensorsTable.Rows[i][2]).ToString(), sqlConnectionUser);
                cmdUser.CommandType = CommandType.Text;
                SqlDataAdapter dataAdaptorUser = new SqlDataAdapter(cmdUser);
                DataTable usersTable = new DataTable();

                sqlConnectionUser.Open();
                dataAdaptorUser.Fill(usersTable);
                sqlConnectionUser.Close();

                List<object> arguments = new List<object>();
                arguments.Add(new Person((int)sensorsTable.Rows[i][2], (String)usersTable.Rows[0][1],
                                         (String)usersTable.Rows[0][2], (DateTime)usersTable.Rows[0][3]));

                arguments.Add(holder.sensor);

                backgroundWorker.RunWorkerAsync(argument: arguments);
            }
            sqlConnection.Close();
        }


        static int dataCount = 0;
        private void generateData(object sender, DoWorkEventArgs e)
        {
            List<object> genericlist = e.Argument as List<object>;

            Person person = (Person)genericlist[0];
            Sensor sensor = (Sensor)genericlist[1];

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteApplication = new IPEndPoint(ipAddress, 9999);

            //List<int> newDataList = new List<int>();
            DataTable newDataTable = new DataTable();
            newDataTable.Columns.Add("data");
            newDataTable.Columns.Add("date");

            try
            {
                clientSocket.Connect(remoteApplication); //client socket will connect to server socket 
            }
            catch (Exception ex)
            {
                MessageBox.Show("socket.Connect(remoteApplication). Details:\n" + ex.ToString());
            }

            bool isContinue = true;
            while (isContinue == true && Main_Form.isGenerate)
            {
                isContinue = sensor.getTimeSimulator().increaseTheTimeBySeconds();

                Holder holder = new Holder();
                holder.sensor = sensor;
                //Thread.Sleep(200);

                if (isContinue == true && Main_Form.isGenerate)
                {
                    clientSocket.Send(Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(holder.sensor)));
                    //clientSocket.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<Data>(newData, new JsonSerializerOptions() { MaxDepth = 64 })));
                }
                else
                {
                    clientSocket.Send(Encoding.UTF8.GetBytes("#"));
                }

                byte[] messageReceivedByte = new Byte[1024];
                clientSocket.Receive(messageReceivedByte);


                int data = sensor.generate();
                newDataTable.Rows.Add(data, sensor.getTimeSimulator().currentDate);
                mainForm.BeginInvoke
                    (
                        new Action
                        (
                            () => mainForm.dataGrid.Rows.Add(dataCount, sensor.getTimeSimulator().currentDate, data)
                        )
                    );
                dataCount = Interlocked.Increment(ref dataCount);


                //TODO  write new data to file 
            }
            //clientSocket.Send(Encoding.UTF8.GetBytes("#"));
            clientSocket.Disconnect(false);
            clientSocket.Close();

            //TODO graph maybe
            mainForm.BeginInvoke
            (
                new Action
                (
                    () => new Graph(newDataTable).Show()
                )
            );     
        }
  
        public void createNewThreadForEachPersonForQuestion()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
            SqlCommand cmd = new SqlCommand("SELECT * FROM questionsToBeAskedToEachPerson", sqlConnection);

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter dataAdaptor = new SqlDataAdapter(cmd);
            DataTable usersQuestionsTable = new DataTable();
            sqlConnection.Open();
            dataAdaptor.Fill(usersQuestionsTable);

            for (int i = 0; i < usersQuestionsTable.Rows.Count; i++)
            {
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += new DoWorkEventHandler(this.generateQuestion);
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.WorkerReportsProgress = true;

                Holder holder = new Holder();
                holder.question = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>((String)usersQuestionsTable.Rows[i][2]);

                List<object> arguments = new List<object>();
                arguments.Add((int)usersQuestionsTable.Rows[i][0]); //personId
                arguments.Add(holder.question);

                backgroundWorker.RunWorkerAsync(argument: arguments);
            }
            sqlConnection.Close();

            /*UI Based Solution
            Person person = (Person)e.Argument;

            foreach (Question question in person.questions)
            {
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += new DoWorkEventHandler(this.generateQuestion);
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.WorkerReportsProgress = true;

                List<object> arguments = new List<object>();
                arguments.Add(person);
                arguments.Add(question);

                backgroundWorker.RunWorkerAsync(argument: arguments);
            }*/
        }
        
        static int questionCount = 0;
        private void generateQuestion(object sender, DoWorkEventArgs e)
        {
            List<object> genericlist = e.Argument as List<object>;

            int personId = (int)genericlist[0];
            Question question = (Question)genericlist[1];

            while (question.getTimeSimulator().increaseTheTimeBySeconds() == true && Main_Form.isGenerate)
            {
                Thread.Sleep(500);

                askQuestion(personId, question.questionId);

                /*mainForm.questionGeneratedListBox.BeginInvoke
                (
                    new Action
                    (
                        () => mainForm.questionGeneratedListBox.Items.Add("Count: " + questionCount.ToString() + " Name: " + person.getFullName() + "  " + question.getQuestion(question.questionId))
                    )
                );*/
                questionCount = Interlocked.Increment(ref questionCount);

                // TO DO  write newData to file.
            }
        }

        private void askQuestion(int userId, int questionId)
        {
            System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(@"Data Source=Dell;Initial Catalog = thesisDB;Integrated Security = true");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("[dbo].[SPaskQuestionToPatient]", sqlConnection);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@patientId", SqlDbType.Int).Value = userId;
            cmd.Parameters.Add("@questionId", SqlDbType.Int).Value = questionId;
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}