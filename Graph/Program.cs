namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.addVertex("A");
            graph.addVertex("B");
            graph.addVertex("C");
            graph.addVertex("D");
            graph.addEdge("A", "B");
            graph.addEdge("B", "C");
            graph.addEdge("C", "A");
            graph.addEdge("D", "B");
            graph.addEdge("C", "D");
            graph.addEdge("D", "A");
            graph.printGraph();
            graph.removeEdge("A", "C");
            graph.printGraph();

            graph.removeVertex("A");
            graph.printGraph();

        }
    }
}
