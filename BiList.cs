using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric
{

    public class BiList
    {
        // Two linked lists representing the bi-directional list.
        private Node<int> lst1;
        private Node<int> lst2;

        // Constructor that initializes both linked lists as empty.
        public BiList()
        {
            lst1 = null;
            lst2 = null;
        }

        // Method to add a number to either lst1 or lst2 based on codeList.
        public void AddNum(int value, int codeList)
        {
            if (codeList == 1)
            {
                lst1 = new Node<int>(value, lst1);
            }
            else if (codeList == 2)
            {
                lst2 = new Node<int>(value, lst2);
            }
            else
            {
                Console.WriteLine("Error: Invalid codeList value. Must be 1 or 2.");

            }
        }

        // Method to print the list.
        public void PrintList(int codeList)
        {
            Node<int> current=null;
            if (codeList == 1)
            {
                current = lst1;
            }
            else if (codeList == 2)
            {
                current = lst2;
            }
            else
            {
                Console.WriteLine("error");
            }

            while (current != null)
            {
                Console.Write(current.GetValue() + " -> ");
                current = current.GetNext();
            }
            Console.WriteLine("null");
        }
    }

}
