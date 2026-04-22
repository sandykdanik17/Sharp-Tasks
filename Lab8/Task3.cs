using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab8
{
    public class OddWordRemover
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string inputPath = "input_task3.txt";
            string outputPath = "result_task3.txt";

            if (!File.Exists(inputPath))
            {
                string dummyText = "Це тестовий рядок для перевірки коду. " +
                                   "Слова непарної довжини, такі як 'ліс', 'кіт' або 'сонце', будуть видалені. " +
                                   "А парні слова залишаться тут!";
                File.WriteAllText(inputPath, dummyText);
            }

            string text = File.ReadAllText(inputPath);
            Console.WriteLine("=== Оригінальний текст ===");
            Console.WriteLine(text);

            string result = Regex.Replace(text, @"\p{L}+", match =>
            {
                if (match.Value.Length % 2 != 0)
                {
                    return "";
                }
                else
                {
                    return match.Value; 
                }
            });

            // ми видалили слова, в тексті могли залишитися подвійні пробіли або пробіли перед комами
            result = Regex.Replace(result, @" {2,}", " "); // Замінюємо 2 і більше пробілів на 1
            result = Regex.Replace(result, @" ([,.!?:;])", "$1"); // Видаляємо пробіл перед розділовим знаком

            // 4. Виводимо результат
            Console.WriteLine("\nТекст після вилучення слів непарної довжини");
            Console.WriteLine(result);

            // 5. Записуємо у новий файл
            File.WriteAllText(outputPath, result);
            Console.WriteLine($"\nРезультат успішно збережено у файл: {outputPath}");
        }
    }
}