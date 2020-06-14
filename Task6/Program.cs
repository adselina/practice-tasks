using System;
using ReadNumbers;

namespace Task6
{
    //Ввести а1, а2, а3, М, N. Построить последовательность чисел ак = 2 * | ак–1 – ак-2 | +  ак–3. 
    //Построить N элементов последовательности, либо найти первые M ее элементов, кратных трем (в зависимости от того, что выполнится раньше). 
    //Напечатать последовательность и причину остановки.

    class Program
    {
        public static int M;
        public static int N;

        static void Main(string[] args)
        {
            do
            {
                int a1 = ReadNumber.ReadIntNumber(-100, 100, "введите первый элемент ряда: ");
                int a2 = ReadNumber.ReadIntNumber(-100, 100, "введите второй элемент ряда: ");
                int a3 = ReadNumber.ReadIntNumber(-100, 100, "введите третий элемент ряда: "); ;
                M = ReadNumber.ReadIntNumber(0, 100, "Введите количество нужных элементов кратных трем: ");
                N = ReadNumber.ReadIntNumber(3, 100, "Введите количество нужных элементов: ");
                Console.WriteLine("_____________");

                int m = M;
                int n = N;


                Console.Write(a1 + " " + a2 + " " + a3 + " ");

                N = N - 3;
                if (a1 != 0 && a1 % 3 == 0) M--;
                if (a2 != 0 && a2 % 3 == 0) M--;
                if (a3 != 0 && a3 % 3 == 0) M--;

                if (M > 0)
                {
                    recursia(a1, a2, a3);
                    Console.WriteLine();
                }

                if (N == 0 && M == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nОба условия выполнились одновременно!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Количество элементов кратных 3: {m - M}");
                    Console.WriteLine($"Количество элементов: {n - N}");
                }
                else
                {
                    if (N == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nДостигнуто необходимое количество элементов");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Количество элементов кратных 3: {m - M}");
                    }
                    if (M == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nДостигнуто необходимое количество элементов кратных 3");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Количество элементов: {n - N}");
                    }
                }
                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            } while (Menu() != 2);
        }
        public static int Menu()
        {
            Console.WriteLine("1. Ввести другие значения" +
                "\n2. Выйти");
            int menu = ReadNumber.ReadIntNumber(0, 3, "Выберите пункт из меню: ");
            Console.Clear();
            return menu;
        }
        public static void recursia(int a1, int a2, int a3)
        {
            int newElem;

            newElem = 2 * Math.Abs(a3 - a2) + a1;
            Console.Write(newElem + " ");

            if (newElem != 0 && newElem % 3 == 0)
                M--;
            
            N--;
            if (M == 0 && N == 0)
                return;

            else
            {
                if (M == 0)
                    return;

                if (N == 0)
                    return;
            }

            a1 = a2;
            a2 = a3;
            a3 = newElem;

            recursia(a1, a2, a3); ;
        }
    }
}
