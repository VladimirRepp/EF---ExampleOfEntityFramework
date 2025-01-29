using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Utilities;
using Sample_0.DatabaseFirstSource;
using Sample_0.ModelFirstSource;
using Sample_0.CodeFirstSource;

// EF доп материал: https://metanit.com/sharp/entityframework/1.1.php
// EF Core: https://metanit.com/sharp/efcore/1.1.php

// EDM (Entity Data Model) — это модель, описывающая 
// взаимоотношение объектов классов в приложении,
// с одной стороны, и связанных таблиц в БД, с другой.

// Основные способы создания EDM при работе с EF:
// - База данных сначала (Database first): сначала проектируется и создается БД, на ее оснвое создается EDM
// - Модель сначала (Model first): сначала графически создается EDM, после на ее основе формируется БД
// - Код сначала (Code First): сначала создаюься необходимые классы, после на их основе формируется EDM и БД

// Контекст БД — это специальный класс, производный 
// от системного класса DbContext и предназначенный для 
// установления связи с БД и для выполнения запросов к БД.

// Сущность — это класс, соответствующий таблице БД,
// автоматически создаваемый Entity Framework. Свойства 
// этого класса соответствуют полям таблицы


namespace Sample_0
{
    internal static class Program
    {
        static void Main()
        {
            int act = 2;
            switch (act)
            {
                case 0:
                    DBFirst_Example();
                    break;

                case 1:
                    ModelFirst_Example();
                    break;

                case 2:
                    CodeFirst_Example();
                    break;

                default:
                    Console.WriteLine("Неверный ввод!");
                    break;
            }
        }

        private static void DBFirst_Example()
        {
            Console.WriteLine("\n=== DB First ===");

            Author author = new Author
            {
                FirstName = "Имя 1",
                LastName = "Фамилия 1"
            };

            DatabaseFirst.AddAuthor(author);
            DatabaseFirst.PrintAuthors();

            ConsoleHelper.ConsolePause();
        }

        private static void ModelFirst_Example()
        {
            Console.WriteLine("\n=== Model First ===");

            User user = new User
            {
                Name = "Имя 1",
                Surname = "Фамилия 1",
                Patronymic = "Отчество 1",
            };

            ModelFirst.AddUser(user);
            ModelFirst.PrintUsers();

            ConsoleHelper.ConsolePause();
        }

        private static void CodeFirst_Example()
        {
            Console.WriteLine("\n=== Code First ===");

            Employee employee = new Employee
            {
                Name = "Имя 1",
                Age = 45
            };

            CodeFirst.AddEmployee(employee);
            CodeFirst.PrintEmployee();

            Console.WriteLine("\n=== TEST ===");

            CodeFirst.PeopleTest();

            ConsoleHelper.ConsolePause();
        }
    }
}
