using System.Collections.Generic;

namespace ConsoleApplication1.Cleaner
{
    public class Cleaner : ICleaner
    {
        private List<ICleaner> _cleaners;
        private bool _typeOfHybrid;

        public Cleaner(bool type = false, params ICleaner[] cleaners)
        {
            _cleaners = new List<ICleaner>();
            _typeOfHybrid = type;
            
            foreach (var cleaner in cleaners)
            {
                _cleaners.Add(cleaner);    
            }
        }
        
        public bool IsWithin(RestorePoint rp)
        {
            if (_cleaners.Count == 1)
            {
                return _cleaners[0].IsWithin(rp);
            }

            if (_cleaners.Count == 0)
            {
                return true;
            }
            
            if (_typeOfHybrid)
            {
                bool result = true;
                foreach (var cleaner in _cleaners)
                {
                    result &= cleaner.IsWithin(rp);
                }

                return result;
            }
            else
            {
                bool result = false;
                foreach (var cleaner in _cleaners)
                {
                    result = result || cleaner.IsWithin(rp);
                }

                return result;
            }
        }
    }
}