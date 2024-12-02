using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric
{
    using System;

    public class TavPlace
    {
        public char Tav { get; set; }
        public int Place { get; set; }

        public TavPlace(char tav, int place)
        {
            Tav = tav;
            Place = place;
        }
    }

}
