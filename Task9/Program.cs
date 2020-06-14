using System;
using ReadNumbers;

namespace Task19
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu = 1;
            MyList myList = new MyList();
            do
            {
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Создание коллекции...");
                        myList = MakeList();
                        myList.PrintList();
                        break;

                    case 2:
                        myList.Add(ReadNumber.ReadIntNumber(-1000, 1000, "Введите значение элемента для добавления: "));
                        myList.PrintList();
                        break;

                    case 3:
                        myList.RemoveKey(ReadNumber.ReadIntNumber(-1000, 1000, "Введите значение элемента для удаления: "));
                        myList.PrintList();
                        break;

                    case 4:
                        int elem = ReadNumber.ReadIntNumber(-1000, 1000, "Введите значение элемента для удаления: ");
                        bool find = myList.FindElement(elem);
                        if (find)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Элемент {elem} найден в списке");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Элемент {elem} в списке не найден");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;

                    case 5:
                        myList.PrintList();
                        break;

                    case 6:
                        //выход
                        break;
                }
                Console.Clear();
                menu = Menu();
            } while (menu != 6);
            
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
        public static int Menu()
        {
            Console.WriteLine("1. Создать лист" +
                "\n2. Добавить элемент" +
                "\n3. Удалить элемент" +
                "\n4. Поиск элемента" +
                "\n5. Печать" +
                "\n6. Выход");
            int menu = ReadNumber.ReadIntNumber(0, 7, "Выберите пункт из меню: ");
            Console.Clear();
            return menu;
        }
    }
}
