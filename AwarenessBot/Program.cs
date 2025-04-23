using System;
using System.Threading.Tasks;

namespace AwarenessChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Play audio greeting in the background
            Task.Run(() => VoicePlayer.PlayGreeting());

            // Immediately display ASCII banner
            AsciiBanner.Show();

            // Optional: brief pause for dramatic effect
            System.Threading.Thread.Sleep(3000);

            Console.WriteLine("Let's continue building the bot...");
        }
    }
}
