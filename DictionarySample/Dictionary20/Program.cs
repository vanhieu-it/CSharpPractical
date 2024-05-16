using System;
using System.Collections.Generic;
using System.Linq;

public class Graph
{
    public Dictionary<string, Dictionary<string, int>> AdjacencyList { get; } = new Dictionary<string, Dictionary<string, int>>();

    public void AddEdge(string source, string destination, int weight)
    {
        if (!AdjacencyList.ContainsKey(source))
        {
            AdjacencyList[source] = new Dictionary<string, int>();
        }
        AdjacencyList[source][destination] = weight;

        if (!AdjacencyList.ContainsKey(destination))
        {
            AdjacencyList[destination] = new Dictionary<string, int>();
        }
        AdjacencyList[destination][source] = weight; // For undirected graph
    }

    public Dictionary<string, int> Dijkstra(string start)
    {
        var distances = AdjacencyList.Keys.ToDictionary(key => key, key => int.MaxValue);
        distances[start] = 0;

        var priorityQueue = new SortedSet<(int distance, string vertex)>(new DistanceComparer());
        priorityQueue.Add((0, start));

        while (priorityQueue.Any())
        {
            var (currentDistance, currentVertex) = priorityQueue.Min;
            priorityQueue.Remove(priorityQueue.Min);

            foreach (var (neighbor, weight) in AdjacencyList[currentVertex])
            {
                var distance = currentDistance + weight;
                if (distance < distances[neighbor])
                {
                    priorityQueue.Remove((distances[neighbor], neighbor));
                    distances[neighbor] = distance;
                    priorityQueue.Add((distance, neighbor));
                }
            }
        }

        return distances;
    }

    private class DistanceComparer : IComparer<(int distance, string vertex)>
    {
        public int Compare((int distance, string vertex) x, (int distance, string vertex) y)
        {
            var result = x.distance.CompareTo(y.distance);
            return result == 0 ? x.vertex.CompareTo(y.vertex) : result;
        }
    }
}

class Program
{
    static void Main()
    {
        Graph graph = new Graph();
        graph.AddEdge("A", "B", 1);
        graph.AddEdge("B", "C", 2);
        graph.AddEdge("A", "C", 4);
        graph.AddEdge("C", "D", 1);

        var distances = graph.Dijkstra("A");

        Console.WriteLine("Shortest distances from A:");
        foreach (var (vertex, distance) in distances)
        {
            Console.WriteLine($"Vertex {vertex}: {distance}");
        }
    }
}
