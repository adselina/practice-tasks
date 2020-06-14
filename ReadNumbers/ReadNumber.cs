using System;

namespace ReadNumbers
{
    public class ReadNumber
    {
        public static int ReadIntNumber(string label)
        {
            int result = 0;
            bool flag = true;
            
            do
            {
                Console.Write(label);
                flag = int.TryParse(Console.ReadLine(), out result);

                if (!flag)

                    Console.WriteLine($"Неверный ввод. Введите целое число.");

            } while (!flag);

            return result;
        }
        public static int ReadIntNumber(int left, string label)
        {
            int result = 0;
            bool flag = true;
            
            do
            {
                Console.Write(label);
                flag = int.TryParse(Console.ReadLine(), out result);

                if (!flag || result < left + 1)

                    Console.WriteLine($"Неверный ввод. Введите целое число от {left + 1}");

            } while (!flag || result < left + 1);

            return result;
        }
        public static int ReadIntNumber(int left, int right, string label)
        {
            int result = 0;
            bool flag = true;
            
            do
            {
                Console.Write(label);
                flag = int.TryParse(Console.ReadLine(), out result);

                if (!flag || result < left + 1 || result > right - 1)

                    Console.WriteLine($"Неверный ввод. Введите целое число от {left + 1} до {right - 1}");

            } while (!flag || result < left + 1 || result > right - 1);

            return result;
        }
        public static double ReadDoubleNumber(string label)
        {
            double result = 0;
            bool flag = true;
            do
            {
                Console.Write(label);
                flag = double.TryParse(Console.ReadLine(), out result);

                if (!flag)
                    Console.WriteLine($"Неверный ввод. Введите число (Например 2,1)");

            } while (!flag);

            return result;
        }
        public static double ReadDoubleNumber(double left, string label)
        {
            double result = 0;
            bool flag = true;
            do
            {
                Console.Write(label);
                flag = double.TryParse(Console.ReadLine(), out result);

                if (!flag || result < left)

                    Console.WriteLine($"Неверный ввод. Введите число от {left} (Например 0,2)");

            } while (!flag || result < left);

            return result;
        }
        public static double ReadDoubleNumber(double left, double right, string label)
        {
            double result = 0;
            bool flag = true;
            
            do
            {
                Console.Write(label);
                flag = double.TryParse(Console.ReadLine(), out result);

                if (!flag || result < left + 1 || result > right - 1)

                    Console.WriteLine($"Неверный ввод. Введите число от {left + 1} до {right - 1} (Например 2,1)");

            } while (!flag || result < left + 1 || result > right - 1);

            return result;
        }
    }
}
