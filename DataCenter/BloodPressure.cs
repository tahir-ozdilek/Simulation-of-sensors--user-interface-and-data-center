using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis_UI1
{
    public class BloodPressure : Sensor
    {
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
        private TimeSimulator timeSimulator;

        public BloodPressure(TimeSimulator timeSimulator, DataCenter mainForm)
        {
            this.timeSimulator = timeSimulator;
            this.mainForm = mainForm;
            Name = "Pressure";
            //Value = 100; // default
            subClassType = (int)subClassTypes.BloodPressure;
        }

        override public int generate()
        {
            int value =0;
            Random random = new Random();

            //foreach (string parameter in selectedParameters)
            {
               // if (parameter == "satiated")
                {
                    upperDeviation = random.Next(5, 15);
                }
            }
            //Value = random.Next(1 + lowerDeviation, 100 + upperDeviation);

            return value;
        }

        override public Sensor newSensorInstance(TimeSimulator timeSimulator, DataCenter mainForm)
        {
            return new BloodPressure(timeSimulator, mainForm);
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
