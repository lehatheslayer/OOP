using System.Collections.Generic;
using Report.DAL.Entity;

namespace Report.DAL.Infrastructure
{
    public interface IData
    {
        void AddTask(Task task);
        Dictionary<int, Task> GetTasks();
        Task GetTask(int id);

        void AddPerson(Person person);
        Dictionary<int, Person> GetPersons();
        Person GetPerson(int id);

        void AddReport(SprintReport report);
        List<SprintReport> GetReports();
    }
}