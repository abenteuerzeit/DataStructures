using DataStructures.Node;
using DataStructures.LinkedList;
using System;
using System.Collections.Generic;
using LinkedListSampleApp.Loaders;

namespace LinkedListSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMainMenu();
        }

        private static void DisplayMainMenu()
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
                        IceCreamFlavorsLoader.Load();
                        break;
                    case "2":
                        SeasonsLoader.Load();
                        break;
                    case "3":
                        TestListLoader.Load();
                        break;
                    case "4":
                        //LoadMagicRainbowNecklaceSample();
                        RainbowNecklaceLoader.Load();
                        break;
                    case "5":
                        TramStopsLoader.Load();
                        break;
                    case "6":
                        ColorsLoader.Load();
                        break;
                    case "7":
                        ChromaticMusicNotationLoader.Load();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid selection. Try again.");
                        break;
                }

                PauseBeforeContinuing();
            }
        }

        private static void PauseBeforeContinuing()
        {
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
