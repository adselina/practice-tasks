using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace Task10
{

    public class MyList
    {
        Point begin = null;

        public int Length
        {
            get
            {
                if (begin == null) return 0;
                int length = 0;
                Point p = begin;
                while (p != null)
                {
                    p = p.next;
                    length++;
                }
                return length;
            }
        }
        public Point End
        {
            get
            {
                if (begin == null) return begin;
                Point p = begin;
                while (p.next != null)
                {
                    p = p.next;

                }
                return p;
            }
        }
        public Point Begin
        {
            get { return begin; }
            set { begin = value; }
        }
        public MyList()
        {
            begin = null;
        } //пустой конструктор

        //добавить в конец
        public void Add(int d)
        {
            Point temp = new Point(d);
            if (begin == null)
            {
                begin = temp;
                return;
            }
            End.next = temp;
        }
     
        //проверка на неубывание
        public bool Increasing()
        {
            Point temp = begin;
            while (temp.next != null)
            {
                if (temp.data > temp.next.data)
                    return false;
                temp = temp.next;
            }
            return true;
        }

        //переворот
        public void Reverse()
        {
            if (!Increasing())
            {
                if (begin == null) return;

                Point previous = null;
                Point current = begin;
                Point newNext = null;

                while (current.next != null)
                {
                    newNext = current.next;
                    current.next = previous;
                    previous = current;
                    current = newNext;
                }

                current.next = previous;
                begin = current;

                Console.WriteLine("Список был перевернут");
            }
            else
            {
                Console.WriteLine("Последовательность неубывающая. Список не перевернут");
            }
            
        }

        //печать
        public void PrintList()
        {
            Console.WriteLine("");
            if (begin == null)
            {
                Console.WriteLine("Пустой список");
                Console.WriteLine("\n...Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                return;
            }
            Point p = begin;
            while (p != null)
            {
                Console.Write(p + " ");
                p = p.next;
            }
            Console.WriteLine("\n...Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }                
    }
}
