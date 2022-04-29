using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace thesis_UI1
{
    public partial class DataCenter : Form
    {
        static IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
        IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 9999);
        Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        Socket clientSocket = default(Socket);
        BackgroundWorker backgroundWorker = new BackgroundWorker();

        public DataCenter()
        {
            InitializeComponent();

            backgroundWorker.DoWork += new DoWorkEventHandler(startListening);
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.RunWorkerAsync();
        }

        public void startListening(object sender, DoWorkEventArgs e)
        {
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);        //Supportss 10 different clients
                Invoke(new Action(() =>
                {
                    logBox.Items.Add("Listening all IP's at 9999 port");
                    logBox.SelectedIndex = logBox.Items.Count - 1;
                }));

                while (true)   //we wait for a connection
                {
                    clientSocket = listener.Accept();

                    new multiClientHandler(clientSocket, this);
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Exception when trying to start listening:");
                    MessageBox.Show(ex.ToString());
                }));
            }
            clientSocket.Close();
            listener.Close();
        }
    }
 
    public class multiClientHandler
    {
        BackgroundWorker backgroundWorker = new BackgroundWorker(); // gui wont freeze with this worker 
        DataCenter dataCenter;
        Socket seperateSocketForEachRequest;
        public multiClientHandler(Socket clientSocket, DataCenter dataCenter)
        {
            this.seperateSocketForEachRequest = clientSocket;
            this.dataCenter = dataCenter;
            backgroundWorker.DoWork += new DoWorkEventHandler(multipleAnswer);   //backgroundworker will use listensocket method
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.RunWorkerAsync();
        }

        static int count = 0;
        public void multipleAnswer(object sender, DoWorkEventArgs e)
        {
            string stringMessage = "";

            while (stringMessage != "#")
            {
                byte[] byteMessage = new Byte[1024];
                try
                {
                    seperateSocketForEachRequest.Receive(byteMessage);
                }
                catch (Exception ex)
                {

                    dataCenter.Invoke(new Action(() =>
                    {
                        dataCenter.logBox.Items.Add("Error when receiving data. Exception details:" + ex.ToString());
                    }));
                }
                seperateSocketForEachRequest.Send(Encoding.UTF8.GetBytes("F"));
                
                stringMessage = Encoding.UTF8.GetString(byteMessage);

                dataCenter.Invoke(new Action(() =>
                {
                    dataCenter.logBox.Items.Add("Received: " + count++);
                }));

                stringMessage = stringMessage.Substring(0, stringMessage.IndexOf('\0'));
                if(stringMessage != "#")
                {

                    //BloodSugar message = JsonSerializer.Deserialize<BloodSugar>(stringMessage);
                    //Data message = Newtonsoft.Json.JsonConvert.DeserializeObject<Data>(stringMessage);
                    Holder holder = new Holder();
                    holder.sensor = Newtonsoft.Json.JsonConvert.DeserializeObject<Sensor>(stringMessage);

                    dataCenter.Invoke(new Action(() =>
                    {
                        dataCenter.dataGrid.Rows.Add(holder.sensor.getName(), holder.sensor.lastValue);
                    }));
                }
            }

            seperateSocketForEachRequest.Disconnect(true);
            seperateSocketForEachRequest.Close();
        }
    }
}
