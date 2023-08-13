using DataStructures.Node;
using DataStructures.LinkedList;
using System;

namespace LinkedListSampleApp.Loaders
{
    public static class TramStopsLoader
    {
        public static void Load()
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
    }
}
