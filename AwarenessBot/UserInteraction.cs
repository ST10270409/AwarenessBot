
using System;

namespace AwarenessChatbot
{
    public static class UserInteraction
    {
        public static string GetUserName()
        {
            Console.Write("\nWhat is your name? ");
            return Console.ReadLine();
        }

        public static void WelcomeUser(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWelcome, {userName}! Let's learn about cybersecurity.");
            Console.ResetColor();
        }
    }
}
