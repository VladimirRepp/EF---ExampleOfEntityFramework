using Sample_0.ModelFirstSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_0.CodeFirstSource
{
    /// <summary>
    /// === Code First ===
    /// Доп. материалы: https://metanit.com/sharp/entityframework/1.2.php
    /// 1. Через Диспетчер пакетов NuGet устанавливаем EF
    /// 2. Создаем новый класс/классы и задаем нужные поля (будущая модель)
    /// 3. Создаем соответсвующие контексты сущностей
    /// 4. В конфигурационном файле пропысваем подключение к БД
    /// </summary>
    public static class CodeFirst
    {
        public static void PeopleTest()
        {
            using (PeopleContext db = new PeopleContext())
            {
                db.Peoples.Add(new People()
                {
                    Name = "Test Name",
                    Description = "Test Description"
                }); ;
                db.SaveChanges();

                var people = db.Peoples;
                foreach (People p in people)
                {
                    Console.WriteLine("{0}: {1} {2}", p.Id, p.Name, p.Description);
                }
            }
        }

        public static void AddEmployee(Employee employee)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();

                Console.WriteLine("Данные добавленый!");
            }
        }

        public static void PrintEmployee()
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                Console.WriteLine("Исходные данные:!");

                var employees = db.Employees;
                foreach (Employee u in employees)
                {
                    Console.WriteLine("{0}: {1} {2}", u.Id, u.Name, u.Age);
                }
            }
        }
    }
}
