using System;
using System.Collections.Generic;

namespace ITDepartmentDemo
{
    //Базовый класс: Сотрудник
    public class Employee
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public string Department { get; set; }

        public Employee(string name, int employeeId, string department)
        {
            Name = name;
            EmployeeId = employeeId;
            Department = department;
        }

        //Виртуальный метод для вывода информации
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Сотрудник: {Name}\nID: {EmployeeId}\nОтдел: {Department}");
        }

        //Виртуальный метод работы
        public virtual void Work()
        {
            Console.WriteLine($"{Name} выполняет общие рабочие задачи связанные с его специальностью");
        }
    }

    //Производный класс: IT-Сотрудник
    public class ITEmployee : Employee
    {
        public string ProgrammingLanguage { get; set; }
        public List<string> Skills { get; } = new List<string>();

        public ITEmployee(string name, int employeeId, string programmingLanguage)
            : base(name, employeeId, "IT Отдел")
        {
            ProgrammingLanguage = programmingLanguage;
        }

        //Переопределение метода вывода информации
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Язык программирования: {ProgrammingLanguage}");
            Console.WriteLine($"Навыки: {string.Join(", ", Skills)}");
        }

        //Переопределение метода работы
        public override void Work()
        {
            Console.WriteLine($"{Name} разрабатывает ПО на {ProgrammingLanguage}");
        }

        //Метод, специфичный для IT-сотрудников
        public void AddSkill(string skill)
        {
            Skills.Add(skill);
            Console.WriteLine($"{Name} освоил новый навык: {skill}");
        }

        //Метод, специфичный для IT-сотрудников
        public void FixBug()
        {
            Console.WriteLine($"{Name} начал исправлять ошибки и баги в своем коде");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демонстрация работы с базовым классом ");

            //Сотрудник
            Employee accountant = new Employee("Петр Петров", 1001, "Отдел продаж");
            accountant.DisplayInfo();
            accountant.Work();

            Console.WriteLine("\nДемонстрация работы с производным классом ");

            //IT-сотрудник
            ITEmployee developer = new ITEmployee("Тазик Огурцов", 2001, "C#");

            //Использование методов базового класса
            developer.DisplayInfo();
            developer.Work();

            //Использование методов производного класса
            developer.AddSkill("ASP.NET Core");
            developer.AddSkill("Entity Framework");
            developer.FixBug();

            Console.WriteLine("\nОбновленная информация о IT-сотруднике ");
            developer.DisplayInfo();

            Console.WriteLine("\nПолиморфизм через базовый класс ");
            Employee employeeAsBase = developer;
            employeeAsBase.DisplayInfo();
            employeeAsBase.Work();
        }
    }
}