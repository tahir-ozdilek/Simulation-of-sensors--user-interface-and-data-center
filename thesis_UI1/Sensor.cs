using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace thesis_UI1
{
    [JsonConverter(typeof(BaseConverter))]
    abstract public class Sensor
    {
        protected Main_Form mainForm;

        public enum subClassTypes{ BloodSugar = 1, BloodPressure, HeartRate };

        public int subClassType { get; set; }

        abstract public int lastValue
        {
            get;
            set;
        }

        abstract public string Name
        {
            get;
            set;
        }

        abstract public int generate();

        //abstract public int getValue();

        abstract public TimeSimulator getTimeSimulator();

        abstract public string getName();

        abstract public Sensor newSensorInstance(TimeSimulator timeSimulator, Main_Form mainForm); //mainForm could be null. Be Careful.

        abstract public void addGeneratingParameter(GeneratingParameterReadyToAssign parameter);

        virtual public int sleepingParameter { set; get; } = 0;
        virtual public List<GeneratingParameterReadyToAssign> getGeneratingParametersList() { return null; }

        virtual public void deleteGeneratingParameter(int index) { }
    }
}
