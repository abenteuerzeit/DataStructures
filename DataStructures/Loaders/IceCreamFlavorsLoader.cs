using DataStructures.Node;
using System;

namespace LinkedListSampleApp.Loaders
{
    public static class IceCreamFlavorsLoader
    {
        public static void Load()
        {
            var vanillaNode = new SingleNode("Vanilla");
            var strawberryNode = new SingleNode("Berry Tasty");
            var coconutNode = new SingleNode("Coconuts for Coconut");

            vanillaNode.SetNextNode(strawberryNode);
            strawberryNode.SetNextNode(coconutNode);

            PrintList(vanillaNode);
        }

        private static void PrintList(Node headNode)
        {
            Node? currentNode = headNode;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.ToString());
                currentNode = currentNode.GetNextNode();
            }
        }
    }
}
