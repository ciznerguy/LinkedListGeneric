using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric
{

    public class Car
    {
        private string licenseNumber;
        private Node<Ticket> tickets = new Node<Ticket>(null);

        // בנאי
        public Car(string licenseNumber, Node<Ticket> tickets)
        {
            this.licenseNumber = licenseNumber;
            this.tickets = tickets;
        }

        // פעולה לחישוב סכום כולל של כל הדוחות שלא שולמו
        public double CalculateTotalUnpaidFines()
        {
            double totalUnpaidFines = 0;
            Node<Ticket> currentNode = tickets;
            while (currentNode != null)
            {
                Ticket ticket = currentNode.GetValue();
                if (!ticket.GetIsPaid())
                {
                    totalUnpaidFines += ticket.GetFineAmount();
                }
                currentNode = currentNode.GetNext();

            }
            return totalUnpaidFines;
        }

        // גטרים וסטרים
        public string GetLicenseNumber()
        {
            return licenseNumber;
        }

        public void SetLicenseNumber(string value)
        {
            licenseNumber = value;
        }

        public Node<Ticket> GetTickets()
        {
            return tickets;
        }

        public void SetTickets(Node<Ticket> value)
        {
            tickets = value;
        }
    }

    public class Ticket
    {
        private string violationDescription;
        private double fineAmount;
        private bool isPaid;

        // בנאי
        public Ticket(string violationDescription, double fineAmount, bool isPaid)
        {
            this.violationDescription = violationDescription;
            this.fineAmount = fineAmount;
            this.isPaid = isPaid;
        }

        // גטרים וסטרים
        public string GetViolationDescription()
        {
            return violationDescription;
        }

        public void SetViolationDescription(string value)
        {
            violationDescription = value;
        }

        public double GetFineAmount()
        {
            return fineAmount;
        }

        public void SetFineAmount(double value)
        {
            fineAmount = value;
        }

        public bool GetIsPaid()
        {
            return isPaid;
        }

        public void SetIsPaid(bool value)
        {
            isPaid = value;
        }
    }

}
