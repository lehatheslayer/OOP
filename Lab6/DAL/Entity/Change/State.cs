using System;

namespace Report.DAL.Entity
{
    public class State : Change
    {
        private readonly Person _executor;
        private readonly int _state;
        
        public State(int id, string text, int state, Person executor) : base(id, text)
        {
            Time = DateTime.Now;
            _state = state;
            _executor = executor;
        }

        public Person GetExecutor()
        {
            return _executor;
        }

        public int GetState()
        {
            return _state;
        }
    }
}