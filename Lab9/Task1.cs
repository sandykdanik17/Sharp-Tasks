using System;
using System.Collections.Generic;

namespace Lab9
{
    public class Task1
    {
        // перевірка чи є символ математичним оператором
        private static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/" || token == "^";
        }

       
        public static string ConvertPostfixToPrefix(string postfix)
        {
            // стек для зберігання проміжних рядків
            Stack<string> stack = new Stack<string>();

           
            string[] tokens = postfix.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                if (IsOperator(token))
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Неправильний постфіксний вираз (не вистачає операндів)!");
                    }

                    string operand1 = stack.Pop(); 
                    string operand2 = stack.Pop(); 

                    string tempPrefix = token + " " + operand2 + " " + operand1;

                    stack.Push(tempPrefix);
                }
                else
                {
                    stack.Push(token);
                }
            }
            if (stack.Count != 1)
            {
                throw new ArgumentException("Неправильний постфіксний вираз (забагато операндів)!");
            }

            return stack.Pop();
        }

        public static void Run()
        {
            Console.WriteLine("Завдання 1.7. Постфікс -> Префікс");
            Console.WriteLine("Введіть постфіксний вираз.");
            Console.WriteLine("ВАЖЛИВО: розділяйте всі символи пробілами (наприклад: A B + C *)");
            Console.Write("Ваш вираз: ");

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Вираз не може бути порожнім.");
                return;
            }

            try
            {
                string result = ConvertPostfixToPrefix(input);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nРезультат (префіксна форма): {result}\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nПомилка: {ex.Message}\n");
                Console.ResetColor();
            }
        }
    }
}