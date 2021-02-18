using System;
using System.Collections.Generic;
using Report.DAL;
using Report.DAL.Entity;
using Report.DAL.Infrastructure;

namespace Report.PL
{
    public class ReportService : IReportService
    {
        private readonly IData _data;
        private int _pid;
        private int _tid;

        public ReportService(IData data)
        {
            _data = data;
            _pid = _data.GetPersons().Count;
            _tid = _data.GetTasks().Count;
        }

        // Tasks methods
        
        public void SetExecutor(int pid, int tid)
        {
            _data.GetTask(tid).SetExecutor(_data.GetPerson(pid));
            Console.WriteLine("Исполнитель назначен");
        }

        public void ChangeExecutor(int pid, int tid)
        {
            _data.GetTask(tid).ChangeExecutor(_data.GetPerson(pid));
            Console.WriteLine("Исполнитель изменен");
        }

        public void AddComment(int pid, int tid, string comment)
        {
            if (_data.GetTask(tid).GetExecutor().Id != tid)
                throw new Exception("Данный сотрудник не является исполнителем данной задачи");
            _data.GetTask(tid).AddComment(comment);
            Console.WriteLine("Комментарий успешно добавлен");
        }

        public void CompleteTask(int pid, int tid)
        {
            if (_data.GetTask(tid).GetExecutor().Id != tid)
                throw new Exception("Данный сотрудник не является исполнителем данной задачи");
            _data.GetTask(tid).Complete();
            Console.WriteLine("Задача успешно завершена");
        }

        // Persons methods
        
        public void SetSubordinateLeader(int subordinate, int leader)
        {
            _data.GetPerson(subordinate).SetLeader(_data.GetPerson(leader));
            _data.GetPerson(leader).SetSubordinate(_data.GetPerson(subordinate));
            Console.WriteLine("Лидер успешно назначен");
        }

        public void DeleteSubordinate(int leader, int subordinate)
        {
            _data.GetPerson(leader).DeleteSubordinate(subordinate);
            _data.GetPerson(subordinate).SetLeader(null);
            Console.WriteLine("Подчиненный успешно удален");
        }

        public void CreateDailyReport(int pid)
        {
            _data.GetPerson(pid).CreateDailyReport();
        }

        public void AddTextToDailyReport(int pid, string text)
        {
            _data.GetPerson(pid).AddTextToDailyReport(text);
        }

        public void AddCompletedTaskToDailyReport(int tid, int pid)
        {
            if (_data.GetTask(tid).GetExecutor().Id != tid)
                throw new Exception("Данный сотрудник не является исполнителем данной задачи");
            _data.GetPerson(pid).AddCompletedTaskToDailyReport(_data.GetTask(tid));
        }

        public void CompleteDailyReport(int pid)
        {
            _data.GetPerson(pid).CompleteDailyReport();
        }

        public void CompleteSprintReport(int pid)
        {
            var tmp = _data.GetPerson(pid).CompleteSprintReport();
            _data.AddReport(tmp);
        }
        
        // Get-Set section
        
        public void AddTask(string name, string description)
        { 
            _data.AddTask(new Task(name, _tid, description));
            _tid++;
        }

        public Dictionary<int, Task> GetTasks()
        {
            return _data.GetTasks();
        }

        public Task GetTask(int id)
        {
            return _data.GetTask(id);
        }

        public void AddPerson(string name)
        {
            _data.AddPerson(new Person(name, _pid));
            _pid++;
        }

        public Dictionary<int, Person> GetPersons()
        {
            return _data.GetPersons();
        }

        public Person GetPerson(int id)
        {
            return _data.GetPerson(id);
        }

        public List<SprintReport> GetReports()
        {
            return _data.GetReports();
        }
    }
}