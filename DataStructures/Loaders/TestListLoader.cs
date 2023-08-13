using DataStructures.Node;
using DataStructures.LinkedList;
using System;

namespace LinkedListSampleApp.Loaders
{
    public static class TestListLoader
    {
        public static void Load()
        {
            Console.WriteLine("LinkedList Test Sample\n");

            var testList = new DoublyLinkedList();

            for (int i = 0; i <= 1; i++)
            {
                testList.AddToTail(i.ToString());
            }

            Console.WriteLine("Initial List:");
            testList.PrintList();
            ContinuePrompt();

            Console.WriteLine("How many numbers do you want to add? (Limit up to 10):");
            int numberOfAdditions;
            while (!int.TryParse(Console.ReadLine(), out numberOfAdditions) || numberOfAdditions < 1 || numberOfAdditions > 10)
            {
                Console.WriteLine("Please enter a valid number between 1 and 10.");
            }

            for (int i = 0; i < numberOfAdditions; i++)
            {
                Console.WriteLine($"Enter the number {i + 1} you want to add:");
                string numberToAdd = Console.ReadLine().Trim();

                Console.WriteLine("Do you want to add to the head or tail? (Enter 'head' or 'tail'):");
                string position = Console.ReadLine().Trim().ToLower();

                while (position != "head" && position != "tail")
                {
                    Console.WriteLine("Invalid choice. Please enter 'head' or 'tail':");
                    position = Console.ReadLine().Trim().ToLower();
                }

                if (position == "head")
                {
                    testList.AddToHead(numberToAdd);
                }
                else
                {
                    testList.AddToTail(numberToAdd);
                }

                Console.WriteLine("Updated List:");
                testList.PrintList();
            }

            Console.WriteLine("Enter the first number you want to swap:");
            string data1 = Console.ReadLine().Trim();

            Console.WriteLine("Enter the second number you want to swap:");
            string data2 = Console.ReadLine().Trim();

            SwapNodes(testList, data1, data2);

            Console.WriteLine("List after swapping:");
            testList.PrintList();
            ContinuePrompt();
        }

        private static void ContinuePrompt()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void SwapNodes(DoublyLinkedList list, string data1, string data2)
        {
            Console.WriteLine($"Swapping {data1} and {data2}:");

            Node node1Prev = null;
            Node node2Prev = null;
            var node1 = list.Head;
            var node2 = list.Head;

            if (data1 == data2)
            {
                Console.WriteLine("Elements are the same - no swap to be made");
                return;
            }

            while (node1 != null && (string)node1.Data != data1)
            {
                node1Prev = node1;
                node1 = node1.GetNextNode();
            }

            while (node2 != null && (string)node2.Data != data2)
            {
                node2Prev = node2;
                node2 = node2.GetNextNode();
            }

            if (node1 == null || node2 == null)
            {
                Console.WriteLine("Swap not possible - one or more element is not in the list");
                return;
            }

            if (node1Prev == null)
            {
                list.Head = node2;
            }
            else
            {
                node1Prev.SetNextNode(node2);
            }

            if (node2Prev == null)
            {
                list.Head = node1;
            }
            else
            {
                node2Prev.SetNextNode(node1);
            }

            var temp = node1.GetNextNode();
            node1.SetNextNode(node2.GetNextNode());
            node2.SetNextNode(temp);
        }
    }
}
