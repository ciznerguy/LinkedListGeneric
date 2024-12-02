using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric
{
    public class OrderList
    {
        private Node<NumCount> lst;

        public Node<NumCount> GetLst()
        {
            return lst;
        }

        public void SetLst(Node<NumCount> value)
        {
            lst = value;
        }
        public void InsertNum(int x)
        {
            if (lst == null)
            {
                // If the list is empty, create the first element
                lst = new Node<NumCount> ( new NumCount(x, 1));
            }
            else
            {
                Node<NumCount> curr = lst;
                while (curr.HasNext() && curr.GetNext().GetValue().GetNum() < x)
                {
                    curr = curr.GetNext();
                }
                curr = curr.GetNext();
                if (curr.GetValue().GetNum() == x)
                {
                    curr.GetValue().SetCount(curr.GetValue().GetCount() + 1);
                }
                else if (curr.GetValue().GetNum() > x)
                {
                    Node<NumCount> toAdd = new Node<NumCount>(new NumCount(x, 1), curr);
                    curr.SetNext( toAdd);
                }
                else
                {
                    curr.SetNext(new Node<NumCount>(new NumCount(x, 1), curr.GetNext()));
                }

            }
        }

    }
}
