
using System;
using System.Threading.Tasks;

namespace AwarenessChatbot
{
    class Program
    {
     public static void Main(string[] args)
        {
            Task.Run(() => VoicePlayer.PlayGreeting());
            AsciiBanner.Show();
            System.Threading.Thread.Sleep(3000);

            string userName = UserInteraction.GetUserName();
            UserInteraction.WelcomeUser(userName);

            string choice;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n╔════════════════════════════════════╗");
                Console.WriteLine("║         [ Main Menu ]              ║");
                Console.WriteLine("╠════════════════════════════════════╣");
                Console.WriteLine("║ 1. Cybersecurity Q&A Chatbot       ║");
                Console.WriteLine("║ 2. Smart AI Chatbot (with mood)    ║");
                Console.WriteLine("║ 3. Play the Password Game          ║");
                Console.WriteLine("║ 4. Exit                            ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.ResetColor();

                Console.Write("\n> Enter your choice (1–4): ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Chatbot.StartConversation();
                        break;
                    case "2":
                        ChatbotAi.StartConversation();
                        break;
                    case "3":
                        ChatbotAi.StartPasswordGame();
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n[CyberBot] Thank you for learning! Stay safe out there! 👋");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("[Warning] Please enter a valid option (1–4).");
                        Console.ResetColor();
                        break;
                }
            }
            while (choice != "4");

            Console.WriteLine("\nPress any key to close...");
            Console.ReadKey();
        }
    }
}
