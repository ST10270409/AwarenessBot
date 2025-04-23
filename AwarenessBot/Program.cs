using AwarenessChatbot;

static void Main(string[] args)
{
    Task.Run(() => VoicePlayer.PlayGreeting());
    AsciiBanner.Show();

    // Optional: pause to let audio/banner play out
    Thread.Sleep(3000);

    // 🌟 Cybersecurity Awareness Welcome Message
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n👋 Welcome to the Cybersecurity Awareness Chatbot!");
    Console.ResetColor();

    Console.WriteLine("🎯 Purpose: I'm here to help you stay safe online by sharing cybersecurity tips and answering your questions.\n");

    Console.WriteLine("💬 You can ask me about:");
    Console.WriteLine("   🔐 Password safety");
    Console.WriteLine("   🎣 Phishing scams");
    Console.WriteLine("   🛡️ Antivirus & malware protection");
    Console.WriteLine("   📱 Mobile security");
    Console.WriteLine("   🌍 Safe browsing practices\n");

    Console.WriteLine("Type your name to begin chatting with me! 🧠");

    // Step 3: Ask for name and greet
    string userName = UserInteraction.GetUserName();
    UserInteraction.WelcomeUser(userName);
}
