using System;
using System.Text;
using System.Web;


namespace Password_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;           
 Console.WriteLine("               ██████   █████  ███████ ███████ ██     ██  ██████  ██████  ██████  ");
 Console.WriteLine("               ██   ██ ██   ██ ██      ██      ██     ██ ██    ██ ██   ██ ██   ██ ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
 Console.WriteLine("               ██████  ███████ ███████ ███████ ██  █  ██ ██    ██ ██████  ██   ██ ");      
 Console.WriteLine("               ██      ██   ██      ██      ██ ██ ███ ██ ██    ██ ██   ██ ██   ██ ");
            Console.ForegroundColor = ConsoleColor.Blue;
 Console.WriteLine(@"              ██      ██   ██ ███████ ███████  ███ ███   ██████  ██   ██ ██████          
     ");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
 Console.WriteLine("                            ██████  ███████ ███    ██ ███████ ██████   █████  ████████  ██████  ██████   ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
 Console.WriteLine("                            ██       ██      ████   ██ ██      ██   ██ ██   ██    ██    ██    ██ ██   ██ ");
 Console.WriteLine("                            ██   ███ █████   ██ ██  ██ █████   ██████  ███████    ██    ██    ██ ██████  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
 Console.WriteLine("                            ██    ██ ██      ██  ██ ██ ██      ██   ██ ██   ██    ██    ██    ██ ██   ██ ");
 Console.WriteLine(@"                            ██████  ███████ ██   ████ ███████ ██   ██ ██   ██    ██     ██████  ██   ██ 
");


            Console.WriteLine("===== > Choose password generation mode: ");
            Console.WriteLine(">>>> 1. Classic generator (random characters)");
            Console.WriteLine(">>>> 2. Based on keywords (name, pet, city, etc.)");
            Console.Write("===== > Enter option [1 or 2]: ");
            string mode = Console.ReadLine();

            if (mode == "1")
            {
                Console.Write("=== > Password Length: ");
                if (!int.TryParse(Console.ReadLine(), out int length))
                {
                    Console.WriteLine("Invalid number. Exiting.");
                    return;
                }

                Console.Write("=== > Include Capital Letters? (y/n): ");
                bool useUpper = Console.ReadLine().Trim().ToLower() == "y";

                Console.Write("=== > Include Lowercase? (y/n): ");
                bool useLower = Console.ReadLine().Trim().ToLower() == "y";

                Console.Write("=== > Include Symbols? (y/n): ");
                bool useSymbols = Console.ReadLine().Trim().ToLower() == "y";

                Console.Write("=== > Include Numbers? (y/n): ");
                bool useNumbers = Console.ReadLine().Trim().ToLower() == "y";

                Console.Write("=== > How many passwords to generate?: ");
                if (!int.TryParse(Console.ReadLine(), out int count))
                {
                    Console.WriteLine("Invalid number. Exiting.");
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n === Passwords generated ===");
                for (int i = 0; i < count; i++)
                {
                    string password = PasswordGenerator.Generate(length, useUpper, useLower, useNumbers, useSymbols);
                    Console.WriteLine($"[{i + 1}] {password}");
                }
            }
            else if (mode == "2")
            {
                Console.Write("Enter your keywords (name, pet, city, etc.), separated by commas: ");
                string input = Console.ReadLine();
                string[] keywords = input.Split(',');

                Console.Write("Enter desired password length: ");
                if (!int.TryParse(Console.ReadLine(), out int length))
                {
                    Console.WriteLine("Invalid number. Exiting.");
                    return;
                }

                Console.Write("How many passwords to generate?: ");
                if (!int.TryParse(Console.ReadLine(), out int count))
                {
                    Console.WriteLine("Invalid number. Exiting.");
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n === Passwords generated ===");
                for (int i = 0; i < count; i++)
                {
                    string password = PasswordGenerator.GenerateFromKeywords(keywords, length);
                    Console.WriteLine($"[{i + 1}] {password}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Option");
            }

            Console.ResetColor();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}