// See https://aka.ms/new-console-template for more information

namespace tale;

class Program
{
    public static void Main(string[] args)
    {
        string[] graphDimentionsInput = Console.ReadLine().Split(" ");
        int[] graphDimentions = Array.ConvertAll(graphDimentionsInput, int.Parse);
        string[] startingPositionsInput = Console.ReadLine().Split(" ");
        int[] startingPositions = Array.ConvertAll(startingPositionsInput, int.Parse);

        Graph graph = new Graph();
        for (int i = 0; i < graphDimentions[1];i++)
        {
            string[] graphEdgeInput = Console.ReadLine().Split(" ");
            int[] graphEdges = Array.ConvertAll(graphEdgeInput, int.Parse);
            Node startNode = new Node();
        }
    }
}