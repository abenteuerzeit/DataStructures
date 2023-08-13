using DataStructures.Node;
using DataStructures.LinkedList;
using System;

namespace LinkedListSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select a sample data set:");
                Console.WriteLine("1. Ice Cream Flavors");
                Console.WriteLine("2. Seasons");
                Console.WriteLine("3. Test List");
                Console.WriteLine("4. Rainbow Necklace");
                Console.WriteLine("5. Tram Stops");
                Console.WriteLine("6. Colors");
                Console.WriteLine("7. Chromatic Music Notation");
                Console.WriteLine("8. Exit");

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        LoadIceCreamFlavorsSample();
                        break;
                    case "2":
                        LoadSeasonsSample();
                        break;
                    case "3":
                        LoadTestListSample();
                        break;
                    case "4":
                        LoadMagicRainbowNecklaceSample();
                        break;
                    case "5":
                        LoadTramStopsSample();
                        break;
                    case "6":
                        LoadColorsSample();
                        break;
                    case "7":
                        LoadChromaticMusicNotationSample();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid selection. Try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void LoadChromaticMusicNotationSample()
        {
            try
            {
                Console.WriteLine("Not implemented yet\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void LoadColorsSample()
        {
            try
            {
                Console.WriteLine("Not implemented yet\n");
                throw new NotImplementedException();
            }
            catch (NotImplementedException nie)
            {
                Console.WriteLine($"Functionality not yet supported: {nie.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }


        private static void LoadIceCreamFlavorsSample()
        {
            var vanillaNode = new SingleNode("Vanilla");
            var strawberryNode = new SingleNode("Berry Tasty");
            var coconutNode = new SingleNode("Coconuts for Coconut");

            vanillaNode.SetNextNode(strawberryNode);
            strawberryNode.SetNextNode(coconutNode);

            PrintList(vanillaNode);
        }

        private static void LoadSeasonsSample()
        {
            var seasons = new LinkedList();
            seasons.AddToHead("summer");
            seasons.AddToHead("spring");
            seasons.AddToTail("fall");
            seasons.AddToTail("winter");
            Console.WriteLine(seasons.ToString());
        }

        private static void LoadTestListSample()
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


        private static void LoadTramStopsSample()
        {
            var tramStops = new DoublyLinkedList();

            var stops = new string[]
            {
                "Nowy Bieżanów P+R",
                "Ćwiklińskiej",
                "Nowy Prokocim",
                "Teligi",
                "Prokocim Szpital",
                "Prokocim",
                "Wlotowa",
                "Bieżanowska",
                "Kabel",
                "Dworcowa",
                "Cmentarz Podgórski",
                "Podgórze SKA",
                "Plac Bohaterów Getta",
                "św. Wawrzyńca",
                "Miodowa",
                "Starowiślna",
                "Poczta Główna",
                "Teatr Słowackiego",
                "Dworzec Główny Zachód",
                "Politechnika",
                "Dworzec Towarowy",
                "Szpital Narutowicza",
                "Bratysławska",
                "Krowodrza Górka",
            };

            var midpoint = stops.Length / 2;
            for (int i = 0; i < midpoint; i++)
            {
                tramStops.AddToHead(stops[i]);
            }
            for (int i = midpoint; i < stops.Length; i++)
            {
                tramStops.AddToTail(stops[i]);
            }

            Console.WriteLine("Initial List:");
            Console.ReadLine();

            PrintList(tramStops.Head);

            tramStops.RemoveHead();
            tramStops.RemoveTail();

            Console.WriteLine("\nAfter Removing Head and Tail:");
            Console.ReadLine();

            PrintList(tramStops.Head);


            tramStops.RemoveByData("Plac Bohaterów Getta");
            Console.WriteLine("\nAfter Removing 'Plac Bohaterów Getta':");
            Console.ReadLine();

            PrintList(tramStops.Head);
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


        private static void LoadMagicRainbowNecklaceSample()
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
