using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_0.DatabaseFirstSource
{
    /// <summary>
    /// === Database first === /// 
    /// Доп. материалы: https://metanit.com/sharp/entityframework/2.4.php
    /// 1. Создаем БД с нужными таблицами
    /// 2. Через Диспетчер пакетов NuGet устанавливаем EF
    /// 3. Через Обозреватель серверов подключаемся с серверу и БД
    /// 4. Создаем EDM (Добавить -> Создать элемент -> Модель ADO.NET EDM)
    /// 5. В появившемся мастере создания моделей EDM выбрать опцию Create from database
    /// 6. Выбираем существующее подключение к БД или создаем новое
    /// 7. Выбираем чек-боксы всех таблицы (нужных) для формирования EDM
    /// 8. Можем пользоваться созданной EDM
    /// </summary>
    public static class DatabaseFirst
    {
        // Базовая работа с EF
        public static void AddAuthor(Author author)
        {
            using (DBFirst_LibraryEntities db = new DBFirst_LibraryEntities())
            {
                db.Author.Add(author);  // действие с сущностью (локально)
                db.SaveChanges();       // сохранение действия в БД

                Console.WriteLine("Новый автор добавлен: " +
                author.LastName);
            }
        }

        public static void PrintAuthors()
        {
            Console.WriteLine("Все авторы: ");

            using (DBFirst_LibraryEntities db = new DBFirst_LibraryEntities())
            {
                var authors = db.Author.ToList();

                foreach (var a in authors)
                {
                    Console.WriteLine(a.FirstName + " " + a.LastName);
                }
            }
        }

        // === LINQ to Entities ===
        // Доп. материал: https://metanit.com/sharp/entityframework/4.1.php
        public static Author GetAuthorByName_ByQuerySyntaxLINQ(string fname)
        {
            using (DBFirst_LibraryEntities db = new DBFirst_LibraryEntities())
            {
                // В формате: синтаксис LINQ запроса 
                var author = (from s in db.Author
                              where s.FirstName == fname
                              select s).FirstOrDefault<Author>();
                return author;
            }
        }

        public static Author GetAuthorByName_ByExtensionMthodLINQ(string fname)
        {
            using (DBFirst_LibraryEntities db = new DBFirst_LibraryEntities())
            {
                // В формате: метод расширения LINQ запроса 
                var author = db.Author.Where(x =>
                x.FirstName == fname).FirstOrDefault();

                return author;
            }
        }

        // Single() и SingleOrDefault() - вернут единственную запись
        public static Author GetAuthorById_ByQuerySyntaxLINQ(int id)
        {
            using (DBFirst_LibraryEntities db = new DBFirst_LibraryEntities())
            {
                var author = (from s in db.Author
                              where s.Id == id
                              select s).Single();

                return author;
            }
        }

        public static Author GetAuthorById_ByExtensionMthodLINQ(int id)
        {
            using (DBFirst_LibraryEntities db = new DBFirst_LibraryEntities())
            {
                var author = db.Author.Where((x) =>
                x.Id == id).SingleOrDefault();
                return author;
            }
        }

        // ToList() - формирует список, например для формирования списка определенного отбора
        public static void GetAllAuthors_ByQuerySyntaxLINQ()
        {
            using (DBFirst_LibraryEntities db = new DBFirst_LibraryEntities())
            {
                var au = (from a in db.Author
                          where a.LastName.StartsWith("A")
                          select a).ToList();

                foreach (var a in au)
                {
                    Console.WriteLine(a.FirstName + " " + a.
                    LastName);
                }
            }
        }

        public static void GetAllAuthors_ByExtensionMthodLINQ()
        {
            using (DBFirst_LibraryEntities db = new DBFirst_LibraryEntities())
            {
                var au = db.Author.Where((x) =>
                x.LastName.StartsWith("A")).ToList();
                foreach (var a in au)
                {
                    Console.WriteLine(a.FirstName + " "
                    + a.LastName);
                }
            }
        }

        // OrderBy() - сортировка
        public static void GetAllAuthorsOrderBy_ByQuerySyntaxLINQ()
        {
            using (DBFirst_LibraryEntities db = new DBFirst_LibraryEntities())
            {
                var au = (from a in db.Author
                          orderby
                a.LastName ascending
                          select a).ToList();
                foreach (var a in au)
                {
                    Console.WriteLine(a.FirstName + " " + a.LastName);
                }
            }
        }

        public static void GetAllAuthorsOrderBy_ByExtensionMthodLINQ()
        {
            using (DBFirst_LibraryEntities db = new DBFirst_LibraryEntities())
            {
                var au = db.Author.OrderBy((x) =>
                x.LastName).ToList();
                foreach (var a in au)
                {
                    Console.WriteLine(a.FirstName + "  " + a.LastName);
                }
            }
        }

        // Find() - поиск объекта
        public static Author GetAuthorFindById_ByExtensionMthodLINQ(int id)
        {
            using (DBFirst_LibraryEntities db = new DBFirst_LibraryEntities())
            {
                var au = db.Author.Find(id);
                Console.WriteLine(au.FirstName + " " +
                au.LastName);
                return au;
            }
        }
    }
}
