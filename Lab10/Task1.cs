using System;

namespace Lab10
{
    // Оголошення делегата, на основі якого буде створена подія
    public delegate void StudentEventHandler(object sender, StudentEventArgs e);

    public class StudentEventArgs : EventArgs
    {
        public int Day { get; }
        public string EventType { get; }
        public string Result { get; set; }

        public StudentEventArgs(int day, string eventType)
        {
            Day = day;
            EventType = eventType;
        }
    }

    public abstract class Observer
    {
        protected StudentLife student;
        protected Random rnd = new Random();

        public Observer(StudentLife student)
        {
            this.student = student;
        }

        public void On()
        {
            student.StudentEvent += new StudentEventHandler(HandleEvent);
        }

        public void Off()
        {
            student.StudentEvent -= new StudentEventHandler(HandleEvent);
        }

        public abstract void HandleEvent(object sender, StudentEventArgs e);
    }

    public class Deanery : Observer
    {
        public Deanery(StudentLife student) : base(student) { }

        public override void HandleEvent(object sender, StudentEventArgs e)
        {
            if (e.EventType == "Сесія")
            {
                if (rnd.Next(0, 10) > 3)
                    e.Result = "[Деканат]: Студент успішно здав усі іспити! Стипендія призначена.";
                else
                    e.Result = "[Деканат]: Є борги! Студент відправлений на перездачу.";
            }
        }
    }

    public class Parents : Observer
    {
        public Parents(StudentLife student) : base(student) { }

        public override void HandleEvent(object sender, StudentEventArgs e)
        {
            if (e.EventType == "Сесія")
            {
                e.Result = "[Батьки]: Хвилюємося за оцінки. Надіслали гроші на їжу.";
            }
            else if (e.EventType == "Вечірка")
            {
                e.Result = "[Батьки]: Дзвонили, питали, чому грає гучна музика.";
            }
        }
    }

    public class Friends : Observer
    {
        public Friends(StudentLife student) : base(student) { }

        public override void HandleEvent(object sender, StudentEventArgs e)
        {
            if (e.EventType == "Вечірка")
            {
                e.Result = "[Друзі]: Прийшли в гості з піцою! Чудовий вечір.";
            }
            else if (e.EventType == "Сесія")
            {
                e.Result = "[Друзі]: Скинули конспекти в Telegram.";
            }
        }
    }

    public class StudentLife
    {
        private string studentName;
        private string university;
        private int daysToSimulate;

        public event StudentEventHandler StudentEvent;
        private string[] resultService;
        private Random rnd = new Random();

        private Deanery deanery;
        private Parents parents;
        private Friends friends;

        public StudentLife(string name, string uni, int days)
        {
            studentName = name;
            university = uni;
            daysToSimulate = days;

            deanery = new Deanery(this);
            parents = new Parents(this);
            friends = new Friends(this);

            deanery.On();
            parents.On();
            friends.On();
        }

        protected virtual void OnStudentEvent(StudentEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n---> День {e.Day}: У студента {studentName} ({university}) сталася подія: {e.EventType}!");
            Console.ResetColor();


            if (StudentEvent != null)
            {
                Delegate[] eventHandlers = StudentEvent.GetInvocationList();
                resultService = new string[eventHandlers.Length];
                int k = 0;

                foreach (StudentEventHandler evHandler in eventHandlers)
                {
                    evHandler(this, e);
                    if (e.Result != null)
                    {
                        resultService[k++] = e.Result;
                        e.Result = null; 
                    }
                }
            }
        }

        public void SimulateLife()
        {
            Console.WriteLine($"=== Починаємо симуляцію життя студента: {studentName} ===");

            for (int day = 1; day <= daysToSimulate; day++)
            {
                double chance = rnd.NextDouble();

                if (chance < 0.15)
                {
                    StudentEventArgs e = new StudentEventArgs(day, "Сесія");
                    OnStudentEvent(e);
                    PrintResults();
                }
                else if (chance > 0.80)
                {
                    StudentEventArgs e = new StudentEventArgs(day, "Вечірка");
                    OnStudentEvent(e);
                    PrintResults();
                }
            }
            Console.WriteLine("\nСимуляція завершена");
        }

        private void PrintResults()
        {
            for (int i = 0; i < resultService.Length; i++)
            {
                if (!string.IsNullOrEmpty(resultService[i]))
                {
                    Console.WriteLine(resultService[i]);
                }
            }
            Array.Clear(resultService, 0, resultService.Length);
        }
    }

    public class Task1
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            StudentLife myLife = new StudentLife("Степан", "ЧНУ", 30);
            myLife.SimulateLife();
        }
    }
}