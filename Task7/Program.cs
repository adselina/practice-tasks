using System;
using System.Collections.Generic;
using ReadNumbers;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu =1;
            while (menu != 2)
            {
                switch (menu)
                {
                    case 1:
                        HaffmanCode();
                        break;
                    case 2:
                        break;
                }

                menu = Menu();
                Console.Clear();
            }
            
            
        }
        public static void HaffmanCode()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Данная программа строит двоичный преффиксный код Хаффмана.");
            Console.ForegroundColor = ConsoleColor.White;

            SortedList<char, double> sList = ReadTask();

            Tree tree = new Tree();
            Console.WriteLine("Визуализация дерева для создания кода: \n");
            tree.MakeTree(sList);
            tree.Show();
            
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Для данного алфавита можно использвать следующие коды:");
            Console.ForegroundColor = ConsoleColor.White;


            SortedList<string, char> result = tree.MakeCodes(sList);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        public static int Menu()
        {
            Console.WriteLine("___________________________");
            Console.WriteLine("\n1. Построить код для другого алфавита" +
                "\n2. Выйти");
            int menu = ReadNumber.ReadIntNumber(0, 3, "Выберите пункт из меню: ");
            return menu;
        }
        public static SortedList<char, double> ReadTask()
        {
            string[] symbols = null;                                           //массив символов исходного алфавита
            int n = default;                                                   //количество символов в исходном алфавите
            SortedList<char, double> sList = new SortedList<char, double>();   //коллекция для хранения символа и его частоты
            bool flag;
            do
            {
                flag = true;
                n = ReadNumber.ReadIntNumber(1, 200, "Введите количество символов в исходном алфавите: ");
                Console.WriteLine();
                Console.WriteLine("Введите символы через запятую: ");
                symbols = Console.ReadLine().Replace(" ", "").Split(',');

                
                if (symbols.Length != n)
                {
                    Console.Clear();
                    flag = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Количество введенных символов не совпадает с количеством символов в исходном алфавите. Введите новые значения");
                    Console.ForegroundColor = ConsoleColor.White;
                }


            } while (!flag);

            Console.WriteLine();
            double value;
            double sum = 0;

            do
            {
                flag = true;
                sList = new SortedList<char, double>();
                Console.Write("Введите частоту каждого символа ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("(NB! Сумма всех частот должна быть равна 1)");
             
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < n; i++)
                {
                    value = ReadNumber.ReadDoubleNumber(0, $"{symbols[i]}:") ;
                    sum += value;
                    if (!sList.ContainsKey(Convert.ToChar(symbols[i])))
                        sList.Add(Convert.ToChar(symbols[i]), value);
                    else
                    { 
                        flag = false;
                        Console.WriteLine("Были введены одинаковые символы. Повторите попытку ввода. \nНажмите любую клавишу для продолжения");
                        Console.ReadKey();
                        break;
                    }
                }
                
                Console.Clear();
                if (sum != 1)
                {
                    sum = 0;
                    flag = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Сумма частот не равна единице. Введите новые значения");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!flag);
            return sList;

        }
    }
}
