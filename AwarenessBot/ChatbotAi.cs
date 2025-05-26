using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AwarenessChatbot
{
    public class ChatbotAi
    {
        private static string userName;
        private static string userInterest;
        private static string lastTopic = "";
        private static Dictionary<string, string[]> topicResponses = new Dictionary<string, string[]>
        {
            { "password", new[] {
                "Include letters, numbers, and special characters.",
                "Avoid common words or sequences like '1234'.",
                "Use a password manager to store your passwords securely."
            }},
            { "phishing", new[] {
                "Look out for fake email addresses and urgent messages.",
                "Don’t click on suspicious links or download unknown attachments.",
                "Verify unexpected emails with the sender through another method."
            }},
            { "privacy", new[] {
                "Use privacy-focused browsers and extensions.",
                "Limit what you share on social media.",
                "Regularly review your app permissions."
            }}
        };

        private static Random rnd = new Random();

        public static void StartConversation()
        {
            LoadUserData();

            if (string.IsNullOrEmpty(userName))
            {
                Console.Write("\nBefore we begin, what's your name? ");
                userName = Console.ReadLine();
            }

            if (string.IsNullOrEmpty(userInterest) || !topicResponses.ContainsKey(userInterest))
            {
                Console.Write($"\nWelcome, {userName}! What topic interests you (privacy, phishing, password)? ");
                userInterest = Console.ReadLine()?.ToLower();
            }

            SaveUserData();

            Console.WriteLine($"\nGreat! I’ll remember that you're interested in {userInterest}.");

            string currentTopic = userInterest;
            bool exitRequested = false;

            while (!exitRequested)
            {
                Console.Write("\nAsk me anything or type 'game', 'quiz', 'leaderboard', 'help', 'export', 'reset', or 'exit': ");
                string input = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(input)) continue;

                string response = "";
                bool understood = false;

                switch (input)
                {
                    case "exit":
                        Console.WriteLine($"\nThanks for chatting, {userName}. Stay safe online!");
                        return;

                    case "reset":
                        ResetUserData();
                        StartConversation(); // restart
                        return;

                    case "export":
                        ExportTips();
                        continue;

                    case "help":
                        response = "Ask about: password, phishing, privacy.\nType 'game' to play, 'quiz' to test yourself, 'leaderboard' to see top scores, 'export' for tips, 'reset' to clear history, or 'exit'.";
                        Console.WriteLine(response);
                        Log(input, response);
                        continue;

                    case "game":
                        StartPasswordGame();
                        continue;

                    case "quiz":
                        StartQuiz();
                        continue;

                    case "leaderboard":
                        ShowLeaderboard();
                        continue;
                }

                // Sentiment detection
                string sentiment = DetectSentiment(input);
                if (sentiment != "neutral")
                {
                    understood = true;
                    response = sentiment switch
                    {
                        "worried" => "It's okay to feel worried. You're not alone, and I'm here to help!",
                        "curious" => "Curiosity is great! Let’s explore that topic together.",
                        "frustrated" => "Frustration is normal — cybersecurity can be tricky. I'm here for you!",
                        _ => ""
                    };
                    Console.WriteLine(response);
                    Log(input, response);
                }

                // Gratitude
                if (input.Contains("thank"))
                {
                    understood = true;
                    response = "You're welcome! 😊 Let me know if you have more questions.";
                    Console.WriteLine(response);
                    Log(input, response);
                    continue;
                }

                // Ask for more
                if (input.Contains("more") && !string.IsNullOrEmpty(lastTopic))
                {
                    understood = true;
                    response = topicResponses[lastTopic][rnd.Next(topicResponses[lastTopic].Length)];
                    Console.WriteLine($"Another tip on {lastTopic}: {response}");
                    Log(input, response);
                    continue;
                }

                // Topic matching
                foreach (var kvp in topicResponses)
                {
                    if (input.Contains(kvp.Key))
                    {
                        understood = true;
                        currentTopic = kvp.Key;
                        lastTopic = kvp.Key;
                        response = kvp.Value[rnd.Next(kvp.Value.Length)];
                        Console.WriteLine($"Here's a tip on {kvp.Key}: {response}");
                        Log(input, response);
                        break;
                    }
                }

                // Fallback
                if (!understood)
                {
                    response = "I'm not sure I understood. Try asking about passwords, phishing, or privacy.";
                    Console.WriteLine(response);
                    Log(input, response);
                }
            }
        }

        private static string DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared")) return "worried";
            if (input.Contains("curious")) return "curious";
            if (input.Contains("angry") || input.Contains("frustrated")) return "frustrated";
            return "neutral";
        }

        private static void LoadUserData()
        {
            if (File.Exists("userdata.txt"))
            {
                string[] data = File.ReadAllLines("userdata.txt");
                if (data.Length >= 2)
                {
                    userName = data[0];
                    userInterest = data[1];
                }
            }
        }

        private static void SaveUserData()
        {
            File.WriteAllLines("userdata.txt", new[] { userName, userInterest });
        }

        private static void ResetUserData()
        {
            if (File.Exists("userdata.txt"))
                File.Delete("userdata.txt");

            if (File.Exists("chatlog.txt"))
                File.Delete("chatlog.txt");

            userName = "";
            userInterest = "";
            lastTopic = "";
        }

        private static void Log(string input, string response)
        {
            File.AppendAllText("chatlog.txt", $"User: {input}\nBot: {response}\n\n");
        }

        private static void ExportTips()
        {
            string fileName = "exported_tips.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Cybersecurity Tips:");
                foreach (var kvp in topicResponses)
                {
                    writer.WriteLine($"\n{kvp.Key.ToUpper()}:");
                    foreach (var tip in kvp.Value)
                    {
                        writer.WriteLine($"- {tip}");
                    }
                }
            }

            Console.WriteLine($"Tips exported to {fileName}");
        }

        public static void StartPasswordGame()
        {
            Console.WriteLine("\n[SECURITY] Welcome to the 'Guess the Safe Password' Game!");

            string[] passwords = new[]
            {
                "A1b2C3d4!",
                "P@ssw0rd123",
                "S3cur3#Password!",
                "Str0ngP@ssw0rd!",
                "1LoveCyber@Security!"
            };

            Console.WriteLine("\nWhich of these is the safest password?");
            for (int i = 0; i < passwords.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {passwords[i]}");
            }

            int correctIndex = 0;
            int attempts = 3;

            while (attempts > 0)
            {
                Console.Write("\n> Your guess (1-5): ");
                string guessInput = Console.ReadLine();
                if (int.TryParse(guessInput, out int guess) && guess >= 1 && guess <= 5)
                {
                    if (guess - 1 == correctIndex)
                    {
                        Console.WriteLine("[Correct] Great job! That’s a safe password.");
                        return;
                    }
                    else
                    {
                        attempts--;
                        if (attempts > 0)
                            Console.WriteLine($"[Incorrect] Try again. Attempts left: {attempts}");
                        else
                            Console.WriteLine($"[Answer] The correct password was option {correctIndex + 1}: {passwords[correctIndex]}");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 5.");
                }
            }
        }

        public static void StartQuiz()
        {
            var questions = new List<(string Question, string Answer)>
            {
                ("What is phishing?", "phishing"),
                ("What should a strong password include?", "special characters"),
                ("What is a privacy tip?", "limit sharing on social media"),
                ("What should you do with suspicious emails?", "avoid clicking"),
                ("What can protect your passwords?", "password manager")
            };

            int score = 0;

            Console.WriteLine("\n📋 [QUIZ MODE] Answer the following:");

            foreach (var (question, answer) in questions)
            {
                Console.WriteLine($"\n🧠 {question}");
                Console.Write("> ");
                var userAnswer = Console.ReadLine()?.ToLower();

                if (userAnswer != null && userAnswer.Contains(answer.ToLower()))
                {
                    Console.WriteLine("✅ Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"❌ Incorrect. Expected: {answer}");
                }
            }

            Console.WriteLine($"\n🏁 Quiz completed. Your score: {score}/{questions.Count}");

            File.AppendAllText("quizscores.txt", $"{userName} - Quiz - {score}/{questions.Count}\n");
        }

        public static void ShowLeaderboard()
        {
            string fileName = "quizscores.txt";

            if (!File.Exists(fileName))
            {
                Console.WriteLine("\n[Leaderboard] No quiz scores found yet.");
                return;
            }

            Console.WriteLine("\n📊 [Leaderboard - Top Scores]");

            var scores = File.ReadAllLines(fileName)
                .Select(line =>
                {
                    var parts = line.Split('-');
                    string user = parts[0].Trim();
                    string mode = parts[1].Trim();
                    int score = int.TryParse(parts[2].Trim().Split('/')[0], out int s) ? s : 0;
                    return new { User = user, Mode = mode, Score = score, Line = line };
                })
                .OrderByDescending(entry => entry.Score)
                .Take(10)
                .ToList();

            int rank = 1;
            foreach (var entry in scores)
            {
                Console.WriteLine($"{rank++}. {entry.Line}");
            }
        }
    }
}
