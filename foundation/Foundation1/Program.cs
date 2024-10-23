using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>();
        // Create some videos
        Video video1 = new Video("Learn C# in 10 Minutes", "Alice", 600);
        video1.AddComment(new Comment("Bob", "Great tutorial!"));
        video1.AddComment(new Comment("Charlie", "Thanks for the tips!"));
        video1.AddComment(new Comment("Dave", "I learned a lot!"));

        Video video2 = new Video("Understanding OOP Concepts", "Eve", 900);
        video2.AddComment(new Comment("Frank", "Very helpful!"));
        video2.AddComment(new Comment("Grace", "Clear explanations."));
        video2.AddComment(new Comment("Heidi", "Looking forward to more videos!"));

        Video video3 = new Video("Advanced C# Techniques", "Mallory", 1200);
        video3.AddComment(new Comment("Oscar", "Can't wait to apply this!"));
        video3.AddComment(new Comment("Peggy", "Good stuff!"));
        video3.AddComment(new Comment("Trent", "Keep it coming!"));
        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        // Display video information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}