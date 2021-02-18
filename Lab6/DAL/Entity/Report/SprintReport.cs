using System;
using System.Collections.Generic;

namespace Report.DAL.Entity
{
    public class SprintReport : Report
    {
        private readonly Dictionary<int, DailyReport> _dailyReports;

        public SprintReport()
        {
            _dailyReports = new Dictionary<int, DailyReport>();
        }

        public void AddReport(DailyReport report)
        {
            _dailyReports.Add(report.Id, report);
        }

        public Dictionary<int, DailyReport> GetReports()
        {
            return _dailyReports;
        }

        public Report GetReport(int id)
        {
            return _dailyReports[id];
        }

        
    }
}