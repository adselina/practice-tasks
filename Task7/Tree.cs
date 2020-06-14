using System;
using System.Collections.Generic;
using System.Linq;


namespace Task7
{
    public class Tree
    {
        public SortedDictionary<string, double> CodesOfLeaves = new SortedDictionary<string, double>(); //список с кодовыми словами символов алфавита
        public string word = "";  //кодовое слово для символа
        public Point root = null; //корень
        //пустой конструктор
        public Tree()
        {
            root = null;
        }                                         


        //печать поддерьвьев
        private void ShowTree(Point p, int l)
        {
            if (p != null)
            {
                ShowTree(p.left, l + 3);
                for (int i = 0; i < l; i++)
                    Console.Write("-");
                Console.WriteLine(p.data);
                ShowTree(p.right, l + 3);
            }
        }                 
        //печать всего дерева
        public void Show()
        {
            if (root == null)
            {
                Console.WriteLine("Пустое дерево");
            }
            else
                ShowTree(root, 5);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }                                   

       
        //визуализация в виде дерева алгоритма Хаффмана
        public void MakeTree(SortedList<char, double> sList)
        {
            var sortedDict = from entry in sList orderby entry.Value ascending select entry;  //сортировка словаря по значению
            Queue<double> valuess = new Queue<double>();
            Queue<Point> points = new Queue<Point>();    //для хранения мини деревьев
            foreach (var item in sortedDict)
            {
                valuess.Enqueue(item.Value);
            }

            double min1 = 0;
            double min2 = 0;

            Point point1 = new Point();
            Point newPoint = new Point();

            min1 = valuess.Dequeue();
            min2 = valuess.Dequeue();
            newPoint = new Point(Math.Round(min1 + min2, 5));
            newPoint.left = new Point(min1);
            newPoint.right = new Point(min2);

            points.Enqueue(newPoint);

            while (valuess.Count != 0 || points.Count != 1)
            {
                if (valuess.Count != 0 && valuess.Peek() < points.Peek().data)
                {
                    min1 = valuess.Dequeue();
                    if (valuess.Count != 0 && valuess.Peek() < points.Peek().data)
                    {
                        min2 = valuess.Dequeue();

                        newPoint = new Point(Math.Round(min1 + min2, 5));
                        newPoint.left = new Point(min1);
                        newPoint.right = new Point(min2);
                    }
                    else
                    {
                        min2 = points.Peek().data;

                        newPoint = new Point(Math.Round(min1 + min2, 5));
                        newPoint.left = new Point(min1);
                        newPoint.right = points.Dequeue();
                    }
                }
                else
                {
                    point1 = points.Dequeue();
                    if ((points.Count == 0) || (valuess.Count != 0 && valuess.Peek() < points.Peek().data))
                    {
                        min2 = valuess.Dequeue();

                        newPoint = new Point(Math.Round(point1.data + min2, 5));
                        newPoint.left = point1;
                        newPoint.right = new Point(min2);
                    }
                    else
                    {
                        min2 = points.Peek().data;

                        newPoint = new Point(Math.Round(point1.data + min2, 5));
                        newPoint.left = point1;
                        newPoint.right = points.Dequeue();
                    }
                }
                points.Enqueue(newPoint);
            }

            this.root = newPoint;
            return;
        }

        //совмещение символа и его кода
        public SortedList<string, char> MakeCodes(SortedList<char, double> sList)
        {
            this.FindCodeForLeaves(this.root);

            SortedList<string, char> resultList = new SortedList<string, char>();
            List<char> sortedDict = (from entry in sList orderby entry.Value ascending select entry.Key).ToList<char>();
            List <string> sortedDict2 = (from entry in CodesOfLeaves orderby entry.Value ascending select entry.Key).ToList<string>();

            for (int i = 0; i<sortedDict.Count; i++) 
                resultList.Add(sortedDict2[i], sortedDict[i]);
            return resultList;
        }

        //создание кодов Хаффмана
        private void FindCodeForLeaves(Point p)
        {
            if (p != null)
            {
                word += 1;
                FindCodeForLeaves(p.left);
                word = word.Substring(0, word.Length - 1); //убрали последний элемент строки

                if (p.left == null && p.right == null)
                    CodesOfLeaves.Add(word, p.data);
                
                word += 0;
                FindCodeForLeaves(p.right);

                word = word.Substring(0, word.Length - 1); //убрали последний элемент строки
            }
        }                                     
    }
}
