using System;

namespace LinkedListSampleApp.Loaders
{
    public static class ColorsLoader
    {
        public static void Load()
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
    }
}
