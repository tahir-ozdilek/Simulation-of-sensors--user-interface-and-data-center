using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;
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
        
        public HeartRate(TimeSimulator timeSimulator, Main_Form mainForm)
        {
            this.timeSimulator = timeSimulator;
            this.mainForm = mainForm;
            Name = "HeartRate";
            subClassType = (int)subClassTypes.HeartRate;
            if(mainForm != null)
            {
                obligatoryParameterAge = (DateTime.Today - (DateTime)mainForm.personsGrid.Rows[mainForm.personsGrid.CurrentCell.RowIndex].Cells[3].Value).Days / 365;
            }

            lowerLimit = (int)((float)(220 - obligatoryParameterAge) * 0.3);
            upperLimit = (220 - obligatoryParameterAge);
            //Exercise rate is assumed between 40 and 60 for initial value , which is supposed to be RHR, resting heart rate
            lastValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 0.4), (int)((float)(220 - obligatoryParameterAge) * 0.6));
        }

        enum outlook { Down = -1, Notr, Up };
        outlook outlookOfSensor = outlook.Notr;
        int downNotrBound = 10;
        int upNotrBound = 45;
        int outlookCounter = 0;
        int outlookEnd;

        int dayLightDecremantDeviation = -1000;
        int dayLightIncremantDeviation = -1000;


        override public int generate()
        {
            /*  Max Heart Rate Equation
                MHR = 220 - Age

                Target Heart Rate Formula(Basic)
                THR = MHR * % Intensity
            
                THR = Target Heart Rate
                MHR = Maximum Heart Rate
                RHR = Resting Heart Rate
                bpm = Beats Per Minute      */
            int localMin;
            int localMax;

            if (timeSimulator.isSleeping)
            {
                int sleepDecremantDeviation = (lastValue - lowerLimit) / timeSimulator.sleepDivider;
                int sleepIncremantDeviation = (upperLimit - lastValue) / timeSimulator.sleepDivider;
                if (sleepDecremantDeviation < 4)
                {
                    sleepDecremantDeviation = 4;
                }
                if (sleepIncremantDeviation < 4)
                {
                    sleepIncremantDeviation = 4;
                }

                switch (sleepingParameter)
                {
                    case (int)GeneratingParameterSleep.None:
                        //The Hammock Pattern
                        if (timeSimulator.sleepCounter  < timeSimulator.sleepDivider / 2)
                        {
                            if(lastValue > (int)((float)(220 - obligatoryParameterAge) * 0.3))
                            {
                                Binomial binomialTimeRandomizer = new Binomial(0.6, 10);
                                int increaseOrReduce = binomialTimeRandomizer.Sample();
                                if (increaseOrReduce > 5)
                                {
                                    lastValue = random.Next(lastValue - sleepDecremantDeviation, lastValue);
                                }
                                else
                                {
                                    lastValue = random.Next(lastValue, lastValue + new Random().Next(2, 5));
                                }
                            }
                            else
                            {
                                lastValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 0.3) - new Random().Next(2, 5), (int)((float)(220 - obligatoryParameterAge) * 0.3) + new Random().Next(2, 5));
                            }
                        }
                        else if(timeSimulator.sleepCounter > timeSimulator.sleepDivider / 2 )
                        {
                            if (lastValue < (int)((float)(220 - obligatoryParameterAge) * 0.7))
                            {
                                Binomial binomialTimeRandomizer = new Binomial(0.6, 10);
                                int increaseOrReduce = binomialTimeRandomizer.Sample();
                                if (increaseOrReduce > 5)
                                {
                                    lastValue = random.Next(lastValue, lastValue + sleepIncremantDeviation);
                                }
                                else
                                {
                                    lastValue = random.Next(lastValue - new Random().Next(2, 5), lastValue);
                                }
                            }
                            else
                            {
                                lastValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 0.45), (int)((float)(220 - obligatoryParameterAge) * 0.55));
                            }
                        }
                        break;
                    case (int)GeneratingParameterSleep.AlcoholBeforeSleep:
                    case (int)GeneratingParameterSleep.LateMeal:
                    case (int)GeneratingParameterSleep.LateWorkout:
                        //Downward Slope Pattern
                        /*if (sleepCounter < 1 && lastValue < (int)((float)(220 - obligatoryParameterAge) * 0.6))
                        {
                            localMax = random.Next(lastValue, (int)((float)(220 - obligatoryParameterAge) * 0.7));
                            lastValue = random.Next(lastValue, localMax);
                        }
                        else */if(timeSimulator.sleepCounter < (int)((float)timeSimulator.sleepDivider * 4.0/5.0 ) && lastValue > (int)((float)(220 - obligatoryParameterAge) * 0.3))
                        {

                            /*if(random.Next(1, 6) != 1) 
                            {*/
                            localMin = (int)(lastValue - (float)(lastValue - lowerLimit) / (float)timeSimulator.sleepDivider);//random.Next(, lastValue);
                            if(localMin< lastValue)
                            {
                                lastValue = random.Next(localMin, lastValue);
                            }
                            else
                            {
                                lastValue = random.Next(lastValue - 5, lastValue + 5);
                            }
                            /*}
                            else //small random increment by the probability of 1/5
                            {
                                lastValue = random.Next(lastValue, lastValue + 7);
                            }*/
                        }
                        /*else if (sleepCounter < sleepDivider && lastValue < (int)((float)(220 - obligatoryParameterAge) * 0.6))
                        {
                            localMax = random.Next(lastValue, (int)((float)(220 - obligatoryParameterAge) * 0.7));
                            lastValue = random.Next(lastValue, localMax);
                        }*/
                        else if(lastValue > (int)((float)(220 - obligatoryParameterAge) * 0.3))
                        {
                            lastValue = random.Next(lastValue-5 , lastValue + 5);
                        }
                        else if (lastValue <= (int)((float)(220 - obligatoryParameterAge) * 0.3))
                        {
                            lastValue = random.Next(lastValue, lastValue + 5);
                        }
                        break;
                    case (int)GeneratingParameterSleep.ExhaustedDay:
                        //Hill Pattern
                        if (timeSimulator.sleepCounter < timeSimulator.sleepDivider / 2 &&
                            lastValue < (int)((float)(220 - obligatoryParameterAge) * 0.8))
                        {
                            localMax = random.Next(lastValue, lastValue - (lastValue - lowerLimit) / timeSimulator.sleepDivider);
                            lastValue = random.Next(lastValue, localMax);
                        }
                        else if (timeSimulator.sleepCounter > timeSimulator.sleepDivider / 2 && timeSimulator.sleepCounter < timeSimulator.sleepDivider / 3 * 4 &&
                                 lastValue > (int)((float)(220 - obligatoryParameterAge) * 0.3))
                        {
                            localMin = random.Next(lastValue - (lastValue - lowerLimit) / timeSimulator.sleepDivider, lastValue);
                            lastValue = random.Next(localMin, lastValue);
                        }
                        else if (timeSimulator.sleepCounter > (int)((float)timeSimulator.sleepDivider / 3.0*4.0) && timeSimulator.sleepCounter < timeSimulator.sleepDivider 
                                 && lastValue > (int)((float)(220 - obligatoryParameterAge) * 0.3))
                        {
                            localMax = random.Next(lastValue - (lastValue - lowerLimit) / timeSimulator.sleepDivider, lastValue);
                            lastValue = random.Next(lastValue, localMax);
                        }
                        else
                        {
                            lastValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 0.6) - 5, (int)((float)(220 - obligatoryParameterAge) * 0.6) + 5);
                        }
                        break;
                    default:
                        break;
                }
                return lastValue;
            }
            else // if awake
            { 
                foreach (GeneratingParameterReadyToAssign parameter in generatingParametersList)
                {
                    if (parameter.timeIntervalForParameter.Start > timeSimulator.currentDate &&
                        parameter.timeIntervalForParameter.End < timeSimulator.currentDate)
                    {
                        if(parameter.GetType() == typeof(ExerciseIntensity))
                        {
                            if(lastValue < (int)((float)(220 - obligatoryParameterAge) / 100.0 * parameter.generatingParameter.Value))
                            {
                                localMax = random.Next(lastValue, upperLimit);
                                lastValue = random.Next(lastValue, localMax);
                                return lastValue;
                            }
                            else
                            {
                                localMin = random.Next(lowerLimit, lastValue);
                                lastValue = random.Next(localMin, lastValue);
                                return lastValue;
                            }
                        }
                    }
                }

                Binomial binomialOutlookRandomizer = new Binomial(0.5, 100);
                int outlookRandomizer = binomialOutlookRandomizer.Sample();

                if (outlookCounter == 0)
                {
                    if (downNotrBound < outlookRandomizer && outlookRandomizer < upNotrBound)
                    {
                        outlookOfSensor = outlook.Notr;
                    }
                    else
                    {
                        if (outlookRandomizer < downNotrBound)
                        {
                            outlookOfSensor = outlook.Down;
                            Binomial binomialTimeRandomizer = new Binomial(0.3, 60);
                            outlookEnd = (int)(new TimeSpan(0, binomialOutlookRandomizer.Sample(), 0).TotalSeconds / timeSimulator.dataUpdateTime.TotalSeconds);
                            //TODO downNotrBound'u küçült, ama ertesi gün olduğunda defaul 40 ye geri çekmen lazım
                        }
                        else if (upNotrBound < outlookRandomizer)
                        {
                            outlookOfSensor = outlook.Up;
                            Binomial binomialTimeRandomizer = new Binomial(0.7, 60);
                            outlookEnd = (int)(new TimeSpan(0, binomialOutlookRandomizer.Sample(), 0).TotalSeconds / timeSimulator.dataUpdateTime.TotalSeconds) * 5;
                            //TODO upNotrBound'u büyüt, ama ertesi gün olduğunda defaul 60 e geri çekmen lazım
                        }

                        if(outlookEnd == 0)
                        {
                            outlookEnd = 1;
                        }

                        dayLightDecremantDeviation = (lastValue - lowerLimit) / outlookEnd;
                        dayLightIncremantDeviation = (upperLimit - lastValue) / outlookEnd;
                        if (dayLightDecremantDeviation < 4)
                        {
                            dayLightDecremantDeviation = 4;
                        }
                        if (dayLightIncremantDeviation < 4)
                        {
                            dayLightIncremantDeviation = 4;
                        }
                    }
                }

                if (outlookOfSensor == outlook.Notr)
                {
                    lastValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 0.45), (int)((float)(220 - obligatoryParameterAge) * 0.55));
                }
                else if (outlookOfSensor == outlook.Up)
                {
                    if (outlookCounter >= outlookEnd )
                    {
                        outlookOfSensor = outlook.Notr;
                        outlookCounter = 0;
                    }

                    if (outlookCounter >= outlookEnd / 2)
                    {
                        if (lastValue > (int)((float)(220 - obligatoryParameterAge) * 0.3))
                        {
                            Binomial binomialTimeRandomizer = new Binomial(0.6, 10);
                            int increaseOrReduce = binomialTimeRandomizer.Sample();
                            if (increaseOrReduce > 5)
                            {
                                lastValue = random.Next(lastValue - dayLightDecremantDeviation, lastValue);
                            }
                            else
                            {
                                lastValue = random.Next(lastValue, lastValue + new Random().Next(2, 5));
                            }
                        }
                        else
                        {
                            lastValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 0.35) - new Random().Next(2, 5), (int)((float)(220 - obligatoryParameterAge) * 0.35) + new Random().Next(2, 5));
                        }
                    }
                    else
                    {
                        if (lastValue < (int)((float)(220 - obligatoryParameterAge) * 1.0))
                        {
                            Binomial binomialTimeRandomizer = new Binomial(0.6, 10);
                            int increaseOrReduce = binomialTimeRandomizer.Sample();
                            if (increaseOrReduce > 5)
                            {
                                lastValue = random.Next(lastValue, lastValue + dayLightIncremantDeviation);
                            }
                            else
                            {
                                lastValue = random.Next(lastValue - new Random().Next(2, 5), lastValue);
                            }
                        }
                        else
                        {
                            lastValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 0.9), (int)((float)(220 - obligatoryParameterAge) * 1.00));
                        }
                    }
                    outlookCounter++;
                }
                else if (outlookOfSensor == outlook.Down)
                {
                    if (outlookCounter >= outlookEnd)
                    {
                        outlookOfSensor = outlook.Notr;
                        outlookCounter = 0;
                    }

                    if (outlookCounter >= outlookEnd / 2)
                    {
                        if (lastValue < (int)((float)(220 - obligatoryParameterAge) * 1.0))
                        {
                            Binomial binomialTimeRandomizer = new Binomial(0.6, 10);
                            int increaseOrReduce = binomialTimeRandomizer.Sample();
                            if (increaseOrReduce > 5)
                            {
                                lastValue = random.Next(lastValue, lastValue + dayLightIncremantDeviation);
                            }
                            else
                            {
                                lastValue = random.Next(lastValue - new Random().Next(2, 5), lastValue);
                            }
                        }
                        else
                        {
                            lastValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 0.9), (int)((float)(220 - obligatoryParameterAge) * 1.00));
                        }
                    }
                    else
                    {
                        if (lastValue > (int)((float)(220 - obligatoryParameterAge) * 0.35))
                        {
                            Binomial binomialTimeRandomizer = new Binomial(0.6, 10);
                            int increaseOrReduce = binomialTimeRandomizer.Sample();
                            if (increaseOrReduce > 5)
                            {
                                lastValue = random.Next(lastValue - dayLightDecremantDeviation, lastValue);
                            }
                            else
                            {
                                lastValue = random.Next(lastValue, lastValue + new Random().Next(2, 5));
                            }
                        }
                        else
                        {
                            lastValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 0.35) - new Random().Next(2, 5), (int)((float)(220 - obligatoryParameterAge) * 0.35) + new Random().Next(2, 5));
                        }
                    }
                    outlookCounter++;
                }

                /* Binomial binomialGenerator = new Binomial(0.5, 10);
                int aRandomNumber = binomialGenerator.Sample();
                int newValue;

                if(3 < aRandomNumber && aRandomNumber < 7)
                {
                    if(lastValue > (int)((float)(220 - obligatoryParameterAge) * 0.5))
                    {
                        newValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 0.5), lastValue);
                    }
                    else
                    {
                        newValue = random.Next(lastValue, (int)((float)(220 - obligatoryParameterAge) * 0.5));
                    }
                }
                else if(3 == aRandomNumber || aRandomNumber == 7)
                {
                    if (lastValue > (int)((float)(220 - obligatoryParameterAge) * 0.6))
                    {
                        newValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 0.6), lastValue);
                    }
                    else
                    {
                        newValue = random.Next(lastValue, (int)((float)(220 - obligatoryParameterAge) * 0.6));
                    }
                }
                else if (2 == aRandomNumber || aRandomNumber == 8)
                {
                    if (lastValue > (int)((float)(220 - obligatoryParameterAge) * 0.7))
                    {
                        newValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 0.7), lastValue);
                    }
                    else
                    {
                        newValue = random.Next(lastValue, (int)((float)(220 - obligatoryParameterAge) * 0.7));
                    }
                }
                else if (1 == aRandomNumber || aRandomNumber == 9)
                {
                    if (lastValue > (int)((float)(220 - obligatoryParameterAge) * 0.8))
                    {
                        newValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 0.8), lastValue);
                    }
                    else
                    {
                        newValue = random.Next(lastValue, (int)((float)(220 - obligatoryParameterAge) * 0.8));
                    }
                }
                else
                {
                    if (lastValue > (int)((float)(220 - obligatoryParameterAge) * 1.0))
                    {
                        newValue = random.Next((int)((float)(220 - obligatoryParameterAge) * 1.0), lastValue);
                    }
                    else
                    {
                        newValue = random.Next(lastValue, (int)((float)(220 - obligatoryParameterAge) * 1.0));
                    }
                }*/
 
                return lastValue;
            }
        }

        override public Sensor newSensorInstance(TimeSimulator timeSimulator, Main_Form mainForm)
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
