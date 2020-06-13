using System;

namespace practica
{
    class Program
    {
        static void Main(string[] args)
        {
            short n = Convert.ToInt16(Console.ReadLine());

            sbyte[,] matrix = new sbyte[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] temp = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                    matrix[i, j] = Convert.ToSByte(temp[j]);

            }

            int sum, a, b;
            int max = -101;

            //Если размерность = 2, то только квадрат
            if (n == 2)
            {
                a = matrix[1, 0];
                b = matrix[0, 0];
                if (a>b) sum = matrix[0, 1] + matrix[1, 1] + a;
                else  sum = matrix[0, 1] + matrix[1, 1] + b;  
                if (sum > max) max = sum;
                
                a = matrix[1, 1];
                b = matrix[0, 1];

                if (a > b) sum = matrix[1, 0] + matrix[0, 0] + a;
                else sum = matrix[1, 0] + matrix[0, 0] + b;
                if (sum > max) max = sum;

            }
            //Если размерность > 2
            else
            {
                //первые две строки горизонталь
                for (int j = 0; j < n - 2; j++)
                {
                    sum = matrix[0, j] + matrix[0, j + 1] + matrix[0, j + 2];
                    if (sum > max) max = sum;
                    sum = matrix[1, j] + matrix[1, j + 1] + matrix[1, j + 2];
                    if (sum > max) max = sum;
                }

                //квадрат
                for (int j = 0; j < n - 1; j++)
                {
                    a = matrix[1, j];
                    b = matrix[0, j + 1];

                    //направо вниз
                    if (a >= b) sum = matrix[0, j] + matrix[1, j + 1] + a;
                    //вниз направо
                    else sum = matrix[0, j] + b + matrix[1, j + 1]; 
                    if (sum > max) max = sum;

                    a = matrix[0, j];
                    b = matrix[1, j + 1];

                    //влево вниз
                    if (a >= b) sum = matrix[0, j + 1] + a + matrix[1, j];
                    //враво вверх
                    else sum = matrix[1, j] + b + matrix[0, j + 1]; 
                    if (sum > max) max = sum;
                }


                //начиная с 3 строки 
                for (int i = 2; i < n; i++)
                {
                    //вертикаль
                    for (int j = 0; j < n; j++)
                    {
                        sum = matrix[i, j] + matrix[i - 1, j] + matrix[i - 2, j]; 
                        if (sum > max) max = sum;
                    }
                    //горизонталь
                    for (int j = 0; j < n-2; j++)
                    {
                        sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]; 
                        if (sum > max) max = sum;
                    }
                    //квадрат
                    for (int j = 0; j < n - 1; j++)
                    {
                        
                        a = matrix[i, j];
                        b = matrix[i - 1, j + 1];

                        if (a >= b) sum = matrix[i - 1, j] + matrix[i, j + 1] + a; 
                        else sum = matrix[i - 1, j] + matrix[i, j + 1] + b;
                        if (sum > max) max = sum;

                        a = matrix[i - 1, j];
                        b = matrix[i, j + 1];

                        if (a >= b) sum = matrix[i - 1, j + 1] + matrix[i, j] + a; 
                        else sum = matrix[i - 1, j + 1] + matrix[i, j] + b;
                        if (sum > max) max = sum;
                    }
                }
            }
            Console.WriteLine(max);
        }
    }
}