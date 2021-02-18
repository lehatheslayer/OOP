using System.Collections;
using System.Collections.Generic;

namespace Report.DAL.Entity
{
    
    public class DailyReport : Report
    {
        private readonly Dictionary<int, Task> _completedTasks;
        
        public DailyReport(int id)
        {
            Id = id;
            _completedTasks = new Dictionary<int, Task>();
        }

        public void AddTask(Task task)
        {
            _completedTasks.Add(task.Id, task);
        }

        public Dictionary<int, Task> GetCompletedTasks()
        {
            return _completedTasks;
        }

        public Task GetCompletedTask(int id)
        {
            return _completedTasks[id];
        }
    }
}