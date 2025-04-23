using System;

namespace AwarenessChatbot
{
    public class UserInteraction
    {
        public static string GetUserName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u270B  Hello! What’s your name?"); // 👋 Hand = U+270B
            Console.ResetColor();

            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\u26A0  Please enter a valid name:"); // ⚠️ Warning = U+26A0
                Console.ResetColor();
                name = Console.ReadLine();
            }

            return name;
        }

        public static void WelcomeUser(string name)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n\u2728  Welcome, {name}! I'm your Cybersecurity Awareness Assistant."); // ✨ Sparkles = U+2728
            Console.WriteLine("\u2139  I'm here to help you learn how to stay safe online!\n"); // ℹ Info = U+2139
            Console.ResetColor();
        }
    }
}
