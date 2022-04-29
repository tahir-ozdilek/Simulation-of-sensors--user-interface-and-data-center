using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis_UI1
{
    public class TimeSimulator
    {
        public short hourCurrent;
        public int minCurrent;
        private int secondCurrent;

        public short hourEnd;
        public short minEnd;

        int secondIncrementAmount;

        public TimeSimulator(int intervalSecond)
        {
            secondIncrementAmount = intervalSecond;
            if (secondIncrementAmount == 0)
                secondIncrementAmount = 1;
        }

        //Simulates according to given NUMBER OF DATA 
        public TimeSimulator(short hourStart, short hourEnd, short minStart, short minEnd, int numberOfData)
        {
            hourCurrent = hourStart;
            minCurrent = minStart;
            this.hourEnd = hourEnd;
            this.minEnd = minEnd;
            secondIncrementAmount = ((hourEnd - hourStart) * 60 * 60 + (minEnd - minStart) * 60) / numberOfData;
            if (secondIncrementAmount == 0)
                secondIncrementAmount = 1;
        }

        //Simulates according to given TIME INTERVAL
        public TimeSimulator(int intervalSecond, short hourStart, short hourEnd, short minStart, short minEnd)
        {
            hourCurrent = hourStart;
            minCurrent = minStart;
            this.hourEnd = hourEnd;
            this.minEnd = minEnd;
            secondIncrementAmount = intervalSecond;
            if (secondIncrementAmount == 0)
                secondIncrementAmount = 1;
        }

        public bool increaseTheTimeBySeconds()
        {
            //DateTime;
            secondCurrent += secondIncrementAmount;
            if (secondCurrent >= 60)
            {
                secondCurrent = (short)(secondCurrent % 60);
                minCurrent += secondIncrementAmount / 60;
            }
            if (minCurrent >= 60)
            {
                hourCurrent += (short)(minCurrent / 60);
                minCurrent = minCurrent % 60;
            }
            if (hourCurrent >= hourEnd && minCurrent >= minEnd)
                return true;
            else
                return false;
        }
        /*public bool increaseTheTimeByMinutes()
        {
            minCurrent =+minIncrementAmount;
            if (minCurrent >= 60)
            {
                hourCurrent++;
                minCurrent = minCurrent % 60;
            }

            if (hourCurrent >= hourEnd)
                return true;
            else
                return false;
        }*/
    }
}
