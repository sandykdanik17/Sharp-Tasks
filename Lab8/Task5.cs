using System;
using System.IO;

namespace Lab8.Task5
{
    public class FileSystemManager
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Базова директорія та ім'я студента
            string baseDir = @"c:\temp";
            string studentName = "Sandiuk";

            // Шляхи до папок
            string dir1 = Path.Combine(baseDir, studentName + "1"); 
            string dir2 = Path.Combine(baseDir, studentName + "2"); 
            string dirAll = Path.Combine(baseDir, "ALL");           

            try
            {
                Console.WriteLine("Початок виконання операцій з файлами\n");

                if (!Directory.Exists(baseDir))
                {
                    Directory.CreateDirectory(baseDir);
                }

                // Створення папок Sandiuk1 та Sandiuk2
                Directory.CreateDirectory(dir1);
                Directory.CreateDirectory(dir2);
                Console.WriteLine($"1. Папки {studentName}1 та {studentName}2 успішно створено.");

                // Створення файлів t1.txt та t2.txt у першій папці
                string t1Path = Path.Combine(dir1, "t1.txt");
                string t2Path = Path.Combine(dir1, "t2.txt");

                string text1 = "Шевченко Степан Іванович, 2001 року народження, місце проживання м. Суми\n";
                string text2 = "Комар Сергій Федорович, 2000 року народження, місце проживання м. Київ\n";

                File.WriteAllText(t1Path, text1);
                File.WriteAllText(t2Path, text2);
                Console.WriteLine("2. Файли t1.txt та t2.txt створено та заповнено.");

                // Створення файлу t3.txt у другій папці
                string t3Path = Path.Combine(dir2, "t3.txt");
                string combinedText = File.ReadAllText(t1Path) + File.ReadAllText(t2Path);
                File.WriteAllText(t3Path, combinedText);
                Console.WriteLine("3. Файл t3.txt створено (тексти об'єднано).");

                // Виведення розгорнутої інформації про створені файли
                Console.WriteLine("\n4. Інформація про початкові файли");
                PrintFileInfo(t1Path);
                PrintFileInfo(t2Path);
                PrintFileInfo(t3Path);

                // Перенесення t2.txt у папку Sandiuk2
                string t2NewPath = Path.Combine(dir2, "t2.txt");
                if (File.Exists(t2NewPath)) File.Delete(t2NewPath); // Перестраховка, якщо файл вже там є
                File.Move(t2Path, t2NewPath);
                Console.WriteLine("\n5. Файл t2.txt перенесено.");

                // Копіювання t1.txt у папку Sandiuk2
                string t1CopyPath = Path.Combine(dir2, "t1.txt");
                File.Copy(t1Path, t1CopyPath, true); 
                Console.WriteLine("6. Файл t1.txt скопійовано.");

               
                // Якщо папка ALL вже існує з минулого запуску, видаляємо її
                if (Directory.Exists(dirAll)) Directory.Delete(dirAll, true);

                Directory.Move(dir2, dirAll); 
                Directory.Delete(dir1, true); 
                Console.WriteLine("7. Папку перейменовано на ALL, першу папку вилучено.");

                // 8. Виведення інформації про файли в папці ALL
                Console.WriteLine("\n8. Повна інформація про файли папки ALL");
                string[] finalFiles = Directory.GetFiles(dirAll);
                foreach (string file in finalFiles)
                {
                    PrintFileInfo(file);
                }

                Console.WriteLine("\nВсі завдання успішно виконано!");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nСталася помилка: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void PrintFileInfo(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            if (info.Exists)
            {
                Console.WriteLine($"- Назва: {info.Name}");
                Console.WriteLine($"  Розмір: {info.Length} байт");
                Console.WriteLine($"  Створено: {info.CreationTime}");
                Console.WriteLine($"  Шлях: {info.FullName}\n");
            }
        }
    }
}