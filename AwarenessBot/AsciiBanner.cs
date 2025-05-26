using System;
using Figgle; // Make sure Figgle is referenced

namespace AwarenessChatbot
{
    public static class AsciiBanner
    {
        public static void Show()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(FiggleFonts.Standard.Render("CyberBot"));
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║        Welcome to the Cyber Awareness Bot      ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");
            Console.ResetColor();
        }
    }
}
