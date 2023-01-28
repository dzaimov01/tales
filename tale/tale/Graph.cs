using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tale
{
    internal class Graph
    {
        private int[,] graph;
        private int[] weights;

        public Graph(int size)
        {
            graph = new int[size, size];
            weights = new int[size, size];
        }

        public void AddEdge(int from, int to, int weight)
        {
            graph[from, to] = 1;
            weights[from, to] = weight;
        }

        public int[,] GetGraph()
        {
            return graph;
        }

        public int[] GetWeights()
        {
            return weights;
        }
    }

}
