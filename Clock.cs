using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric
{
    public class Clock
    {
        private int hour;
        private int minutes;

        public Clock(int hour, int minutes)
        {
            this.hour = hour;
            this.minutes = minutes;
        }

        public int GetHour()
        {
            return hour;
        }

        public int GetMinutes()
        {
            return minutes;
        }

        public void SetMinutes(int minutes)
        {
            this.minutes = minutes;
        }
        public void SetHour(int hours)
        {
            this.hour = hours;
        }

        public override string ToString()
        {
            return $"Hour is {this.hour}, Minutes is {this.minutes}";
        }
    }
    
}
