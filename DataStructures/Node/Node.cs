using System;
using System.Text;

namespace DataStructures.Node
{
    public abstract class Node : INode<Node>
    {
        protected internal abstract string Data { get; }
        protected abstract Node? Next { get; }
        protected abstract Node? Prev { get; }

        public abstract Node? GetNextNode();
        public abstract void SetNextNode(Node? node);
        public abstract Node? GetPrevNode();
        public abstract void SetPrevNode(Node? node);
    }

}
