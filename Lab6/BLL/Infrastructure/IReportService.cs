using System.Collections;
using System.Collections.Generic;
using Report.DAL.Entity;

namespace Report.PL
{
    public interface IReportService
    {
        void AddTask(string name, string description);
        Dictionary<int, Task> GetTasks();
        Task GetTask(int id);

        void AddPerson(string name);
        Dictionary<int, Person> GetPersons();
        Person GetPerson(int id);
        List<SprintReport> GetReports();
    }
}