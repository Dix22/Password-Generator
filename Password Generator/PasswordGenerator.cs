using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Password_Generator
{
    public class PasswordGenerator
    {
        private static readonly string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string Lower = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string Digits = "0123456789";
        private static readonly string Symbols = "!@#$%^&*()-_=+[]{};:,.<>?";

        private static readonly Random rand = new Random();

        public static string Generate(int length, bool useUpper, bool useLower, bool useNumbers, bool useSymbols)
        {
            StringBuilder charpool = new StringBuilder();

            if (useUpper) charpool.Append(Upper);
            if (useLower) charpool.Append(Lower);
            if (useNumbers) charpool.Append(Digits);
            if (useSymbols) charpool.Append(Symbols);

            if (charpool.Length == 0)
                throw new ArgumentException("You must select at least one character type.");

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = rand.Next(charpool.Length);
                result.Append(charpool[index]);
            }

            string password = result.ToString();

            File.AppendAllText("passwords.txt",
                $"--- Random Passwords ---{Environment.NewLine}" +
                $"{DateTime.Now}: {password}{Environment.NewLine}{Environment.NewLine}");

            return password;
        }

        public static string GenerateFromKeywords(string[] keywords, int length)
        {
            if (keywords == null || keywords.Length == 0)
                throw new ArgumentException("At least one keyword is required.");

            Dictionary<char, char> leetMap = new Dictionary<char, char>()
            {
                { 'a', '@' }, { 'A', '@' },
                { 'e', '3' }, { 'E', '3' },
                { 'i', '1' }, { 'I', '1' },
                { 'o', '0' }, { 'O', '0' },
                { 's', '$' }, { 'S', '$' }
            };

            string[] symbols = { "!", "*", "#", "?" };

            
            keywords = keywords.OrderBy(_ => rand.Next()).ToArray();

            StringBuilder passwordBuilder = new StringBuilder();

            foreach (var word in keywords)
            {
                string clean = word.Trim();
                if (clean.Length == 0)
                    continue;

                int fragLength = rand.Next(3, Math.Min(7, clean.Length + 1)); 

                string fragment = clean.Substring(0, fragLength);

                StringBuilder transformed = new StringBuilder();
                foreach (char c in fragment)
                    transformed.Append(leetMap.ContainsKey(c) ? leetMap[c] : c);

                if (transformed.Length > 0 && rand.Next(2) == 0)
                    transformed[0] = char.ToUpper(transformed[0]);

                passwordBuilder.Append(transformed);
            }

            
            int inserts = rand.Next(1, 3);
            for (int i = 0; i < inserts; i++)
            {
                int pos = rand.Next(passwordBuilder.Length + 1);
                char insertChar = rand.Next(2) == 0 ? symbols[rand.Next(symbols.Length)][0] : Digits[rand.Next(Digits.Length)];
                passwordBuilder.Insert(pos, insertChar);
            }

            
            while (passwordBuilder.Length < length)
            {
                passwordBuilder.Append(Digits[rand.Next(Digits.Length)]);
            }

            if (passwordBuilder.Length > length)
                passwordBuilder.Length = length;

            string finalPassword = passwordBuilder.ToString();

            File.AppendAllText("passwords.txt",
                $"--- Keyword Passwords ---{Environment.NewLine}" +
                $"{DateTime.Now}: {finalPassword}{Environment.NewLine}{Environment.NewLine}");

            return finalPassword;
        }

        public static string ShuffleString(string input)
        {
            char[] array = input.ToCharArray();
            int n = array.Length;
            for (int i = n - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                char temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return new string(array);
        }
    }
}
