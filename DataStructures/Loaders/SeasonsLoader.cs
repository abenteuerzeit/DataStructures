using DataStructures.LinkedList;
using System;

namespace LinkedListSampleApp.Loaders
{
    public static class SeasonsLoader
    {
        public static void Load()
        {
            var seasons = new LinkedList();
            seasons.AddToHead("summer");
            seasons.AddToHead("spring");
            seasons.AddToTail("fall");
            seasons.AddToTail("winter");
            Console.WriteLine(seasons.ToString());
        }
    }
}
