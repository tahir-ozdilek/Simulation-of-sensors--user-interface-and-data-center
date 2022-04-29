using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace thesis_UI1
{
    public class BloodSugar : Sensor
    {
        public struct generatingParameters
        {
            public SelectionRange timeIntervalForParameter;
            public int age;
            public int excerciseIntensity;  // percentage. 30-50 idle 50+ exercising.
            //(i.e. when sleeping) A normal heart rate can range anywhere from 40 to 100 beats per minute (BPM) 
            public generatingParameters(SelectionRange timeIntervalForParameter, int age, int excerciseIntensity)
            {
                this.timeIntervalForParameter = timeIntervalForParameter;
                this.age = age;
                this.excerciseIntensity = excerciseIntensity;
            }
        }
        override public string Name
        {
            get;
            set;
        }
        override public int lastValue
        {
            get;
            set;
        }

        int upperDeviation = 0;
        int lowerDeviation = 0;
        [JsonProperty(ItemIsReference = true)]
        private TimeSimulator timeSimulator;

        [JsonProperty(ItemIsReference = true)]
        private List<generatingParameters> generatingParametersList = new List<generatingParameters>();

        public BloodSugar(TimeSimulator timeSimulator, Main_Form mainForm)
        {
            this.timeSimulator = timeSimulator;
            this.mainForm = mainForm;
            Name = "Blood Sugar";
            //Value = 100; //default
            subClassType = (int)subClassTypes.BloodSugar;
        }

        override public int generate()
        {
            int value;
            Random random = new Random();

            foreach (generatingParameters generatingParameters in generatingParametersList)
            {
   
            }

            value = random.Next(1 + lowerDeviation, 100 + upperDeviation);

            return value;
        }

        override public Sensor newSensorInstance(TimeSimulator timeSimulator, Main_Form mainForm)
        {
            return new BloodSugar(timeSimulator, mainForm);
        }

        override public TimeSimulator getTimeSimulator()
        {
            return timeSimulator;
        }

        override public string getName()
        {
            return Name;
        }

        /*override public int getValue()
        {
            return Value;
        }*/

        override public void addGeneratingParameter(GeneratingParameterReadyToAssign parameter)
        {

        }
    }
}
