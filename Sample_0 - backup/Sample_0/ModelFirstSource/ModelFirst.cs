using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Sample_0.ModelFirstSource
{
    /// <summary>
    /// === Model first === ///
    /// Доп. материалы: https://metanit.com/sharp/entityframework/2.5.php
    /// 1. Через Диспетчер пакетов NuGet устанавливаем EF
    /// 2. Создаем EDM (Добавить -> Создать элемент -> Модель ADO.NET EDM)
    /// 3. Выбираем Empty EF Designer Model
    /// 4. Из Панель Инструментов создаем Entity (Сущность) в EDM
    /// 5. В Свойства задаем имя сущности
    /// 6. Создаем нужные поля: Правой кнопкой мишы на модель -> Добавить -> Сколярное свойство 
    /// 7. Генерируем код модели: Правой кнопкой мишы на модель -> Добавить элемент создания кода
    /// 8. Выбираем генератор модель и вводим ее название
    /// 9. Генерация БД по модели: На диаграмму модели правой кнопкой мыши -> Сформировать БД на основе модели
    /// 10. Выбираем БД или создаем новую
    /// 10.1 Может возникнуть ошибка при формировании sql запроса (Кнопка Далее полсе выбора БД) -> Помогает перезапусе IDE MVS
    /// 11. Сформируется соответсвующий sql запрос по созданию модели в БД -> Запускаем его
    /// 11.1 В верхнем левом углу соответсвующая кнопка -> Выбираем нужный сервер и БД на нем -> Выполнить/Далее
    /// 11.2 В результате должны увидеть: Команды выполнены успешно.
    /// </summary>
    public static class ModelFirst
    {
        public static void AddUser(User d)
        {
            using (ModelFirst_UsersContainer db = new ModelFirst_UsersContainer())
            {
                // добавление элементов
                db.UserSet.Add(d);
                db.SaveChanges();

                Console.WriteLine("Данные добавлены!");
            }
        }

        public static void PrintUsers()
        {
            using (ModelFirst_UsersContainer db = new ModelFirst_UsersContainer())
            {
                Console.WriteLine("Исходные данные: ");

                // получение элементов
                var users = db.UserSet;
                foreach (User u in users)
                    Console.WriteLine("{0}: {1} {2} {3}", u.Id, u.Name, u.Surname, u.Patronymic);
            }
        }
    }
}
