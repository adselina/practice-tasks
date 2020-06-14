using System.Collections.Generic;
using System.Linq;


namespace Task8
{
    class Graph
    {
        //множество вершин
        List<Vertex> Vertexes = new List<Vertex>();

        //множество ребер
        List<Edge> Edges = new List<Edge>();

        public int VertexCount => Vertexes.Count();
        public int EdgeCount => Edges.Count();

        public void AddVertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }
        public void AddEdge(Vertex from, Vertex to)
        {
            var edge = new Edge(from, to);
            Edges.Add(edge);
        }

        public int[,] GetMatrix()
        {
            var matrix = new int[Vertexes.Count, Vertexes.Count];

            foreach(var edge in Edges)
            {
                var row = edge.From.Number;
                var column = edge.To.Number;

                matrix[row-1, column-1] = edge.Weight;
            }

            return matrix;
        }

        private void FindChain(int firstV, int endV, int[] visit, string resultChain, int K)
        {
            
            //firstV - начальная вершина
            //endV - конечная вершина
            //visit - массив, в котором хранится информация о посещении вершины
            //resultChain - рекурсивно собирающаяся цепочка
            //K - неоьходимое кол-во вершин в цепи

            //не достигли конца обхода
            //вершину не перекрашивать, если первая вершина = последней вершине (возможно в ней есть несколько путей)
            if (firstV != endV)
                visit[firstV - 1] = 1;
            else
            {
                if (resultChain.Split("-").Length == K)               
                    chain = resultChain;
                return;       
            }

            //обход всех ребер данной верщ
            for (int i = 0; i < Edges.Count; i++)
            {
                //если найдена цепь можно выходить из рекурсии
                if (chain.Split("-").Length == K)
                    break;

                //если вершину не посещали и в нее можно попасть из начальной вершины
                if (visit[Edges[i].To.Number - 1] == 0 && Edges[i].To.Number == firstV)
                {
                    FindChain(Edges[i].To.Number, endV, visit, resultChain + "-" + (Edges[i].To.Number).ToString(), K);
                    visit[Edges[i].To.Number - 1] = 0;
                }

                //если вершину не посещали и в нее можно попасть из начальной вершины
                else if (visit[Edges[i].From.Number - 1] == 0 && Edges[i].To.Number == firstV)
                {
                    FindChain(Edges[i].From.Number, endV, visit, resultChain + "-" + (Edges[i].From.Number).ToString(), K);
                    visit[Edges[i].From.Number - 1] = 0;
                }
            }
        }

        public string chain = new string("");

        public string chainsSearch(int K)
        {
            
            int[] visit = new int[Vertexes.Count];      //если вершину проходили, то ее значение = 1, иначе 0
           
            //для перебора первоначальных вершин
            for (int i = 1; i <= Vertexes.Count; i++)

                //для перебора конечных вершин
                for (int j = i+1; j <= Vertexes.Count; j++)
                {
                    //все вершины первоначально имеют значение 0,
                    for (int n = 0; n < Vertexes.Count; n++)
                        visit[n] = 0;

                    chain = "";
                    FindChain(i, j, visit, (i).ToString(), K);
                    
                    if (chain.Split('-').Length == K)
                        return chain;
                }
            return null;
        }
    }
}
