using System;

namespace Task19
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
        }                          //пустой конструктор
        public MyList(int size)
        {

            begin = new Point();
            Point p = begin;
            for (int i = 1; i < size; i++)
            {
                Point temp = new Point();
                p.next = temp;
                p = temp;
            }
        }                  //контруктор для создания листа по размеру
        public MyList(params int[] mas)
        {
            begin = new Point();
            begin.data = mas[0];
            Point p = begin;
            Point temp = new Point();
            for (int i = 1; i < mas.Length; i++)
            {

                temp.data = mas[i];
                p.next = temp;

                p = p.next;
            }
            p.next = null;
        }          //контруктор для создания листа по массиву

        public void Add(int d)
        {
            //добавление в конец
            if (d < 0)
            {
                Point temp = new Point(d);
                if (begin == null)
                {
                    begin = temp;
                    return;
                }
                End.next = temp;
            }
            //добавление в начало
            else if (d > 0)
            {
                Point temp = new Point(d);
                if (begin == null)
                {
                    begin = temp;
                    return;
                }
                temp.next = begin;
                begin = temp;
            }
            //нулевой элемент
            else
            {
                Point p = begin;
                while (p.next != null && p.next.data > 0)
                {
                    p = p.next;
                }
                Point newPoint = new Point(d);

                if (p.next != null)
                {
                    newPoint.next = p.next;
                    p.next = newPoint;
                    return;
                }
                
                
                    p.next = newPoint;
                

            }
        }
       
        public bool FindElement(int key)
        {
            if (this.Length == 0)
            {
                Console.WriteLine("Список пустой");
                return false;
            }                                //пустой список

            if (this.Length == 1)
            {
                 if (begin.data == key)
                {
                    return true;
                }
                 else { return false; }
            }

            Point p = begin;
            while (p.next != null && p.data != key)
            {
                p = p.next;
            }

            if (p.next == null)
            {
                return false;
            }

            return true;
        }       //поиск элемента по ключу
        public void RemoveKey(int key)
        {
            if (this.Length == 0)
            {
                Console.WriteLine("Список пустой");
                return;
            }                                //пустой список

            if (Length == 1 && Begin.data.Equals(key))
            {
                begin = null;
                Console.WriteLine("Единственный элемент был удален");
                return;
            }           //один элемент и он = ключ
            if (Length == 1 && !Begin.data.Equals(key))
            {
                Console.WriteLine("Элемента нет в списке");
                return;
            }          //один элемент и он != ключ

            if (Begin.data.Equals(key))
            {
                begin = begin.next;
                return;
            }                          //первый элемент = ключ

            Point p = begin;
            while (p.next.next != null && !p.next.data.Equals(key)) //пока следующий элемент не последний или следующий элемент !=ключ
                p = p.next;

            if (!p.next.data.Equals(key))
            {
                Console.WriteLine("Элемента нет в списке");
                return;
            }                        //если следующий элемент != ключ -> элемента нет

            p.next = p.next.next;                                   //если следующий элемент = ключ -> удаление этого элемента
        }         //удаление элемента по ключу

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
        }                //печать
    }
}
