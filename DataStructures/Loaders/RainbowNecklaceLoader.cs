using DataStructures.Node;
using DataStructures.LinkedList;
using System;
using System.Collections.Generic;

namespace LinkedListSampleApp.Loaders
{
    public static class RainbowNecklaceLoader
    {
        public static void Load()
        {
            Console.WriteLine("Magic Rainbow Necklace: Swapping Beads with C#");
            Console.WriteLine();
            Console.WriteLine("We will create a magical rainbow necklace with beads represented as nodes in a linked list. Each bead has a specific color from the rainbow.");
            Console.WriteLine();
            Console.WriteLine("Step 1: Setting Up");
            Console.WriteLine("Initializing a new necklace using the `DoublyLinkedList` class:");
            var necklace = new DoublyLinkedList();

            Dictionary<string, string> colorNames = new Dictionary<string, string>
            {
                { "Red", "#FF0000" },
                { "Orange", "#FF7F00" },
                { "Yellow", "#FFFF00" },
                { "Light Green", "#7FFF00" },
                { "Green", "#00FF00" },
                { "Cyan", "#00FF7F" },
                { "Light Blue", "#00FFFF" }
            };

            Console.WriteLine("Now, let's define our rainbow colors. They represent:");
            foreach (var color in colorNames)
            {
                Console.WriteLine($"- `{color.Value}`: {color.Key}");
                necklace.AddToTail(color.Key);
            }

            Console.WriteLine();
            Console.WriteLine("Display the Necklace:");
            necklace.PrintList();
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Choose an action:\n1. Swap beads\n2. Add bead\n3. Remove bead\n4. Exit");
                string choice = Console.ReadLine().Trim();

                switch (choice)
                {
                    case "1":
                        SwapBeadsInteractive(necklace, colorNames);
                        break;
                    case "2":
                        AddBeadInteractive(necklace, colorNames);
                        break;
                    case "3":
                        RemoveBeadInteractive(necklace, colorNames);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nUpdated Necklace:");
                necklace.PrintList();
            }
        }

        private static void SwapBeadsInteractive(DoublyLinkedList necklace, Dictionary<string, string> colorNames)
        {
            Console.WriteLine("Enter the first color name or hex code you want to swap:");
            string input1 = GetColorInput(colorNames);

            Console.WriteLine("Enter the second color name or hex code you want to swap:");
            string input2 = GetColorInput(colorNames);

            SwapBeads(necklace, input1, input2);
        }

        private static void AddBeadInteractive(DoublyLinkedList necklace, Dictionary<string, string> colorNames)
        {
            Console.WriteLine("Enter the color name or hex code of the bead you want to add:");
            string input = GetColorInput(colorNames);

            Console.WriteLine("Where do you want to add the bead?\n1. Head\n2. Tail");
            string choice = Console.ReadLine().Trim();
            if (choice == "1")
            {
                necklace.AddToHead(input);
            }
            else if (choice == "2")
            {
                necklace.AddToTail(input);
            }
            else
            {
                Console.WriteLine("Invalid choice. The bead was not added.");
            }
        }

        private static void RemoveBeadInteractive(DoublyLinkedList necklace, Dictionary<string, string> colorNames)
        {
            Console.WriteLine("Enter the color name or hex code of the bead you want to remove:");
            string input = GetColorInput(colorNames);

            necklace.RemoveByData(input);
        }

        private static string GetColorInput(Dictionary<string, string> colorNames)
        {
            while (true)
            {
                string input = Console.ReadLine().Trim();

                if (colorNames.ContainsKey(input))
                {
                    return colorNames[input];
                }
                else if (colorNames.ContainsValue(input) || input.StartsWith("#"))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid color name or hex code. Please try again.");
                }
            }
        }

        private static void SwapBeads(DoublyLinkedList necklace, string color1, string color2)
        {
            Console.WriteLine($"Swapping beads with colors {color1} and {color2}:");

            Node beadBefore1 = null;
            Node beadBefore2 = null;

            var bead1 = necklace.Head;
            var bead2 = necklace.Head;

            while (bead1 != null && (string)bead1.Data != color1)
            {
                beadBefore1 = bead1;
                bead1 = bead1.GetNextNode();
            }

            while (bead2 != null && (string)bead2.Data != color2)
            {
                beadBefore2 = bead2;
                bead2 = bead2.GetNextNode();
            }

            if (bead1 == null || bead2 == null)
            {
                Console.WriteLine("Oops! One or both beads are missing from the necklace. No swap for now.");
                return;
            }

            var nextAfter1 = bead1.GetNextNode();
            var nextAfter2 = bead2.GetNextNode();

            if (beadBefore1 == null)
            {
                necklace.Head = bead2;
            }
            else
            {
                beadBefore1.SetNextNode(bead2);
            }

            if (beadBefore2 == null)
            {
                necklace.Head = bead1;
            }
            else
            {
                beadBefore2.SetNextNode(bead1);
            }

            bead1.SetNextNode(nextAfter2);
            bead2.SetNextNode(nextAfter1);
        }
    }
}
