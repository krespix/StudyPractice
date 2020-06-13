using System.Collections.Generic;

namespace task37Graph
{
    class Vertex
    {
        public int x, y;
 
        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    class Edge
    {
        public int v1, v2;
 
        public Edge(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public override string ToString()
        {
            return $"Вершина 1: {v1}\nВершина 2: {v2}";
        }
    }
    public class DFS
    {
        //1-white 2-black
        private List<Vertex> V = new List<Vertex>();
        private List<Edge> E = new List<Edge>();
        public List<string> catalogCycles = new List<string>();

        public DFS(int[,] matrix)
        {
            Edge edge;
            Vertex vertex = new Vertex(1, 1);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                vertex = new Vertex(i, i);
                V.Add(vertex);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    edge = new Edge(i, j);
                    if (matrix[i, j] == 1)
                    {
                        E.Add(edge);
                    }
                }
            }
        }

        public void cyclesSearch()

        {
            int[] color = new int[V.Count];
            for (int i = 0; i < V.Count; i++)
            {
                for (int k = 0; k < V.Count; k++)
                    color[k] = 1;
                List<int> cycle = new List<int>();
                cycle.Add(i + 1);
                DFScycle(i, i, E, color, -1, cycle);
            }
        }

        private void DFScycle(int u, int endV, List<Edge> E, int[] color, int unavailableEdge, List<int> cycle)
        {
        //если u == endV, то эту вершину перекрашивать не нужно, иначе мы в нее не вернемся, а вернуться необходимо
            if (u != endV)
                color[u] = 2;
            else if (cycle.Count >= 2)
            {
                cycle.Reverse();
                string s = cycle[0].ToString();
                for (int i = 1; i < cycle.Count; i++)
                    s += "-" + cycle[i].ToString();
                bool flag = false; //есть ли палиндром для этого цикла графа в List<string> catalogCycles?
                for (int i = 0; i < catalogCycles.Count; i++)
                    if (catalogCycles[i].ToString() == s)
                    {
                        flag = true;
                        break;
                    }
                if (!flag)
                {
                    cycle.Reverse();
                    s = cycle[0].ToString();
                    for (int i = 1; i < cycle.Count; i++)
                        s += "-" + cycle[i].ToString();
                    catalogCycles.Add(s);
                }
                return;
            }
            for (int w = 0; w < E.Count; w++)
            {
                if (w == unavailableEdge)
                    continue;
                if (color[E[w].v2] == 1 && E[w].v1 == u)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(E[w].v2 + 1);
                    DFScycle(E[w].v2, endV, E, color, w, cycleNEW);
                    color[E[w].v2] = 1;
                }
                else if (color[E[w].v1] == 1 && E[w].v2 == u)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(E[w].v1 + 1);
                    DFScycle(E[w].v1, endV, E, color, w, cycleNEW);
                    color[E[w].v1] = 1;
                }
            }
        }
    }
}