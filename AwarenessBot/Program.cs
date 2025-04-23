using System;
using System.Threading.Tasks;

namespace AwarenessChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Play voice greeting asynchronously
            Task.Run(() => VoicePlayer.PlayGreeting());

            // Show ASCII banner
            AsciiBanner.Show();

            // Optional: pause to let audio and banner finish
            System.Threading.Thread.Sleep(3000);

            // Ask user for their name
            string userName = UserInteraction.GetUserName();

            // Greet user personally
            UserInteraction.WelcomeUser(userName);

            // General welcome message
            Console.WriteLine("Welcome to CyberSecurity Awareness App");

            // Start the interactive Q&A chatbot
            Chatbot.StartConversation();

            // Let user know app is closing
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
