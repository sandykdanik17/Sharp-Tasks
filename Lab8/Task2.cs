using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab8
{
    public class WordLengthFilter
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            string inputPath = "input_task2.txt";
            string outputPath = "words_by_length.txt";

            if (!File.Exists(inputPath))
            {
                string dummyText = "Привіт! Це тестовий файл для другої задачі. " +
                                   "Програма повинна знаходити та виводити слова певної довжини. " +
                                   "Наприклад, слово університет має аж одинадцять літер!";
                File.WriteAllText(inputPath, dummyText);
            }

            string text = File.ReadAllText(inputPath);
            Console.WriteLine("Вміст вхідного файлу");
            Console.WriteLine(text);

            Console.Write("\nВведіть бажану довжину слова: ");
            if (!int.TryParse(Console.ReadLine(), out int targetLength) || targetLength <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка! Довжина має бути додатним цілим числом.");
                Console.ResetColor();
                return;
            }

            char[] separators = { ' ', '.', ',', '!', '?', ';', ':', '-', '(', ')', '\n', '\r', '\t', '"' };

            // гарантує, що між двома пробілами не з'явиться порожнє слово
            string[] allWords = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            List<string> resultWords = allWords.Where(w => w.Length == targetLength).ToList();

            if (resultWords.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nЗнайдено {resultWords.Count} слів довжиною {targetLength} символів:");
                Console.ResetColor();

                foreach (string w in resultWords)
                {
                    Console.WriteLine($"- {w}");
                }

                File.WriteAllLines(outputPath, resultWords);
                Console.WriteLine($"\nРезультат успішно збережено у файл: {outputPath}");
            }
            else
            {
                Console.WriteLine($"\nСлів довжиною {targetLength} символів у тексті не знайдено.");
            }
        }
    }
}