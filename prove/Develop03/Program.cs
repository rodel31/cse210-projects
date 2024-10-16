using System;
using System.Collections.Generic;
using System.IO;
/*
Exceeding Requirements:
1. A library of scriptures is stored in a file ('scriptures.txt') and loaded into the program.
2. The program randomly selects a scripture from the library for the user to memorize.
3. A hint system is implemented. Users can type 'hint' to reveal a random hidden word.
4. Scriptures are stored in a file and dynamically loaded to provide variety and increase the challenge.
*/
class Program
{
    static void Main(string[] args)
    {
        // Load scriptures from a file
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in the file.");
            return;
        }
        // Randomly select a scripture
        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];
        // Main loop
        while (true)
        {
            // Clear the console screen
            Console.Clear();
            // Display the scripture
            Console.WriteLine(scripture.GetDisplayText());
            // Check if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                break;
            }
            // Prompt the user for input
            Console.WriteLine("\nPress Enter to hide more words, type 'hint' for a hint, or type 'quit' to exit.");
            string input = Console.ReadLine();
            // Exit if the user types 'quit'
            if (input.ToLower() == "quit")
            {
                break;
            }
            // Provide a hint if the user types 'hint'
            if (input.ToLower() == "hint")
            {
                scripture.RevealRandomWord();
                continue;
            }
            // Hide a few random words
            scripture.HideRandomWords(3); // Adjust the number if needed
        }
        Console.WriteLine("\nAll words are hidden. Goodbye!");
    }
    // Method to load scriptures from a file
    static List<Scripture> LoadScripturesFromFile(string fileName)
    {
        List<Scripture> scriptures = new List<Scripture>();
        try
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    // Parse reference and text
                    string[] referenceParts = parts[0].Split(' ');
                    string book = referenceParts[0];
                    string[] chapterAndVerses = referenceParts[1].Split(':');
                    int chapter = int.Parse(chapterAndVerses[0]);
                    string[] verses = chapterAndVerses[1].Split('-');

                    // Create a scripture object
                    if (verses.Length == 1)
                    {
                        int verse = int.Parse(verses[0]);
                        Reference reference = new Reference(book, chapter, verse);
                        scriptures.Add(new Scripture(reference, parts[1]));
                    }
                    else if (verses.Length == 2)
                    {
                        int startVerse = int.Parse(verses[0]);
                        int endVerse = int.Parse(verses[1]);
                        Reference reference = new Reference(book, chapter, startVerse, endVerse);
                        scriptures.Add(new Scripture(reference, parts[1]));
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading scriptures: {e.Message}");
        }

        return scriptures;
    }
}