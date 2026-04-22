using System;
using System.Collections; // Обов'язково для Hashtable

namespace Lab9
{
    public class Task4
    {
        // Наша головна база даних (Каталог)
        private static Hashtable catalog = new Hashtable();

        public static void Run()
        {
            Hashtable rockCD = new Hashtable();
            rockCD.Add("Bohemian Rhapsody", "Queen");
            rockCD.Add("Hotel California", "Eagles");
            catalog.Add("Rock Hits", rockCD);

            Hashtable popCD = new Hashtable();
            popCD.Add("Toxic", "Britney Spears");
            popCD.Add("Bad Romance", "Lady Gaga");
            popCD.Add("Poker Face", "Lady Gaga");
            catalog.Add("Pop 2000s", popCD);

            while (true)
            {
                Console.WriteLine("    КАТАЛОГ МУЗИЧНИХ CD (Hashtable)");
                Console.WriteLine("1. Переглянути весь каталог");
                Console.WriteLine("2. Переглянути конкретний диск");
                Console.WriteLine("3. Додати новий диск");
                Console.WriteLine("4. Видалити диск");
                Console.WriteLine("5. Додати пісню на диск");
                Console.WriteLine("6. Видалити пісню з диску");
                Console.WriteLine("7. Пошук усіх пісень за ВИКОНАВЦЕМ");
                Console.WriteLine("0. Повернутися до головного меню");
                Console.Write("Оберіть дію: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": ViewCatalog(); break;
                    case "2": ViewCD(); break;
                    case "3": AddCD(); break;
                    case "4": RemoveCD(); break;
                    case "5": AddSong(); break;
                    case "6": RemoveSong(); break;
                    case "7": SearchByArtist(); break;
                    case "0": return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        Console.ResetColor();
                        break;
                }
            }
        }


        private static void ViewCatalog()
        {
            if (catalog.Count == 0)
            {
                Console.WriteLine("Каталог порожній.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- ВМІСТ УСЬОГО КАТАЛОГУ ---");
            Console.ResetColor();

            foreach (DictionaryEntry cdEntry in catalog)
            {
                string cdName = (string)cdEntry.Key;
                Hashtable songs = (Hashtable)cdEntry.Value;

                Console.WriteLine($"\n💿 Диск: [{cdName}] (Кількість пісень: {songs.Count})");

                foreach (DictionaryEntry songEntry in songs)
                {
                    Console.WriteLine($"   🎵 {(string)songEntry.Key} - {(string)songEntry.Value}");
                }
            }
        }

        private static void ViewCD()
        {
            Console.Write("Введіть назву диску: ");
            string cdName = Console.ReadLine();

            if (catalog.ContainsKey(cdName))
            {
                Hashtable songs = (Hashtable)catalog[cdName];
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n--- ВМІСТ ДИСКУ [{cdName}] ---");
                Console.ResetColor();

                if (songs.Count == 0) Console.WriteLine("Цей диск поки що порожній.");

                foreach (DictionaryEntry songEntry in songs)
                {
                    Console.WriteLine($"🎵 {(string)songEntry.Key} - {(string)songEntry.Value}");
                }
            }
            else
            {
                Console.WriteLine($"Диск '{cdName}' не знайдено!");
            }
        }

        private static void AddCD()
        {
            Console.Write("Введіть назву НОВОГО диску: ");
            string cdName = Console.ReadLine();

            if (catalog.ContainsKey(cdName))
            {
                Console.WriteLine("Диск з такою назвою вже існує!");
            }
            else
            {
                catalog.Add(cdName, new Hashtable());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Диск '{cdName}' успішно додано!");
                Console.ResetColor();
            }
        }

        private static void RemoveCD()
        {
            Console.Write("Введіть назву диску для ВИДАЛЕННЯ: ");
            string cdName = Console.ReadLine();

            if (catalog.ContainsKey(cdName))
            {
                catalog.Remove(cdName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Диск '{cdName}' повністю видалено!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Диск '{cdName}' не знайдено!");
            }
        }

        private static void AddSong()
        {
            Console.Write("На який диск додати пісню?: ");
            string cdName = Console.ReadLine();

            if (catalog.ContainsKey(cdName))
            {
                Hashtable songs = (Hashtable)catalog[cdName];

                Console.Write("Введіть НАЗВУ пісні: ");
                string songName = Console.ReadLine();

                if (songs.ContainsKey(songName))
                {
                    Console.WriteLine("Пісня з такою назвою вже є на цьому диску!");
                    return;
                }

                Console.Write("Введіть ВИКОНАВЦЯ пісні: ");
                string artist = Console.ReadLine();

                songs.Add(songName, artist);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Пісню '{songName}' додано на диск '{cdName}'.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Диск '{cdName}' не знайдено!");
            }
        }

        private static void RemoveSong()
        {
            Console.Write("З якого диску видалити пісню?: ");
            string cdName = Console.ReadLine();

            if (catalog.ContainsKey(cdName))
            {
                Hashtable songs = (Hashtable)catalog[cdName];
                Console.Write("Введіть НАЗВУ пісні для видалення: ");
                string songName = Console.ReadLine();

                if (songs.ContainsKey(songName))
                {
                    songs.Remove(songName);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Пісню '{songName}' видалено!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"Пісню '{songName}' не знайдено на цьому диску!");
                }
            }
            else
            {
                Console.WriteLine($"Диск '{cdName}' не знайдено!");
            }
        }

        private static void SearchByArtist()
        {
            Console.Write("Введіть ім'я ВИКОНАВЦЯ для пошуку: ");
            string searchArtist = Console.ReadLine();
            bool found = false;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nРЕЗУЛЬТАТИ ПОШУКУ: {searchArtist}");
            Console.ResetColor();

            foreach (DictionaryEntry cdEntry in catalog)
            {
                string cdName = (string)cdEntry.Key;
                Hashtable songs = (Hashtable)cdEntry.Value;

                foreach (DictionaryEntry songEntry in songs)
                {
                    string currentArtist = (string)songEntry.Value;
                    string songTitle = (string)songEntry.Key;

                    if (currentArtist.ToLower().Contains(searchArtist.ToLower()))
                    {
                        Console.WriteLine($"На диску [{cdName}]: {songTitle}");
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("У каталозі не знайдено жодної пісні цього виконавця.");
            }
        }
    }
}