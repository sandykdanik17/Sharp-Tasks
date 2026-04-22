using System;
using System.Collections;
using System.IO;

namespace Lab9
{
    public class Task3
    {
        public static void Run()
        {
            Console.WriteLine("=== Завдання 3. Використання ArrayList ===");
            Console.WriteLine("1. Переписати Завдання 1.7 (Стек через ArrayList)");
            Console.WriteLine("2. Переписати Завдання 2.7 (Черга через ArrayList)");
            Console.Write("Виберіть підзавдання (1 або 2): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                RunTask1_ArrayList();
            }
            else if (choice == "2")
            {
                RunTask2_ArrayList();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Невірний вибір.");
                Console.ResetColor();
            }
        }


        // Імітація Стека через ArrayList

        private static void RunTask1_ArrayList()
        {
            Console.WriteLine("Постфікс -> Префікс (через ArrayList)");
            Console.Write("Введіть постфіксний вираз (через пробіл, напр. A B +): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) return;

            string[] tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Замість Stack<string> використовуємо універсальний ArrayList
            ArrayList fakeStack = new ArrayList();

            try
            {
                foreach (string token in tokens)
                {
                    if (token == "+" || token == "-" || token == "*" || token == "/" || token == "^")
                    {
                        if (fakeStack.Count < 2) throw new Exception("Не вистачає операндів!");

                        int lastIdx = fakeStack.Count - 1;
                        string op1 = (string)fakeStack[lastIdx]; 
                        fakeStack.RemoveAt(lastIdx);

                        lastIdx = fakeStack.Count - 1;
                        string op2 = (string)fakeStack[lastIdx];
                        fakeStack.RemoveAt(lastIdx);

                        string tempPrefix = token + " " + op2 + " " + op1;

                        fakeStack.Add(tempPrefix);
                    }
                    else
                    {
                        fakeStack.Add(token); 
                    }
                }

                if (fakeStack.Count != 1) throw new Exception("Забагато операндів!");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nРезультат: {(string)fakeStack[0]}\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nПомилка: " + ex.Message + "\n");
                Console.ResetColor();
            }
        }

        private static void RunTask2_ArrayList()
        {
            Console.WriteLine("--- Сортування співробітників (через ArrayList) ---");
            string filePath = "employees.txt";

            if (!File.Exists(filePath))
            {
                File.WriteAllLines(filePath, new string[] {
                    "Шевченко Тарас Григорович Чоловіча 35 12000",
                    "Косач Лариса Петрівна Жіноча 28 9500",
                    "Франко Іван Якович Чоловіча 40 15000",
                    "Сандюк Данило Іванович Чоловіча 19 8000"
                });
            }

            ArrayList lowSalaryList = new ArrayList();
            ArrayList highSalaryList = new ArrayList();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > 0)
                    {
                        if (double.TryParse(parts[parts.Length - 1], out double salary))
                        {
                            if (salary < 10000)
                                lowSalaryList.Add(line);
                            else
                                highSalaryList.Add(line);
                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nСпівробітники із зарплатою МЕНШЕ 10000");
            Console.ResetColor();

            foreach (object emp in lowSalaryList)
            {
                Console.WriteLine((string)emp);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nІнші співробітники (Зарплата >= 10000)");
            Console.ResetColor();

            foreach (object emp in highSalaryList)
            {
                Console.WriteLine((string)emp);
            }
            Console.WriteLine();
        }
    }
}