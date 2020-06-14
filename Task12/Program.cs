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
                else if (d.CompareTo(p.data) < 0) p = p.left;

                else { p = p.right; compares+=2; }
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

        public static List<int> elements = null;
                
        //преобразование дерева в отсортированный массив
        public static void Transform(Point p)
        {
            if (elements == null)
            {
                elements = new List<int>();
            }

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
            return elements.ToArray();
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = ReadNumber.ReadIntNumber(0,10000,"Введите количество элементов в массиве: ");
            
            int[] arr1 = new int[n]; 
            int[] result_arr1 = new int[n];

            int a = 0;
            
            for (int i = 0; i < n; i++)
            {
                do
                {
                    a = rnd.Next(-n, n);
                } while (arr1.Contains(a));
                
                arr1[i] = a;
               
            }

            TreeNode tree = new TreeNode(arr1);
            result_arr1 = tree.SortByTree();
            Console.WriteLine("Количество сравнений для создания двоичного дерева " + tree.compares);
            PrintArr(result_arr1);
            
            
            SelectionSort(arr1);
            PrintArr(arr1);
        }

       
        public static void SelectionSort(int[] arr)
        {
            int count = 0;
            int min, temp;
            int length = arr.Length;

            for (int i = 0; i < length - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    count++;
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
            
            Console.WriteLine($"Количество перестановок, используя сортировку простым выбором, равно {count}");
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
