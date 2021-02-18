using System;
using System.Collections.Generic;
using Report.DAL.Infrastructure;

namespace Report.DAL.Entity
{
    public class Person : IEntity
    {
        private readonly string _name;
        private Person _leader;
        private Dictionary<int, Person> _subordinates;
        private Dictionary<int, DailyReport> _daily;
        private DailyReport _currentDailyReport;
        private SprintReport _sprint;
        private int _rid = 0;
        
        public int Id { get; }

        public Person(string name, int id)
        {
            _name = name;
            Id = id;
            _leader = null;
            _subordinates = new Dictionary<int, Person>();
            _daily = new Dictionary<int, DailyReport>();
        }
        
        public void SetLeader(Person leader)
        {
            _leader = leader;
        }

        public void SetSubordinate(Person subordinate)
        {
            if (_subordinates.ContainsKey(subordinate.Id))
                throw new Exception("Уже есть такой подчиненный");
            _subordinates.Add(subordinate.Id, subordinate);
        }

        public void DeleteSubordinate(int id)
        {
            if (!_subordinates.ContainsKey(id)) 
                throw new Exception("Нет такого подчиненного");
            var tmp = new Dictionary<int, Person>();
            foreach (var subordinate in _subordinates)
            {
                if (id != subordinate.Key)
                    tmp.Add(subordinate.Key, subordinate.Value);
            }

            _subordinates = tmp;
        }

        public void CreateDailyReport()
        {
            _currentDailyReport = new DailyReport(_rid);
            _rid++;
        }

        public void AddTextToDailyReport(string text)
        {
            _currentDailyReport.AddText(text);
        }

        public void AddCompletedTaskToDailyReport(Task task)
        {
            if (task.GetState() != 2)
                throw new Exception("Задача еще не завершнена");
            _currentDailyReport.AddTask(task);
        }

        public void CompleteDailyReport()
        {
            if (_daily.ContainsKey(_currentDailyReport.Id))
                throw new Exception("данный отчет уже завершен");
            _daily.Add(_currentDailyReport.Id, _currentDailyReport);
            _sprint.AddReport(_currentDailyReport);
        }

        public SprintReport CompleteSprintReport()
        {
            var tmp = _sprint;
            _sprint = new SprintReport();
            return tmp;
        }
        
        public Dictionary<int, DailyReport> GetDaily()
        {
            return _daily;
        }

        public SprintReport GetSprint()
        {
            return _sprint;
        }

        public Dictionary<int, Person> GetSubordinates()
        {
            return _subordinates;
        }

        public Person GetSubordinate(int id)
        {
            if (!_subordinates.ContainsKey(id))
                throw new Exception("Нет такого сотрудника");
            return _subordinates[id];
        }

        public string GetName()
        {
            return _name;
        }

        public Person GetLeader()
        {
            return _leader;
        }
    }
}