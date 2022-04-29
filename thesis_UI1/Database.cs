using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace thesis_UI1
{
    public class Database
    {
        static public List<Person> persons = new List<Person>();

        static public List<Sensor> instanceOfAllData = new List<Sensor>() { new BloodSugar(new TimeSimulator(new TimeSpan()),null),
                                                                            new BloodPressure(new TimeSimulator(new TimeSpan()),null),
                                                                            new HeartRate(new TimeSimulator(new TimeSpan()),null)};

        static public List<GeneratingParameterDayLight> generatingParameterTypes = new List<GeneratingParameterDayLight>()
        {
            new ExerciseIntensity(0)
        };
        static public List<int> exerciseIntensityValues = new List<int>() { 30,40,50,60,70,80,90,100 };


        /*static public List<List<string>> generatingParameterTypes = new List<List<string>>()
                                                                       { new List<string>() { "Season:", "spring", "summer", "autumn", "winter" },
                                                                         new List<string>() { "Sleepiness:", "sleepy", "nonSleepy" },
                                                                         new List<string>() { "Last Sleep Quality:", "poor", "wellSlept" },
                                                                         new List<string>() { "Hunger:", "hungry", "satiated" } };*/

        static public DataTable questionTable = new DataTable();

        public Database()
        {
            questionTable.Columns.Add("ID");
            questionTable.Columns.Add("Question");

            questionTable.Rows.Add(1, "How well did you sleep last night?");
            questionTable.Rows.Add(2, "Do you feel dizzy today?");
        }
    }
}
