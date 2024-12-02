using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric
{
    public class NumCount
    {
        private int num;
        private int count;
        
        public NumCount(int num, int count)
        {
            this.num = num;
            this.count = count;
        }
        public int GetNum()
        {
            return num;
        }
        public void SetNum(int value)
        {
            num = value;
        }
        public int GetCount()
        {
            return count;
        }
        public void SetCount(int value)
        {
            count = value;
        }
        public override string ToString()
        {
            return $"num  {num}  count {count}";
        }
    }

}
