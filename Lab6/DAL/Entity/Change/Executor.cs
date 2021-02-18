using System;

namespace Report.DAL.Entity
{
    public class Executor : Change
    {
        private readonly Person _from;
        private readonly Person _to;
        
        public Executor(int id, string text, Person from, Person to) : base(id, text)
        {
            Time = DateTime.Now;
            _from = from;
            _to = to;
        }

        public Person GetFrom()
        {
            return _from;
        }

        public Person GetTo()
        {
            return _to;
        }
    }
}