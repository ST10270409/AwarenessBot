
namespace AwarenessBot
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class Chatbot
    {
        // Simulating a typing effect
        public static void TypeText(string text, int delay = 100)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay); // Simulate typing effect
            }
        }

        public static void StartConversation()
        {
            // Dictionary to store questions and responses
            Dictionary<int, string> responses = new Dictionary<int, string>
        {
            { 1, "I'm always secure and alert! How can I assist you?" },
            { 2, "I'm here to help South Africans learn how to stay safe online." },
            { 3, "You can ask me about password safety, phishing, and safe browsing tips." },
            { 4, "Use strong passwords with a mix of letters, numbers, and symbols. Never reuse them!" },
            { 5, "Phishing is when attackers trick you into giving personal info. Always check the sender’s email and avoid clicking suspicious links." },
            { 6, "Make sure the site uses HTTPS, avoid downloading unknown files, and use browser privacy settings." },
            { 7, "Thanks for chatting! Stay safe online!" }
        };

            string choice = "";
            bool validInput = false;

            do
            {
                // Section Header with Unicode Borders
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n╔══════════════════════════════════════╗");
                Console.WriteLine("║        🛡️ Cybersecurity Q&A Menu      ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.ResetColor();

                // Menu Options
                Console.WriteLine("║ 1. How are you?                      ║");
                Console.WriteLine("║ 2. What’s your purpose?              ║");
                Console.WriteLine("║ 3. What can I ask you?               ║");
                Console.WriteLine("║ 4. Password safety tips              ║");
                Console.WriteLine("║ 5. Phishing awareness                ║");
                Console.WriteLine("║ 6. Safe browsing practices           ║");
                Console.WriteLine("║ 7. Exit                              ║");
                Console.WriteLine("╚══════════════════════════════════════╝");

                // Asking for user input
                Console.Write("\n➤ Enter your choice (1–7): ");
                choice = Console.ReadLine();

                // Input Validation
                Console.ForegroundColor = ConsoleColor.White;
                validInput = int.TryParse(choice, out int numChoice);

                if (!validInput || numChoice < 1 || numChoice > 7)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    TypeText("⚠ Please enter a valid number between 1 and 7.\n");
                    Console.ResetColor();
                    continue;
                }

                // Visual Divider for clean look
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n──────────────────────────────────────");

                // Fetch the response based on user choice from the dictionary
                if (responses.ContainsKey(numChoice))
                {
                    TypeText(responses[numChoice] + "\n");
                }

                // Visual Divider for clean look
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("──────────────────────────────────────");
                Console.ResetColor();

            } while (choice != "7");
        }
    }
}