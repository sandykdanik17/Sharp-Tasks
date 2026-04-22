using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab8
{
    public class IPProcessor
    {
        // Регулярний вираз для валідної IP-адреси (0.0.0.0 - 255.255.255.255)
        private const string IPPattern = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string inputPath = "input.txt";
            string outputPath = "found_ips.txt";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "Сервер 1: 192.168.1.1, шлюз: 10.0.0.255. Неправильний IP: 999.1.1.1. Мій комп: 127.0.0.1.");
            }

            string text = File.ReadAllText(inputPath);
            Console.WriteLine("Вміст вхідного файлу");
            Console.WriteLine(text);

            MatchCollection matches = Regex.Matches(text, IPPattern);
            List<string> foundIPs = new List<string>();

            foreach (Match match in matches)
            {
                foundIPs.Add(match.Value);
            }

            Console.WriteLine($"\nЗнайдено IP-адрес: {foundIPs.Count}");
            foreach (var ip in foundIPs) Console.WriteLine($"- {ip}");

            File.WriteAllLines(outputPath, foundIPs);
            Console.WriteLine($"\nВсі знайдені адреси збережено у файл: {outputPath}");

            Console.WriteLine("\nОперація заміни");
            Console.Write("Введіть IP, який треба замінити: ");
            string targetIP = Console.ReadLine();
            Console.Write("Введіть новий IP (або залиште порожнім для вилучення): ");
            string newIP = Console.ReadLine();

            string updatedText = Regex.Replace(text, targetIP, newIP);

            Console.WriteLine("\n=== Оновлений текст ===");
            Console.WriteLine(updatedText);

            File.WriteAllText("input.txt", updatedText);
        }
    }
}