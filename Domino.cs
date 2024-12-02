using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric
{
    public class Domino
    {
        private int left;
        private int right;

        public Domino (int left, int right)
        {
            this.left = left;
            this.right = right;
        }

        // פעולה בונה רנדומלית

        public Domino ()
        {   
            Random rand = new Random();
            this.left = rand.Next(0, 7);
            this.right = rand.Next(0, 7);
        }

        public Domino (Domino other)
        {
            this.left = other.left;
            this.right = other.right;
        }

        public int GetLeft()
        {
            return left;
        }

        public int GetRight ()
        {
            return right;
        }
        //הוספת פעולה שמחזירה סכום של אבן דומינו
        public int GetSum()
        {
            return this.left+ this.right;
        }

         public override string ToString()
        {
            return $"[{left}|{right}]";

        }
    }
}
