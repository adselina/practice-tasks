using System;
using System.Collections.Generic;
using System.Text;

namespace Task10
{
    public class Point
    {
        public int data;
        public Point next;
        Random rnd = new Random();

        public Point()
        {
            data = default;
            next = null;
        }

        public Point(bool ok)
        {
            data = rnd.Next(10);
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
