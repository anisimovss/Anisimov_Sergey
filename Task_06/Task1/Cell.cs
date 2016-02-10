using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Cell
    {
        public int Data { get; set; }
        public Cell Next { get; set; }

        public Cell()
        {
            Next = null;
        }

        public Cell(int newElement)
        {
            Data = newElement;
            Next = null;
        }
    }
}
