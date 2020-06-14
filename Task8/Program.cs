using System;
using ReadNumbers;
using System.IO;

namespace Task8
{
    class Program
    {
        public static Graph graph = new Graph();
        static void Main(string[] args)
        {

            int menu = 1;

            while (menu != 3)
            {
                menu = PrintMenu();
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        //найти цепь указанной длины
                        //выбрать файл

                        ReadGraph();
                        PrintGraph();
                        FindChain();
                        break;

                    case 2:
                        //сгенерировать тесты для графа

                        GenerateTests();
                        break;

                    case 3:
                        //выход
                        break;
                }

            }

        }

        static int PrintMenu()
        {
            Console.WriteLine("1. Найти цепь необходимой длины" +
                "\n2. Сгенерировать тесты для графа" +
                "\n3. Выход");

            int menu = ReadNumber.ReadIntNumber(0, 4, "Выберите пункт: ");
            Console.Clear();
            return menu;
        }
        static void ReadGraph()
        {
            string[] lines = new string[0];
            bool flag = true;
            graph = new Graph();

            do
            {
                Console.WriteLine("Введите название файла (Например INPUT.TXT)");
                string file = Console.ReadLine();
                int newVertex;
                flag = true;
                try
                {
                    
                    lines = File.ReadAllLines(file);
                    short n = Convert.ToInt16(lines[0]);


                    for (int i = 0; i < n; i++)
                    {
                        graph.AddVertex(new Vertex(i));//создали необходимое кол-во вершин
                    }

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] temp = lines[i].Split(':', ',');
                        newVertex = Convert.ToInt32(temp[0]);

                        for (int j = 1; j < temp.Length; j++)
                        {
                            if (temp[j] != temp[0])
                            {
                                //добавили ребро
                                graph.AddEdge(new Vertex(newVertex), new Vertex(Convert.ToInt32(temp[j])));
                                //добавили обратное ребро
                                graph.AddEdge(new Vertex(Convert.ToInt32(temp[j])), new Vertex(newVertex));
                            }
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.Clear();
                    Console.WriteLine("Файл не найден");
                    flag = false;
                }

            } while (!flag);
            Console.Clear();
        }
        static void PrintGraph()
        {
            Console.WriteLine("Матрица смежностей");

            var matrix = graph.GetMatrix();

            Console.Write("  | ");

            string border = "---";
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(i + 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | ");
                border += "----";

            }
            Console.WriteLine();
            Console.WriteLine(border);


            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(i + 1);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | ");
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    if (i == j)
                    {
                        
                    }
                    if (matrix[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(matrix[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" | ");
                    }
                    else if (i == j) {

                        Console.Write(" " + " | ");
                    }
                    else
                    { Console.Write(matrix[i, j] + " | "); }

                }
                Console.WriteLine();
                Console.WriteLine(border);
            }
        }
        static void FindChain()
        {
            int K = ReadNumber.ReadIntNumber(0, 20, "Введите длину цепи: ");
            string chain = graph.chainsSearch(K);
            if (chain == null)
            {
                Console.WriteLine($"Цепь длины {K} не найдена");
            }
            else Console.WriteLine($"Цепь длины {K}: {chain}");

            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void GenerateTests()
        {
            Random random = new Random();
            int numberOfTest = ReadNumber.ReadIntNumber(0, 15, "Введите количество графов для генерации: ");
            string fileName = new string("TEST0.txt");
            string oneVertex = new string("");
            int flag;

            for (int i = 1; i <= numberOfTest; i++)
            {

                int numberofVertex = random.Next(2, 10);                  //количество вершин в графе
                fileName = fileName.Replace((i - 1).ToString(), i.ToString());
                StreamWriter sw = new StreamWriter(fileName);
                sw.WriteLine(numberofVertex);
                for (int k = 1; k <= numberofVertex; k++)
                {
                    for (int j = 1+k; j <= numberofVertex; j++)
                    {
                        flag = random.Next(0, 2);
                        if (flag != 0)
                        {
                            oneVertex += j +",";
                            
                        }

                    }
                    if (oneVertex != "")
                    {
                        oneVertex = oneVertex.TrimEnd(',');
                        sw.WriteLine(k + ":" + oneVertex);;
                        oneVertex = "";
                    }
                    
                }
                sw.Close();
            }
            Console.WriteLine();
            Console.WriteLine("Тесты успешно сгенерированы" +
                    "\nФормат сформированных тестов: test(№ теста).txt  (Например test3.txt)");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }
    }
}
