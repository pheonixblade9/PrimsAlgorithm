using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework4Prims
{
    public class Edge
    {
        public int cost;
        public Node[] edgeNodes;  ///first node added is the new neighbor
        ///second node added is the calling node
        public bool inSpanningTree;

        public Edge()
        { }

        public Edge(Edge e)
        {
            this.edgeNodes = e.edgeNodes;
            this.cost = e.cost;
            this.inSpanningTree = e.inSpanningTree;
        }

        public Edge(int pCost, Node[] pEdgeNodes)
        {
            cost = pCost;
            edgeNodes = pEdgeNodes;
            inSpanningTree = false;
        }

        public override string ToString()
        {
            return ("edge node 0: " + this.edgeNodes[0].name + "\nedge node 1: " +
                this.edgeNodes[1].name + "\n cost:" + this.cost);
        }
    }
}
