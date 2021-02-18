using System;
using Report.DAL.Infrastructure;

namespace Report.DAL.Entity
{
    public class Change : IEntity
    {
        private readonly string _text;
        protected DateTime Time; 
        public int Id { get; }

        protected Change(int id, string text)
        {
            Id = id;
            _text = text;
            Time = DateTime.Now;
        }

        public string GetText()
        {
            return _text;
        }

        public DateTime GetTime()
        {
            return Time;
        }
    }
    
    
}