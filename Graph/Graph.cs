using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Graph
    {
        private Dictionary<string, List<string>> adjList = [];
        private bool isEdgeExist(List<string> adjList, string vertex)
        {
            foreach(var adj in adjList)
            {
                if(adj == vertex) return true;
            }
            return false;
        }

        public void printGraph()
        {
            foreach (var adj in adjList)
            {
                Console.WriteLine($"{adj.Key} = [{string.Join(", ", adj.Value)}]");
            }
        }

        public bool addVertex(string vertex)
        {
            if (!adjList.ContainsKey(vertex))
            {
                adjList.Add(vertex, []);
                return true;
            }

            return false;
        }

        public bool addEdge(string vertex1, string vertex2)
        {
            if (adjList.ContainsKey(vertex1) && adjList.ContainsKey(vertex2))
            {
                if (!(isEdgeExist(adjList[vertex1], vertex2)) &&
                    !(isEdgeExist(adjList[vertex2], vertex1)))
                {
                    adjList[vertex1].Add(vertex2);
                    adjList[vertex2].Add(vertex1);
                    return true; 
                }
            }
            return false;
        }

        public bool removeEdge(string vertex1, string vertex2)
        {
            if (adjList.TryGetValue(vertex1, out List<string>? value1) &&
                adjList.TryGetValue(vertex2, out List<string>? value2))
            {
                if (isEdgeExist(value1, vertex2) &&
                    isEdgeExist(value2, vertex1))
                {
                    value1.Remove(vertex2);
                    value2.Remove(vertex1);
                    return true; 
                }
            }
            return false;
        }

        public bool removeVertex(string removeVertex)
        {
            if (adjList.ContainsKey(removeVertex))
            {
                foreach (var vertex in adjList[removeVertex])
                {
                    adjList[vertex].Remove(removeVertex);
                }
                adjList.Remove(removeVertex);
                return true;
            }
            return false ;
        }
    }
}
