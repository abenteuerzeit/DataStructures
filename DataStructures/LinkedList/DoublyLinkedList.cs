using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Node;

namespace DataStructures.LinkedList
{
    internal class DoublyLinkedList
    {
        public Node.Node Head { get; internal set; }
        public Node.Node Tail { get; private set; }

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        internal void SetHead(DoubleNode newHead)
        {
            Head = newHead;
        }


        public void AddToHead(string data)
        {
            var newHead = new DoubleNode(data);
            var currentHead = Head;

            if (currentHead != null)
            {
                currentHead.SetPrevNode(newHead);
                newHead.SetNextNode(currentHead);
            }

            Head = newHead;

            if (Tail == null)
            {
                Tail = newHead;
            }
        }

        public void AddToTail(string data)
        {
            var newTail = new DoubleNode(data);
            var currentTail = Tail;

            if (currentTail != null)
            {
                currentTail.SetNextNode(newTail);
                newTail.SetPrevNode(currentTail);
            }

            Tail = newTail;

            if (Head == null)
            {
                Head = newTail;
            }
        }

        public object RemoveHead()
        {
            var removedHead = Head;

            if (removedHead == null)
            {
                return null;
            }

            Head = removedHead.GetNextNode();

            if (Head != null)
            {
                Head.SetPrevNode(null);
            }

            if (removedHead == Tail)
            {
                RemoveTail();
            }

            return removedHead.Data;
        }

        public object RemoveTail()
        {
            var removedTail = Tail;

            if (removedTail == null)
            {
                return null;
            }

            Tail = removedTail.GetPrevNode();

            if (Tail != null)
            {
                Tail.SetNextNode(null);
            }

            if (removedTail == Head)
            {
                RemoveHead();
            }

            return removedTail.Data;
        }

        public Node.Node RemoveByData(string data)
        {
            Node.Node nodeToRemove = null;
            var currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                {
                    nodeToRemove = currentNode;
                    break;
                }

                currentNode = currentNode.GetNextNode();
            }

            if (nodeToRemove == null)
            {
                return null;
            }

            if (nodeToRemove == Head)
            {
                RemoveHead();
            }
            else if (nodeToRemove == Tail)
            {
                RemoveTail();
            }
            else
            {
                var nextNode = nodeToRemove.GetNextNode();
                var previousNode = nodeToRemove.GetPrevNode();
                nextNode.SetPrevNode(previousNode);
                previousNode.SetNextNode(nextNode);
            }

            return nodeToRemove;
        }

        public void PrintList()
        {
            var currentNode = Head;
            var output = "<head> ";

            while (currentNode != null)
            {
                output += currentNode.Data + " ";
                currentNode = currentNode.GetNextNode();
            }

            output += "<tail>";
            Console.WriteLine(output);
        }
    }

}
