using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodes
{
    public class Node
    {
        private string Data { get; set; }
        private Node Next { get; set; }

        public Node(string data)
        {
            Data = data;
            Next = null;
        }

        public Node GetNextNode()
        {
            return Next;
        }

        public void SetNextNode(Node node)
        {
            if (node is null)
            {
                Next = node;
            }

        }

    }
}
