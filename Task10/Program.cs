using System;
using ReadNumbers;

namespace Task10
{
    class Program
    {
        //Даны натуральное число n, действительные числа а1 ..., аn. 
        //Если последовательность a1 ... аn упорядочена по неубыванию (т. е. если a1<=a2<=...<=an) то оставить ее без изменения. 
        //Иначе получить последовательность an, ..., a1,
        static void Main(string[] args)
        {
            MyList m = MakeList();

            m.PrintList();
            m.Reverse();
            m.PrintList();
            Console.ReadKey();
        }
        public static MyList MakeList()
        {
            MyList myList = new MyList();
            int n = ReadNumber.ReadIntNumber(0, "Введите количество элементов для добавления: ");
            for (int i = 0; i < n; i++)
            {
                myList.Add(ReadNumber.ReadIntNumber(-1000, 1000, "Введите элемент: "));
            }
            return myList;
        }
    }
}