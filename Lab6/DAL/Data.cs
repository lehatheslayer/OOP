using System;
using System.Collections.Generic;
using Report.DAL.Entity;
using Report.DAL.Infrastructure;

namespace Report.DAL
{
    public class Data : IData
    {
        private readonly Dictionary<int, Person> _persons;
        private readonly Dictionary<int, Task> _tasks;
        private readonly List<SprintReport> _reports;

        public Data()
        {
            _persons = new Dictionary<int, Person>();
            _tasks = new Dictionary<int, Task>();
            _reports = new List<SprintReport>();
        }

        public void AddReport(SprintReport report)
        {
            _reports.Add(report);
        }

        public List<SprintReport> GetReports()
        {
            return _reports;
        }
        
        public void AddTask(Task task)
        {
            if (_tasks.ContainsKey(task.Id))
                throw new Exception("Такая задача уже существует");
            _tasks.Add(task.Id, task);
        }

        public void AddPerson(Person person)
        {
            if (_persons.ContainsKey(person.Id)) 
                throw new Exception("Такой сотрудник уже существует");
            _persons.Add(person.Id, person);
        }

        public Dictionary<int, Task> GetTasks()
        {
            return _tasks;
        }

        public Dictionary<int, Person> GetPersons()
        {
            return _persons;
        }

        public Task GetTask(int id)
        {
            if (!_tasks.ContainsKey(id))
                throw new Exception("Нет такой задачи");
            return _tasks[id];
        }

        public Person GetPerson(int id)
        {
            if (!_persons.ContainsKey(id))
                throw new Exception("Нет такого сотрудника");
            return _persons[id];
        }
    }
}