using System;
using System.IO;

namespace Lab8
{
    public class BinaryWordFilter
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            string filePath = "words_data.dat";

            Console.WriteLine("Завдання 4. Двійкові файли");

            CreateBinaryFile(filePath);

            Console.Write("\nВведіть шукану довжину слова: ");
            if (!int.TryParse(Console.ReadLine(), out int targetLength) || targetLength <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка! Введіть додатне ціле число.");
                Console.ResetColor();
                return;
            }

            ReadAndFilterBinaryFile(filePath, targetLength);
        }

        private static void CreateBinaryFile(string path)
        {
            string[] words = { "університет", "код", "програма", "кіт", "ліс", "сонце", "студент", "мир", "шафа" };

            // Використовуємо BinaryWriter для запису двійкових даних
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (string word in words)
                {
                    writer.Write(word);
                }
            }
            Console.WriteLine($"[+] Двійковий файл '{path}' успішно створено та заповнено ({words.Length} слів).");

            Console.WriteLine("Слова, які були записані: " + string.Join(", ", words));
        }

        private static void ReadAndFilterBinaryFile(string path, int targetLength)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nСлова з двійкового файлу, довжина яких дорівнює {targetLength}:");
            Console.ResetColor();

            bool found = false;

            // Використовуємо BinaryReader для читання двійкових даних
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    // ReadString() сам знає, скільки байтів займає наступне слово
                    string word = reader.ReadString();

                    if (word.Length == targetLength)
                    {
                        Console.WriteLine($"- {word}");
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Слів такої довжини у файлі не знайдено.");
            }
        }
    }
}