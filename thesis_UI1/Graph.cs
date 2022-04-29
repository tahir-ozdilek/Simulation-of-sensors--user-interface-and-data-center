using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace thesis_UI1
{
    public partial class Graph : Form
    {
        public Graph(DataTable newDataTable)
        {
            InitializeComponent();

            //chart1.Series.Clear();
            chart1.DataSource = newDataTable;
            //chart1.Series["data"].XValueMember = "data";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chart1.Series["data"].YValueMembers = "data";
            chart1.Series["data"].XValueMember = "date";
            chart1.Update();
            //Series series1 = new Series("Data");
            //series1.Points.DataBindY(array);
            //series1.ChartType = SeriesChartType.Line;
            //chart1.Series.Add(series1);
        }
    }
}
