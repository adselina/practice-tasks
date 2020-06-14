using System;

namespace Task11
{ 
    //Задача 841
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            string str = "";
            do
            {
                flag = true;
                Console.WriteLine("Введите сообщение из 1 и 0 для расшифрования (для удобства можно делить строку пробелами)");
                str = Console.ReadLine().Replace(" ", "");
                
                for (int i = 0; i< str.Length; i++)
                {
                    if (str[i] != '0' && str[i] != '1')
                    {
                        flag = false;
                        Console.WriteLine("Неверный ввод сообщения: Введите последовательность из нулей и единиц");
                        break;
                    }
                }
                if (str.Length % 3 != 0 && flag)
                {
                    flag = false;
                    Console.WriteLine("Неверный ввод сообщения:");
                }
            } while (!flag);
            int count = 0;
            string resultStr = "";
            for (int i = 0; i<str.Length; i++)
            {
                if (str[i] == '0')
                    count--;
                
                else count++;
                if ((i + 1) % 3 == 0)
                {
                    if (count > 0)
                        resultStr += 1;
                    else
                        resultStr += 0;
                    count = 0;
                } 
            }

            Console.WriteLine(resultStr);
            Console.ReadLine();
        }
    }
}
