using System;
using ReadNumbers;

namespace Task3
{
    //попадение точки в нужную область
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Введите координаты точки");
                double x = ReadNumber.ReadDoubleNumber(-1000, 1000, "Введите x: ");      
                double y = ReadNumber.ReadDoubleNumber(-1000, 1000, "Введите y: ");

                if ((((y <= x / 2 + 1) && (y >= -(x / 2) - 1)) && (x < 0)) || ((x >= 0) && (Math.Pow(x, 2) + Math.Pow(y, 2) <= 1)))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Точка ({x},{y}) принадлежит области");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Точка ({x},{y}) НЕ принадлежит области");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.ReadKey();
                Console.Clear();
            } while (Menu() != 2);
        }

        public static int Menu()
        {
            Console.WriteLine("1. Ввести другую точку" +
                "\n2. Выйти");
            int menu = ReadNumber.ReadIntNumber(0, 3, "Выберите пункт из меню: ");
            Console.Clear();
            return menu;
        }
    }
}
