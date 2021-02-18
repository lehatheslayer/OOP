using System;
using System.Collections.Generic;
using Report.DAL.Infrastructure;

namespace Report.DAL.Entity
{
    public class Task : IEntity
    {
        private readonly string _name;
        private readonly string _description;
        private int _state;
        private Person _executor;
        private readonly List<string> _comments;
        private readonly List<Change> _changes;
        public int Id { get; }

        public Task(string name, int id, string description)
        {
            _name = name;
            Id = id;
            _description = description;
            _state = 0; // 0 - open, 1 - active, 2 - resolved
            _executor = null;
            _comments = new List<string>();
            _changes = new List<Change>();
            
            _changes.Add(new State(_changes.Count, "Задача была создана", _state, _executor));
        }

        public void SetExecutor(Person executor)
        {
            if (_state != 0) 
                throw new Exception("Выполнение задачи начато, или было завершено, невозможно начать ее заного");
            _executor = executor;
            _state = 1;
            
            _changes.Add(new State(_changes.Count, "Назначен исполнитель, над задачей начали работать", _state, _executor));
        }

        public void ChangeExecutor(Person newExecutor)
        {
            if (_executor == null) 
                throw new Exception("Нельзя поменять исполнителя, если он не назначен");
            _executor = newExecutor;
            
            _changes.Add(new Executor(_changes.Count, "Назначен новый исполнитель", _executor, newExecutor));
        }

        public void AddComment(string comment)
        {
            if (_state != 1)
                throw new Exception("Нельзя добавить комментарий в неначатую или завершенную задачу");
            _comments.Add(comment);
            
            _changes.Add(new Comments(_changes.Count,"Добавлен комментарий", _executor, comment));
        }

        public void Complete()
        {
            if (_state != 1)
                throw new Exception("Невозможно завершить неначатую или уже заверщенную работу");
            _state = 2;
            
            _changes.Add(new State(_changes.Count, "Задача завершена", _state, _executor));
        }

        public string GetName()
        {
            return _name;
        }
        
        public string GetDescription()
        {
            return _description;
        }

        public int GetState()
        {
            return _state;
        }

        public Person GetExecutor()
        {
            return _executor;
        }

        public List<string> GetComments()
        {
            return _comments;
        }

        public string GetComment(int id)
        {
            return _comments[id];
        }

        public List<Change> GetChanges()
        {
            return _changes;
        }

        public Change GetChange(int id)
        {
            return _changes[id];
        }
        
    }
}
