using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework4Prims
{
    public class Node
    {
        public string name;
        public List<Edge> edges = new List<Edge>();

        public Node() { }

        public Node(string pName)
        { name = pName; }

        public override string ToString()
        { return this.name; }

    }
}