using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric
{

    public class UsageTracker
    {
        private Node<StationUsage> head;

        // RecordUsage method
        public void RecordUsage(string stationId, int hours)
        {
            Node<StationUsage> currentNode = head;

            // Traverse the linked list to find the station with the given ID
            while (currentNode != null)
            {
                if (currentNode.GetStationId() == stationId)
                {
                    // If found, add the usage hours
                    currentNode.AddHours(hours);
                    return;
                }
                currentNode = currentNode.GetNext();
            }

            // If station not found, add a new node to the end of the list
            StationUsage newStationUsage = new StationUsage(stationId, hours);
            Node<StationUsage> newNode = new Node<StationUsage>(newStationUsage);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<StationUsage> lastNode = head;
                while (lastNode.GetNext() != null)
                {
                    lastNode = lastNode.GetNext();
                }
                lastNode.SetNext(newNode);
            }
        }
    }

}
