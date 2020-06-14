using System;
using ReadNumbers;

namespace Task4
{
    //вычислить сумму ряда с заданной точностью
    class Program
    {
        static void Main(string[] args)
        {
            int nSymb = ReadNumber.ReadIntNumber(0, 16, "Введите с точность до какого знака нужно вычислить сумму ряда: ");  //задать точность
            double e = 1 / (Math.Pow(10, nSymb));
            double a = 1;       //первый элемент ряда
            int i = 1;          //номер элемента
            double SE = 1;      //частичная сумма
            do
            {
                a = a * (-2) / (i);       //новый элемент ряда
                SE += a;
                i += 1;

            } while (Math.Abs(a) >= e);

            Console.WriteLine($"Сумма ряда = {SE}");
            Console.ReadKey();
        }
    }
}
