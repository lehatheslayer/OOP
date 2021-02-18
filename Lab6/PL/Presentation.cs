using System;
using Report.DAL;
using Report.DAL.Entity;
using Report.DAL.Infrastructure;

namespace Report.PL
{
    public static class Presentation
    {
        private static readonly ReportService Service = new ReportService(new Data());
        
        public static void Start()
        {
            while (true)
            {
                Info();
                var key = Convert.ToInt32(Console.ReadLine());

                switch (key)
                {
                    case 0:
                        return;
                    case 1:
                        Console.WriteLine("Введите название и описание задачи");
                        string taskName = Convert.ToString(Console.ReadLine()), description = Convert.ToString(Console.ReadLine());
                        AddTask(taskName, description);
                        break;
                    case 2:
                        Console.WriteLine("Введите имя");
                        string personName = Convert.ToString(Console.ReadLine());
                        AddPerson(personName);
                        break;
                    case 3:
                        GetPersons();
                        break;
                    case 4:
                        GetTasks();
                        break;
                    case 5:
                        GetReports();
                        break;
                    case 6:
                        Login();
                        break;
                    case 7:
                        Console.WriteLine("Введите айди лидера и подчиненного: ");
                        var leader = Convert.ToInt32(Console.ReadLine());
                        var subordinate = Convert.ToInt32(Console.ReadLine());
                        Service.SetSubordinateLeader(subordinate, leader);
                        break;
                    case 8:
                        Console.WriteLine("Введите айди лидера и подчиненного: ");
                        var leader1 = Convert.ToInt32(Console.ReadLine());
                        var subordinate1 = Convert.ToInt32(Console.ReadLine());
                        Service.DeleteSubordinate(leader1, subordinate1);
                        break;
                    case 9:
                        Console.WriteLine("Введите айди исполнителя и айди задачи: ");
                        var newExecutor = Convert.ToInt32(Console.ReadLine());
                        var tid = Convert.ToInt32(Console.ReadLine());
                        Service.ChangeExecutor(newExecutor, tid);
                        break;
                    default:
                        Console.WriteLine("выберите число от 0 - 9");
                        break;
                        
                }
            }
        }

        private static void Info()
        {
            Console.WriteLine("0 - выйти");
            Console.WriteLine("1 - добавить задание");
            Console.WriteLine("2 - добавить пользователя");
            Console.WriteLine("3 - вывести список пользователей");
            Console.WriteLine("4 - вывести список задач");
            Console.WriteLine("5 - вывести список выполненных отчетов");
            Console.WriteLine("6 - войти в аккаунт");
            Console.WriteLine("7 - назначить лидера пользователю");
            Console.WriteLine("8 - убрать лидера пользователю");
            Console.WriteLine("9 - поменять исполнителя");
        }

        private static void AddPerson(string name)
        {
            Service.AddPerson(name);
        }

        private static void AddTask(string name, string description)
        {
            Service.AddTask(name, description);
        }

        private static void GetPersons()
        {
            Console.WriteLine("Список сотрудников:");
            foreach (var person in Service.GetPersons())
            {
                Console.WriteLine("Id: " + person.Key + ", имя: " + person.Value.GetName());
            }
        }

        private static void GetTasks()
        {
            Console.WriteLine("Список задач:");
            foreach (var task in Service.GetTasks())
            {
                Console.WriteLine("Id: " + task.Key + ", имя: " + task.Value.GetName() + ", описание: " +
                                  task.Value.GetDescription());
            }
        }

        private static void GetReports()
        {
            Console.WriteLine("Список отчетов:");
            foreach (var report in Service.GetReports())
            {
                Console.WriteLine("Id: " + report.Id + ", текст: " + report.GetText());
            }
        }

        private static void AuthorizedInfo()
        {
            Console.WriteLine("0 - выход");
            Console.WriteLine("1 - создать ежедневный отчет");
            Console.WriteLine("2 - добавить текст в ежедневный отчет");
            Console.WriteLine("3 - добавить завершенную задачу в ежедневный отчет");
            Console.WriteLine("4 - завершить ежедневный отчет");
            Console.WriteLine("5 - сформировать спринт-отчет");
            Console.WriteLine("6 - завершить задачу");
            Console.WriteLine("7 - добавить комментарий задаче");
            Console.WriteLine("8 - стать исполнителем");
        }
        
        private static void Login()
        {
            Console.WriteLine("Введите свой ID: ");
            var id = Convert.ToInt32(Console.ReadLine());
            if (!Service.GetPersons().ContainsKey(id))
                throw new Exception("Нет такого пользователя");
            while (true)
            {
                AuthorizedInfo();
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 0:
                        return;
                    case 1:
                        Service.CreateDailyReport(id);
                        break;
                    case 2:
                        Console.WriteLine("Введите текст: ");
                        var text = Convert.ToString(Console.ReadLine());
                        Service.AddTextToDailyReport(id, text);
                        break;
                    case 3:
                        Console.WriteLine("Введите айди задания: ");
                        GetTasks();
                        var tid = Convert.ToInt32(Console.ReadLine());
                        Service.AddCompletedTaskToDailyReport(tid, id);
                        break;
                    case 4:
                        Service.CompleteDailyReport(id);
                        break;
                    case 5:
                        Service.CompleteSprintReport(id);
                        break;
                    case 6:
                        Console.WriteLine("Введите айди задания: ");
                        tid = Convert.ToInt32(Console.ReadLine());
                        Service.CompleteTask(id, tid);
                        break;
                    case 7:
                        Console.WriteLine("Введите айди задания: ");
                        tid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("введите комментарий: ");
                        text = Convert.ToString(Console.ReadLine());
                        Service.AddComment(id, tid, text);
                        break;
                    case 8:
                        Console.WriteLine("Введите айди задания: ");
                        tid = Convert.ToInt32(Console.ReadLine());
                        Service.SetExecutor(id, tid);
                        break;
                    default:
                        Console.WriteLine("выберите число от 0 - 8");
                        break;
                }
            }
        }
    }
}