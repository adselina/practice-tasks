using System;
using System.Collections.Generic;
using System.Text;

namespace Task19
{
    public class Point
    {
        public int data;
        public Point next;

        public Point()
        {
            data = default;
            next = null;
        }

        public Point(int d)
        {
            data = d;
            next = null;
        }

        public override string ToString()
        {
            return data.ToString() + " ";
        }
    }
}
