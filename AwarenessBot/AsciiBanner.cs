using System;
using Figgle;

namespace AwarenessChatbot
{
    public class AsciiBanner
    {
        public static void Show()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(FiggleFonts.Doom.Render("Cyber Bot"));
            Console.ResetColor();
        }
    }
}
