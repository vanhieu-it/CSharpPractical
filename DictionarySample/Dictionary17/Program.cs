using System;
using System.Collections.Generic;

public class GraphNode
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Graph
{
    private Dictionary<GraphNode, List<GraphNode>> adjacencyList = new Dictionary<GraphNode, List<GraphNode>>();

    public void AddEdge(GraphNode source, GraphNode destination)
    {
        if (!adjacencyList.ContainsKey(source))
        {
            adjacencyList[source] = new List<GraphNode>();
        }
        adjacencyList[source].Add(destination);

        // Đối với đồ thị không có hướng, thêm cạnh ngược lại
        if (!adjacencyList.ContainsKey(destination))
        {
            adjacencyList[destination] = new List<GraphNode>();
        }
        adjacencyList[destination].Add(source);
    }

    public void PrintGraph()
    {
        foreach (var node in adjacencyList)
        {
            Console.Write($"{node.Key.Name}: ");
            foreach (var neighbor in node.Value)
            {
                Console.Write($"{neighbor.Name} ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        GraphNode node1 = new GraphNode { Id = 1, Name = "Node 1" };
        GraphNode node2 = new GraphNode { Id = 2, Name = "Node 2" };
        GraphNode node3 = new GraphNode { Id = 3, Name = "Node 3" };

        Graph graph = new Graph();
        graph.AddEdge(node1, node2);
        graph.AddEdge(node2, node3);
        graph.AddEdge(node3, node1);

        graph.PrintGraph();
    }
}
