using System;

namespace Report.DAL.Entity
{
    public class Comments : Change
    {
        private readonly Person _executor;
        private readonly string _comment;
        
        public Comments(int id, string text, Person executor, string comment) : base(id, text)
        {
            Time = DateTime.Now;
            _executor = executor;
            _comment = comment;
        }

        public Person GetExecutor()
        {
            return _executor;
        }

        public string GetComment()
        {
            return _comment;
        }
    }
}