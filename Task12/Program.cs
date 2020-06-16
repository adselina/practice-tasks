using System;
using System.Collections.Generic;
using System.Linq;
using ReadNumbers;

namespace Task12
{
    public class Point
    {
        public int data;
        public Point left;
        public Point right;
      
        public Point(int d)
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
    public class TreeNode
    {
        public int compares;      //количество сравнений
        public Point root = null; //корень 


        //дерево поиска(массив значений)
        public TreeNode(int[] arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("введите корень");
            }
            else
            {
                root = new Point(arr[0]);//первый элемент
                for (int i = 1; i < arr.Length; i++)
                {
                    Add(arr[i]);
                }
            }
            
        }

        //добавление элемента в дерево поиска
        public void Add(int d)
        {
            if (this.root == null)
            {
                this.root = new Point(d);
                return;
            }
            if (d == null)
            {
                return;
            }
            Point p = this.root;
            Point r = null;
            bool ok = false;
            while (p != null && !ok)
            {
                r = p;
                if (d.CompareTo(p.data) == 0)
                {
                    ok = true;
                    compares++;
                }
                else if  (d.CompareTo(p.data) < 0) {p = p.left; compares += 2; }

                else { p = p.right; compares += 2; }
                }
            if (ok) return;
            Point NewPoint = new Point(d);

            compares++;
            if (d.CompareTo(r.data) < 0)
            {
                r.left = NewPoint;
                
            }
            else r.right = NewPoint;
            return;

        }                          

        public static List<int> elements = new List<int>();
                
        //преобразование дерева в отсортированный массив
        public static void Transform(Point p)
        {
            if (p.left != null)
            {
                Transform(p.left);
            }

            elements.Add(p.data);

            if (p.right != null)
            {
                Transform(p.right);
            }
        }   
        public int[] SortByTree()
        {
            Transform(root);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Двоичное дерево поиска       |    ");
            Console.Write($"Количество пересылок: {elements.Count};     Количество сравнений:{compares}");
            Console.ForegroundColor = ConsoleColor.White;
            compares = 0;
            elements = new List<int>();
            return elements.ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Random rnd = new Random();
            Console.WriteLine("Данная программа сортирует массивы двумя способами и подсчитывает количество пересылок и сравнений");
            int n = ReadNumber.ReadIntNumber(0,1000, "Введите количество элементов для массивов: ");
            Console.WriteLine("\n");
            int[] sortToMaxArr = new int[n];
            int[] sortToMinArr = new int[n];
            int[] notSortArr = new int[n];
            int a = 0;
            
            for (int i = 0; i < n; i++)
            {
                do
                {
                    a = rnd.Next(-n, n);
                } while (notSortArr.Contains(a));

                notSortArr[i] = a;
                sortToMaxArr[i] = i;
                sortToMinArr[i] = n-i;
            }

        
            Results(notSortArr, "Неотсортированный массив");
            Results(sortToMaxArr, "Возрастающий массив");
            Results(sortToMinArr, "Убывающий массив");

            Console.ReadKey();
        }

        public static void Results(int[] arr, string message)
        {
            Console.WriteLine($"{message}\n");
            Console.Write($"массив: "); PrintArr(arr);
            Console.WriteLine();
            TreeNode tree = new TreeNode(arr);
            tree.SortByTree();
            Console.WriteLine();
            SelectionSort(arr);
            Console.WriteLine("\n");
        }

        public static void SelectionSort(int[] arr)
        {
            int countCompares = 0;
            int count = 0;
            int min, temp;
            int length = arr.Length;

            for (int i = 0; i < length - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < length; j++)
                {
                    countCompares++;
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                countCompares++;
                if (min != i)
                {
                    count++;
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Сортировка простым выбором   |    ");
            Console.Write($"Количество пересылок: {count};     Количество сравнений:{countCompares}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintArr(int[] arr)
        {
            for (int i = 0; i< arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        } 
    }
}
