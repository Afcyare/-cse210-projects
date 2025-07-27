public class Program
{
    static void Main(string[] args)
    {
        // Create list to hold videos
        List<Video> videos = new List<Video>();

        // Create first video
        Video video1 = new Video();
        video1._title = "C# Tutorial for Beginners";
        video1._author = "ProgrammingExpert";
        video1._lenght = 600;

        Comment comment1 = new Comment("John", "Great introduction to C#");
        Comment comment2 = new Comment("Sarah", "When will part 2 be ready?");
        Comment comment3 = new Comment("Mike", "Clear explanations, thank you!");

        // Add comments to first video
        video1._comments.Add(comment1);
        video1._comments.Add(comment2);
        video1._comments.Add(comment3);

        // Create second video
        Video video2 = new Video();
        video2._title = "OOP Principles Explained";
        video2._author = "CodeMaster";
        video2._lenght = 480;

        // Add comments to second video
        Comment comment4 = new Comment("Emma", "Finally understand abstraction!");
        Comment comment5 = new Comment("Alex", "Could you do a video on polymorphism?");
        Comment comment6 = new Comment("Farhan", "perfect explanation");

        video2._comments.Add(comment4);
        video2._comments.Add(comment5);
        video2._comments.Add(comment6);

        // Create third video
        Video video3 = new Video();
        video3._title = "Building Your First API";
        video3._author = "WebDevPro";
        video3._lenght = 900;

        // Add comments to third video
        Comment comment7 = new Comment("Abdirahman", "Well explained");
        Comment comment8 = new Comment("yasin", "that was great video");
        Comment comment9 = new Comment("abdul", "perfect, you explained everything well");

        video3._comments.Add(comment7);
        video3._comments.Add(comment8);
        video3._comments.Add(comment9);

        // Add videos to list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Lenght: {video._lenght} seconds");

            Console.WriteLine($"Number of comments {video.GetCommentCount()}");

            Console.WriteLine("Comments: ");
            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"- {comment._commenterName}: {comment._commenterText}");
            }
            Console.WriteLine();
        }
    }
}