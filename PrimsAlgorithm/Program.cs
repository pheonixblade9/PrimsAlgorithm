using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Homework4Prims
{
    class Homework4Prims
    {
        static void Main(string[] args)
        {
            List<Node> moretCities = new List<Node>();           //holds cities for moret/shapiro problem
            List<Edge> moretEdges = new List<Edge>();            //holds edges  for moret/shapiro problem
            List<Edge> finalMoretSpanningTree = new List<Edge>();//final tree that edges are added to
            List<Node> finalMoretNodes = new List<Node>();       //holds final graph of cities
            AddMoretCities(moretCities);                         //add cities for the Moret/Shapiro problem
            AddMoretNeighbors(moretEdges, moretCities);          //add neighbors for the Moret/Shapiro problem
            SortSpanningTree(moretEdges);                        //sorts by minimum cost
            AddEdgesToNodes(moretEdges);                         //links added nodes and edges
            BuildPrimsGraph(moretCities, moretEdges, finalMoretNodes, finalMoretSpanningTree); //builds the MST
            PrintTree(finalMoretSpanningTree, "moretProblem.txt");

            List<Node> bookCities = new List<Node>();           //holds cities for 6.23 problem
            List<Edge> bookEdges = new List<Edge>();            //holds edges  for 6.23 problem
            List<Edge> finalBookSpanningTree = new List<Edge>();//final tree that edges are added to
            List<Node> finalBookNodes = new List<Node>();       //holds final graph of cities
            Add6_23Cities(bookCities);                          //add cities for the 6.23 problem
            Add6_23Neighbors(bookEdges, bookCities);            //add neighbors for the 6.23 problem
            SortSpanningTree(bookEdges);                        //sorts by minimum cost
            AddEdgesToNodes(bookEdges);                         //links added nodes and edges
            BuildPrimsGraph(bookCities, bookEdges, finalBookNodes, finalBookSpanningTree);
            PrintTree(finalBookSpanningTree, "6_23Problem.txt");
        }

        private static void PrintTree(List<Edge> treeToPrint, string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName);
            foreach (Edge e in treeToPrint)
                sw.WriteLine(e.ToString());
            sw.Close();
        }

        private static void BuildPrimsGraph(List<Node> primNodes, List<Edge> primEdges,
            List<Node> finalPrimsGraph, List<Edge> finalPrimsTree)
        {
            //[0] contains the "new" edge
            //[1] contains the edge pointed to
            //at this point, finalPrimsTree should be empty, but not null
            finalPrimsGraph.Add(primNodes[0]);  //adds first node to tree
            Edge minEdge = finalPrimsGraph[0].edges[0];

            while (finalPrimsTree.Count < primNodes.Count - 1)
            {
                minEdge = new Edge(10000, new Node[] { primNodes[0], primNodes[1] });
                foreach (Node n in finalPrimsGraph)
                    foreach (Edge e in n.edges)
                        if (e.cost < minEdge.cost)
                            if (!finalPrimsGraph.Contains(e.edgeNodes[0]))
                                if (!finalPrimsTree.Contains(e))
                                    minEdge = e;
                finalPrimsGraph.Add(minEdge.edgeNodes[0]);
                finalPrimsTree.Add(minEdge);
            }
        }

        private static Edge minEdgeConnectedToTree(List<Edge> spanningTree)
        {
            int minCost = int.MaxValue;
            Edge minEdge = new Edge();
            foreach (Edge e in spanningTree)
            {
                foreach (Node n in e.edgeNodes)
                {
                    foreach (Edge nodeEdge in n.edges)
                    {
                        if (nodeEdge.cost < minCost)
                        {
                            minCost = nodeEdge.cost;
                            minEdge = new Edge(nodeEdge.cost, nodeEdge.edgeNodes);
                        }
                    }
                }
            }
            return minEdge;
        }

        private static void SortSpanningTree(List<Edge> spanningTree)
        {
            spanningTree.Sort(delegate(Edge e1, Edge e2) { return e1.cost.CompareTo(e2.cost); });
        }

        private static void AddEdgesToNodes(List<Edge> spanningTree)
        {
            foreach (Edge e in spanningTree)
            {
                e.edgeNodes[0].edges.Add(e);
                e.edgeNodes[1].edges.Add(e);
            }
        }

        private static void AddMoretCities(List<Node> cities)
        {
            cities.Add(new Node("Baltimore"));    //0
            cities.Add(new Node("Buffalo"));      //1
            cities.Add(new Node("Cincinatti"));   //2
            cities.Add(new Node("Cleveland"));    //3
            cities.Add(new Node("Detroit"));      //4
            cities.Add(new Node("New York"));     //5
            cities.Add(new Node("Philadelphia")); //6
            cities.Add(new Node("Pittsburgh"));   //7
            cities.Add(new Node("Washington"));   //8
        }

        private static void AddMoretNeighbors(List<Edge> edges, List<Node> cities)
        {
            edges.Add(new Edge(345, new Node[] { cities[1], cities[0] }));
            edges.Add(new Edge(186, new Node[] { cities[1], cities[3] })); //switched
            edges.Add(new Edge(244, new Node[] { cities[2], cities[3] })); //switched
            edges.Add(new Edge(252, new Node[] { cities[4], cities[1] }));
            edges.Add(new Edge(265, new Node[] { cities[4], cities[2] }));
            edges.Add(new Edge(167, new Node[] { cities[4], cities[3] }));
            edges.Add(new Edge(445, new Node[] { cities[5], cities[1] }));
            edges.Add(new Edge(507, new Node[] { cities[5], cities[3] }));
            edges.Add(new Edge(97, new Node[] { cities[6], cities[0] }));
            edges.Add(new Edge(365, new Node[] { cities[6], cities[1] }));
            edges.Add(new Edge(92, new Node[] { cities[5], cities[6] })); //switched
            edges.Add(new Edge(230, new Node[] { cities[7], cities[0] }));
            edges.Add(new Edge(217, new Node[] { cities[7], cities[1] }));
            edges.Add(new Edge(284, new Node[] { cities[2], cities[7] })); //switched
            edges.Add(new Edge(125, new Node[] { cities[3], cities[7] }));
            edges.Add(new Edge(386, new Node[] { cities[7], cities[5] }));
            edges.Add(new Edge(305, new Node[] { cities[7], cities[6] }));
            edges.Add(new Edge(39, new Node[] { cities[8], cities[0] }));
            edges.Add(new Edge(492, new Node[] { cities[8], cities[2] }));
            edges.Add(new Edge(231, new Node[] { cities[8], cities[7] }));
        }

        private static void Add6_23Cities(List<Node> cities)
        {
            cities.Add(new Node("0"));
            cities.Add(new Node("1"));
            cities.Add(new Node("2"));
            cities.Add(new Node("3"));
            cities.Add(new Node("4"));
            cities.Add(new Node("5"));
            cities.Add(new Node("6"));
        }

        private static void Add6_23Neighbors(List<Edge> edges, List<Node> cities)
        {
            edges.Add(new Edge(28, new Node[] { cities[1], cities[0] }));
            edges.Add(new Edge(16, new Node[] { cities[2], cities[1] }));
            edges.Add(new Edge(12, new Node[] { cities[3], cities[4] }));
            edges.Add(new Edge(22, new Node[] { cities[4], cities[5] }));
            edges.Add(new Edge(10, new Node[] { cities[5], cities[0] }));
            edges.Add(new Edge(25, new Node[] { cities[5], cities[4] }));
            edges.Add(new Edge(14, new Node[] { cities[6], cities[1] }));
            edges.Add(new Edge(18, new Node[] { cities[6], cities[3] }));
            edges.Add(new Edge(24, new Node[] { cities[6], cities[4] }));

        }
    }
}
