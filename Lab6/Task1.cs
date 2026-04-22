using System;

namespace Lab6.Task1
{
    // Інтерфейс Персони (описує базові дані людини)
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        void Show();
    }

    // Інтерфейс Працівника (описує робочі характеристики)
    public interface IEmployee
    {
        double Salary { get; set; }
        void ReceiveBonus(); 
    }

 

    // Клас Службовець реалізує ОДРАЗУ ТРИ інтерфейси: 
    public class Employee : IPerson, IEmployee, IComparable<Employee>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public Employee(string name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        // Реалізація інтерфейсних методів
        public virtual void Show()
        {
            Console.WriteLine($"[Службовець] Ім'я: {Name}, Вік: {Age}, Зарплата: {Salary} грн");
        }

        public void ReceiveBonus()
        {
            Console.WriteLine($" => {Name} отримує премію 10% ({Salary * 0.1} грн)");
        }

        // Реалізація інтерфейсу .NET (IComparable)
        public int CompareTo(Employee other)
        {
            if (other == null) return 1;
            return this.Salary.CompareTo(other.Salary);
        }

        public void AttendMeeting()
        {
            Console.WriteLine($"   * {Name} присутній на загальних зборах компанії.");
        }
    }

    public class Worker : Employee
    {
        public string Specialty { get; set; }

        public Worker(string name, int age, double salary, string specialty)
            : base(name, age, salary)
        {
            Specialty = specialty;
        }

        public override void Show()
        {
            Console.WriteLine($"[Робітник] Ім'я: {Name}, Вік: {Age}, Зарплата: {Salary} грн, Спеціальність: {Specialty}");
        }

        public void OperateMachine()
        {
            Console.WriteLine($"   * {Name} запускає верстат за спеціальністю {Specialty}.");
        }
    }

    public class Engineer : Employee
    {
        public string Project { get; set; }

        public Engineer(string name, int age, double salary, string project)
            : base(name, age, salary)
        {
            Project = project;
        }

        public override void Show()
        {
            Console.WriteLine($"[Інженер] Ім'я: {Name}, Вік: {Age}, Зарплата: {Salary} грн, Проєкт: {Project}");
        }

        public void DesignArchitecture()
        {
            Console.WriteLine($"   * {Name} розробляє креслення для проєкту «{Project}».");
        }
    }

    public class Task1
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\n=== Завдання 1: Інтерфейси та Type Pattern ===");

            IPerson[] staff = new IPerson[]
            {
                new Employee("Марія", 25, 20000),
                new Worker("Іван", 45, 25000, "Токар"),
                new Engineer("Олена", 32, 50000, "Новий міст")
            };

            Console.WriteLine("\n1. Виклик інтерфейсних методів (Show):");
            foreach (IPerson person in staff)
            {
                person.Show(); 
            }

            Console.WriteLine("\n2. Виклик особистих методів через Type Pattern:");
            CallSpecificMethods(staff);

            Console.WriteLine("\nНатисніть Enter для повернення...");
            Console.ReadLine();
        }

        public static void CallSpecificMethods(IPerson[] people)
        {
            foreach (IPerson person in people)
            {
                // Використовуємо Pattern Matching (зіставлення типів)
                switch (person)
                {
                    case Engineer eng:
                        // Якщо person насправді Інженер, він автоматично розпаковується в змінну eng
                        eng.DesignArchitecture();
                        break;

                    case Worker w:
                        w.OperateMachine();
                        break;

                    case Employee emp:
                        emp.AttendMeeting();
                        break;
                }
            }
        }
    }
}