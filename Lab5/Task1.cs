using System;

namespace Lab5
{
    abstract class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set;  }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        ~Person()
        {

        }

        public abstract void Show();

        public int CompareTo(Person other)
        {
            if (other == null) return 1;
            return this.Age.CompareTo(other.Age);
        }
    }

    class Employee  : Person
    {
        public double Salary { get; set; }

        public Employee(string name, int age, double salary) : base(name, age)
        {
            Salary = salary;
        }

        public override void Show()
        {
            Console.WriteLine($"[Службовець] Ім'я:{Name}, Вік: {Age}, Зарплата: {Salary} грн");
        }
    }

    class Worker : Employee
    {
        public string Specialty { get; set; }

        public Worker(string name, int age, double salary, string specialty) : base(name, age, salary )
        {
            Specialty = specialty;
        }

        public override void Show()
        {
            Console.WriteLine($"[Робітник] Ім'я: {Name}, Вік: {Age}, Зарплата: {Salary} грн, Спеціальність: {Specialty}");
        }
    }

    class Engineer : Employee
    {
        public string Project { get; set; }

        public Engineer(string name, int age, double salary, string project) : base(name, age, salary)
        {
            Project = project;
        }

        public override void Show()
        {
            Console.WriteLine($"[Інженер] Ім'я: {Name}, Вік: {Age}, Зарплата: {Salary} грн, Проєкт: {Project}");
        }
    }

    class Task1
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Завдання 1: Ієрархія класів");

            Person[] people = new Person[]
            {
                new Engineer("Олена", 28, 45000, "Розробка ШІ"),
                new Worker("Іван", 45, 25000, "Токар-фрезерувальник"),
                new Employee("Марія", 35, 18000),
                new Engineer("Віктор", 50, 60000, "Будівництво мосту")
            };

            Console.WriteLine("\nМасив ДО сортування:");
            foreach (Person p in people)
            {
                p.Show();
            }

            Array.Sort(people);

            Console.WriteLine("\nМасив ПІСЛЯ сортування за віком");
            foreach (Person p in people)
            {
                p.Show();
            }

            Console.WriteLine("\nНатисніть Enter для повернення...");
            Console.ReadLine();
        }
    }
}
