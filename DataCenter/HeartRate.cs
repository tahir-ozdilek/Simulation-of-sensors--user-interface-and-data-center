using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace thesis_UI1
{
    class HeartRate : Sensor
    {
        public enum GeneratingParameterSleep
        {
            None, LateMeal, LateWorkout, AlcoholBeforeSleep, ExhaustedDay
        }

        override public string Name { get; set; }

        override public int lastValue
        {
            get;
            set;
        } = -1;

        int upperLimit;
        int lowerLimit;
        //int lastValue;

        override public int sleepingParameter { set; get; } = (int)GeneratingParameterSleep.None;
        public int obligatoryParameterAge { get; set; }
        Random random = new Random();

        [JsonProperty(ItemIsReference = true)]
        private TimeSimulator timeSimulator;

        [JsonProperty(ItemIsReference = true)]
        private List<GeneratingParameterReadyToAssign> generatingParametersList = new List<GeneratingParameterReadyToAssign>();
        
        public HeartRate(TimeSimulator timeSimulator, DataCenter mainForm)
        {

        }

        enum outlook { Down = -1, Notr, Up };
        outlook outlookOfSensor = outlook.Notr;
        int downNotrBound = 10;
        int upNotrBound = 45;
        int outlookCounter = 0;
        int outlookEnd;

        override public int generate()
        {
           
                return 0;
        }

        override public Sensor newSensorInstance(TimeSimulator timeSimulator, DataCenter mainForm)
        {
            return new HeartRate(timeSimulator,mainForm);
        }

        override public TimeSimulator getTimeSimulator()
        {
            return timeSimulator;
        }

        override public string getName()
        {
            return Name;
        }

        override public void addGeneratingParameter(GeneratingParameterReadyToAssign parameter)
        {
            generatingParametersList.Add(parameter);
        }

        override public void deleteGeneratingParameter(int index)
        {
            generatingParametersList.RemoveAt(index);
        }

        override public List<GeneratingParameterReadyToAssign> getGeneratingParametersList()
        {
            return generatingParametersList;
        }

        /*override public int getValue()
        {
            return Value;
        }*/
    }
}
