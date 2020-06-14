using System;
using System.Collections.Generic;
using System.Text;

namespace Task7
{
    public class Point      
    { 
        public double data;  //значение узла дерева
        public Point left;   //ссылка на левое поддерево
        public Point right;  //ссылка на правое поддерево

        //конструкторы
        public Point (double d)  
        {
            data = d;
            left = null;
            right = null;
        }
        public Point()
        {
            data = default;
            left = null;
            right = null;
        }

        public override string ToString()
        {
            return data.ToString() + " ";
        }
    }
}
