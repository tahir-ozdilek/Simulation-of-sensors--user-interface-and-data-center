using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

namespace thesis_UI1
{
    public class TimeSimulator
    {
        public TimeSpan dataUpdateTime;
        public SelectionRange selectionRange;
        public DateTime currentDate;

        public TimeSpan sleepStartTime = new TimeSpan(22,0,0);
        public TimeSpan sleepEndTime = new TimeSpan(6, 0, 0);
        public TimeSpan sleepLenght;
        public TimeSpan dayLightLenght;
        public bool isSleeping { set; get; }
        public int sleepDivider;
        public int sleepCounter = 0;

        public int dayLightDivider;
        public int dayLightCounter = 0;

        TimeSimulator() { }

        //Simulates according to given DATA UPDATE TIME INTERVAL PERMENENTLY
        public TimeSimulator(TimeSpan dataUpdateTime)
        {
            this.dataUpdateTime = dataUpdateTime;
            selectionRange = new SelectionRange();
            selectionRange.End = new DateTime(9999, 12, 30);

            currentDate = new DateTime();
            currentDate = DateTime.Now;
            calculateOtherTimeRelatedValues();
        }

        //Simulates according to given DATA UPDATE TIME DURING GIVEN INTERVAL
        public TimeSimulator(SelectionRange selectionRange, TimeSpan dataUpdateTime)
        {
            this.dataUpdateTime = dataUpdateTime;
            this.selectionRange = selectionRange;
            currentDate = selectionRange.Start;
            calculateOtherTimeRelatedValues();
        }

        //Simulates according to given NUMBER OF DATA DURING GIVEN INTERVAL
        public TimeSimulator(SelectionRange selectionRange, int numberOfData)
        {
            this.selectionRange = selectionRange;
            currentDate = selectionRange.Start;

            dataUpdateTime = new TimeSpan(0,0,(int)(selectionRange.End - selectionRange.Start).TotalSeconds / numberOfData);
            calculateOtherTimeRelatedValues();
        }

        void calculateOtherTimeRelatedValues()
        {
            //sleepLenght
            if (sleepStartTime < sleepEndTime)
            {
                sleepLenght = sleepEndTime - sleepStartTime;
            }
            else
            {
                sleepLenght = (new TimeSpan(23, 59, 59) - sleepStartTime) + sleepEndTime;
            }
            dayLightLenght = new TimeSpan(23, 59, 59) - sleepLenght;

            sleepDivider = (int)(sleepLenght.TotalSeconds / dataUpdateTime.TotalSeconds);
            dayLightDivider = (int)(dayLightLenght.TotalSeconds / dataUpdateTime.TotalSeconds);
        }

        public bool increaseTheTimeBySeconds()
        {
            currentDate += dataUpdateTime;

            //TODO şu saat kontolü doğru mu, test et. Test sonrası değiştirildi. Doğru sanki
            if ( (sleepStartTime.Hours < sleepEndTime.Hours &&  currentDate.Hour > sleepStartTime.Hours && currentDate.Hour < sleepEndTime.Hours) ||
                (sleepStartTime.Hours > sleepEndTime.Hours && (currentDate.Hour > sleepStartTime.Hours || currentDate.Hour < sleepEndTime.Hours) ))
            {
                isSleeping = true;
            }
            else
            {
                isSleeping = false;
            }


            if (sleepCounter < sleepDivider && isSleeping)
            {
                sleepCounter++;
            }
            else
            {
                sleepCounter = 0;
            }

            if (dayLightCounter < dayLightDivider && !isSleeping)
            {
                dayLightCounter++;
            }
            else
            {
                dayLightCounter = 0;
            }

            if (currentDate >= selectionRange.End)
                return false;
            else
                return true;
        }
    }
}
