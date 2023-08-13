using DataStructures.LinkedList;
using System;
using System.Collections.Generic;

namespace LinkedListSampleApp.Loaders
{
    public static class ChromaticMusicNotationLoader
    {
        private static readonly string[] ChromaticScale =
        {
            "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"
        };

        public static void Load()
        {
            Console.WriteLine("Loading Ode to Joy...");
            var melody = new DoublyLinkedList();
            var notes = new string[] { "E", "E", "F", "G", "G", "F", "E", "D", "C", "C", "D", "E", "E", "D", "D" };
            foreach (var note in notes)
            {
                melody.AddToTail(note);
            }

            Console.WriteLine("Original Melody:");
            melody.PrintList();
            ContinuePrompt();

            Console.WriteLine("Would you like to transpose the melody? (yes/no)");
            if (Console.ReadLine().Trim().ToLower() == "yes")
            {
                Console.WriteLine("Enter the number of steps to transpose up or down (e.g., 2 for up two steps, -2 for down two steps):");
                if (int.TryParse(Console.ReadLine(), out int steps))
                {
                    TransposeMelody(melody, steps);
                    Console.WriteLine("Transposed Melody:");
                    melody.PrintList();
                }
                else
                {
                    Console.WriteLine("Invalid input. The melody remains untransposed.");
                }
            }

            ContinuePrompt();
        }

        private static void TransposeMelody(DoublyLinkedList melody, int steps)
        {
            var currentNode = melody.Head;
            while (currentNode != null)
            {
                var currentNote = currentNode.Data.ToString();
                var newIndex = (Array.IndexOf(ChromaticScale, currentNote) + steps + ChromaticScale.Length) % ChromaticScale.Length;
                currentNode.UpdateData(ChromaticScale[newIndex]);
                currentNode = currentNode.GetNextNode();
            }
        }

        private static void ContinuePrompt()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
