using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric
{
    public class StationUsage
    {
        private string stationId;
        private int hoursUsed;

        // Constructor
        public StationUsage(string stationId, int hoursUsed)
        {
            this.stationId = stationId;
            this.hoursUsed = hoursUsed;
        }

        // Getters and Setters
        public string GetStationId()
        {
            return stationId;
        }

        public int GetHoursUsed()
        {
            return hoursUsed;
        }

        public void SetHoursUsed(int hoursUsed)
        {
            this.hoursUsed = hoursUsed;
        }

        // AddHours method
        public void AddHours(int hours)
        {
            this.hoursUsed += hours;
        }
    }
}
