using System.Text;
using DataStructures.Node;

namespace DataStructures.LinkedList
{
    public class LinkedList
    {
        public Node.Node? Head { get; private set; }

        public LinkedList()
        {
            Head = null;
        }

        public void AddToHead(string data)
        {
            var newNode = new SingleNode(data);
            newNode.SetNextNode(Head);
            Head = newNode;
        }

        public void AddToTail(string data)
        {
            if (Head == null)
            {
                Head = new SingleNode(data);
                return;
            }

            Node.Node? currentNode = Head;
            while (currentNode.GetNextNode() != null)
            {
                currentNode = currentNode.GetNextNode();
            }

            currentNode.SetNextNode(new SingleNode(data));
        }

        public void RemoveHead()
        {
            if (Head != null)
            {
                Head = Head.GetNextNode();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("<head> ");
            Node.Node? currentNode = Head;
            while (currentNode != null)
            {
                sb.Append($"{currentNode.Data} ");
                currentNode = currentNode.GetNextNode();
            }
            sb.Append("<tail>");
            return sb.ToString();
        }
    }
}
