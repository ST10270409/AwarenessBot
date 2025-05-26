
using System;

namespace AwarenessChatbot
{
    public static class Chatbot
    {
        public static void StartConversation()
        {
            Console.WriteLine("\n[Basic Chatbot] Hi! Ask me any cybersecurity question or type 'exit' to leave.");

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine().ToLower();

                if (input == "exit")
                {
                    Console.WriteLine("[Basic Chatbot] Goodbye!");
                    break;
                }

                if (input.Contains("password"))
                {
                    Console.WriteLine("[Basic Chatbot] Use long, unique passwords with special characters!");
                }
                else if (input.Contains("phishing"))
                {
                    Console.WriteLine("[Basic Chatbot] Be cautious of suspicious emails and links.");
                }
                else if (input.Contains("privacy"))
                {
                    Console.WriteLine("[Basic Chatbot] Adjust your social media privacy settings regularly.");
                }
                else
                {
                    Console.WriteLine("[Basic Chatbot] Sorry, I don't understand. Try asking about passwords, phishing, or privacy.");
                }
            }
        }
    }
}
