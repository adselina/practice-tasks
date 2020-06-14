using System;

namespace Task2
{
    //Карточки___ Комбинаторика
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            text.Trim(' ');
            char[] p = text.ToCharArray();
            Array.Sort(p);

            long result = 1;
            string newText = new string(p);

            //факториал количества символов в строке
            for (int i = 1; i <= text.Length; i++)
                result *= i;
            
            int Count = 0;
            

            //пока строка не пустая удаляем символы
            while (newText != "")
            {
                char ch = newText[0];

                for (int j = 0; j < newText.Length; j++)
                {
                    char cha = newText[j];
                    if (cha == ch)
                    {
                        Count++;
                        result = result / Count;
                    }
                }
                //удалить повторяющийся символ из строки
                newText = newText.Trim(ch);
                Count = 0; 
            }
            Console.WriteLine(result);
        }
    }
}
