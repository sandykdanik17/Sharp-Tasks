using System;
using System.Collections.Generic;
using System.IO;

namespace Lab9
{
    public class Task2
    {
        public static void Run()
        {
            Console.WriteLine("Завдання 2.7. Сортування співробітників (Queue)\n");

            string filePath = "employees.txt";

            CreateDummyFileIfNotExists(filePath);

            Queue<string> lowSalaryQueue = new Queue<string>();
            Queue<string> highSalaryQueue = new Queue<string>();

            Console.WriteLine("Читання файлу та сортування...\n");

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Припускаємо, що дані розділені пробілами, а зарплата - це останнє слово
                        string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length > 0)
                        {
                            string salaryStr = parts[parts.Length - 1];

                            if (double.TryParse(salaryStr, out double salary))
                            {
                                if (salary < 10000)
                                {
                                    lowSalaryQueue.Enqueue(line);
                                }
                                else
                                {
                                    highSalaryQueue.Enqueue(line);
                                }
                            }
                        }
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Співробітники із зарплатою МЕНШЕ 10000");
                Console.ResetColor();

                while (lowSalaryQueue.Count > 0)
                {
                    Console.WriteLine(lowSalaryQueue.Dequeue());
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- Інші співробітники (Зарплата >= 10000) ---");
                Console.ResetColor();

                while (highSalaryQueue.Count > 0)
                {
                    Console.WriteLine(highSalaryQueue.Dequeue());
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Помилка при роботі з файлом: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void CreateDummyFileIfNotExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                string[] dummyData = {
                    "Шевченко Тарас Григорович Чоловіча 35 12000",
                    "Косач Лариса Петрівна Жіноча 28 9500",
                    "Франко Іван Якович Чоловіча 40 15000",
                    "Сандюк Данило Іванович Чоловіча 19 8000",
                    "Українка Леся Петрівна Жіноча 32 10500",
                    "Грушевський Михайло Сергійович Чоловіча 50 9000"
                };

                File.WriteAllLines(filePath, dummyData);
                Console.WriteLine($"[+] Створено тестовий файл '{filePath}' з даними.\n");
            }
        }
    }
}