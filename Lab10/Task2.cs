using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab10
{
    public delegate Task AsyncStudentEventHandler(object sender, AsyncStudentEventArgs e);

    public class AsyncStudentEventArgs : EventArgs
    {
        public int Day { get; }
        public string EventType { get; }
        public int Priority { get; } 
        public string Result { get; set; }

        public AsyncStudentEventArgs(int day, string eventType, int priority)
        {
            Day = day;
            EventType = eventType;
            Priority = priority;
        }
    }

    public abstract class AsyncObserver
    {
        protected AdvancedStudentLife student;
        protected Random rnd = new Random();

        public AsyncObserver(AdvancedStudentLife student)
        {
            this.student = student;
        }

        public void On() => student.AsyncStudentEvent += HandleEventAsync;
        public void Off() => student.AsyncStudentEvent -= HandleEventAsync;

        public abstract Task HandleEventAsync(object sender, AsyncStudentEventArgs e);
    }


    public class AsyncDeanery : AsyncObserver
    {
        public AsyncDeanery(AdvancedStudentLife student) : base(student) { }

        public override async Task HandleEventAsync(object sender, AsyncStudentEventArgs e)
        {
            if (e.EventType == "Сесія")
            {
                await Task.Delay(1000);
                e.Result = rnd.Next(0, 10) > 3
                    ? "[Деканат]: Іспити перевірено асинхронно. Все здано!"
                    : "[Деканат]: Перевірка завершена. Є борги!";
            }
        }
    }

    public class AsyncParents : AsyncObserver
    {
        public AsyncParents(AdvancedStudentLife student) : base(student) { }

        public override async Task HandleEventAsync(object sender, AsyncStudentEventArgs e)
        {
            await Task.Delay(500);
            if (e.EventType == "Сесія") e.Result = "[Батьки]: Переказали гроші на картку.";
            else if (e.EventType == "Вечірка") e.Result = "[Батьки]: Написали в Viber: 'Чому не спиш?'";
        }
    }

    public class AdvancedStudentLife
    {
        private string studentName;
        private int daysToSimulate;

        public event AsyncStudentEventHandler AsyncStudentEvent;

        private Queue<AsyncStudentEventArgs> highPriorityQueue = new Queue<AsyncStudentEventArgs>();
        private Queue<AsyncStudentEventArgs> lowPriorityQueue = new Queue<AsyncStudentEventArgs>();

        private Dictionary<string, int> statistics = new Dictionary<string, int>();

        private AsyncDeanery deanery;
        private AsyncParents parents;

        public AdvancedStudentLife(string name, int days)
        {
            studentName = name;
            daysToSimulate = days;

            statistics.Add("Сесія", 0);
            statistics.Add("Вечірка", 0);

            deanery = new AsyncDeanery(this);
            parents = new AsyncParents(this);
            deanery.On();
            parents.On();
        }

        public void GenerateEvents()
        {
            Random rnd = new Random();
            Console.WriteLine($"=== Генерація подій на {daysToSimulate} днів ===");

            for (int day = 1; day <= daysToSimulate; day++)
            {
                double chance = rnd.NextDouble();
                if (chance < 0.20) 
                {
                    highPriorityQueue.Enqueue(new AsyncStudentEventArgs(day, "Сесія", 1));
                    Console.WriteLine($"[Заплановано]: День {day} - Сесія (Високий пріоритет)");
                }
                else if (chance > 0.70) 
                {
                    lowPriorityQueue.Enqueue(new AsyncStudentEventArgs(day, "Вечірка", 2));
                    Console.WriteLine($"[Заплановано]: День {day} - Вечірка (Низький пріоритет)");
                }
            }
            Console.WriteLine("Генерація завершена. Переходимо до обробки...\n");
        }

        public async Task ProcessEventsAsync()
        {
            Console.WriteLine("Початок асинхронної обробки подій");

            while (highPriorityQueue.Count > 0 || lowPriorityQueue.Count > 0)
            {
                AsyncStudentEventArgs currentEvent;

                if (highPriorityQueue.Count > 0)
                {
                    currentEvent = highPriorityQueue.Dequeue();
                }
                else
                {
                    currentEvent = lowPriorityQueue.Dequeue();
                }

                statistics[currentEvent.EventType]++;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nОБРОБКА: День {currentEvent.Day} | Подія: {currentEvent.EventType} (Пріоритет {currentEvent.Priority})");
                Console.ResetColor();

                if (AsyncStudentEvent != null)
                {
                    foreach (AsyncStudentEventHandler handler in AsyncStudentEvent.GetInvocationList())
                    {
                        await handler(this, currentEvent);

                        if (currentEvent.Result != null)
                        {
                            Console.WriteLine(currentEvent.Result);
                            currentEvent.Result = null;
                        }
                    }
                }
            }

            PrintStatistics();
        }

        private void PrintStatistics()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   СТАТИСТИКА ЗА ПЕВНИЙ ПЕРІОД   ");
            Console.WriteLine($"Усього днів промодельовано: {daysToSimulate}");
            foreach (var stat in statistics)
            {
                Console.WriteLine($"- Кількість подій '{stat.Key}': {stat.Value}");
            }
            Console.ResetColor();
        }
    }

    public class Task2
    {
        public static async Task RunAsync()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            AdvancedStudentLife advancedLife = new AdvancedStudentLife("Данило", 30);

            advancedLife.GenerateEvents();

            await advancedLife.ProcessEventsAsync();
        }
    }
}