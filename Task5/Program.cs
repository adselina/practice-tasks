using System;
using ReadNumbers;

namespace Task5
{
    //найти наибольший элементв матрице размерностью n x n в области \/
    class Program
    {
        static void Main(string[] args)
        {
            int menu = 1;
            while (menu != 2)
            {
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Данная программа находит наибольший элемент в верхней области (x) матрицы размерностью n x n  ");
                        int n = ReadNumber.ReadIntNumber(0, 20, "Введите размерность матрицы: ");
                        Console.WriteLine();
                        double[,] matrix = MadeMatrix(n);
                        PrintMatrix(matrix);
                        double max = SearchMax(matrix, n);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nНаибольший элемент в матрице в области: " + String.Format("{0:f2}", max));
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 2:
                        break;
                }

                menu = Menu();
                Console.Clear();
            }
        }
        public static int Menu()
        {
            Console.WriteLine("___________________________");
            Console.WriteLine("\n1. Создать другую матрицу" +
                "\n2. Выйти");
            int menu = ReadNumber.ReadIntNumber(0, 3, "Выберите пункт из меню: ");
            return menu;
        }
        public static double SearchMax(double[,] matrix, int n)
        {
            double max = -1000;
            for (int i = 0; i <= n / 2; i++)
            {
                int col = i;
                while (col < n - i)
                {
                    if (matrix[i, col] > max)
                    {
                        max = matrix[i, col];
                    }
                    col++;
                }
            }
            
            return max;
        }
        public static double[,] MadeMatrix(int n)
        {
            double[,] matrix = new double[n, n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.NextDouble()*rnd.Next(-100,100);
                }
            }
            return matrix;
        } 
        public static void PrintMatrix(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            string str;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    str = String.Format("{0:f2}", matrix[i, j]);
                    if (str[0] != '-') str = " " + str;
                    
                    while (str.Length < 8) str += " ";
                    Console.Write(str);
                }
                Console.WriteLine();
            }
        }
    }
}
