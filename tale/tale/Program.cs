using System.Runtime.CompilerServices;

namespace tale;

class Program
{

    public static void Main(string[] args)
    {

        int[] graphChars = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

        int[] positions = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
        int C = positions[0] - 1;
        int W = positions[1] - 1;
        int B = positions[2] - 1;

        int edges = graphChars[0];
        int numberWeights = graphChars[1];

        int[,] graphInput = ReadGraph(edges, numberWeights);

        



        Graph graph = new Graph(graphInput);

        Console.WriteLine(graph.Djikstra(C)[B]);
    }



    public static int[,] ReadGraph(int dimensions, int numberWeights)
    {

        int[,] graph = new int[dimensions, dimensions];

        for (int i = 0; i < numberWeights; i++)
        {
            int[] weightsInput = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

            int p1 = weightsInput[0] - 1;
            int p2 = weightsInput[1] - 1;
            int s1 = weightsInput[2];

            graph[p1, p2] = s1;
        }


        return graph;
    }

   


   

}

