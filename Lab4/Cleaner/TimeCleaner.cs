namespace ConsoleApplication1.Cleaner
{
    public class TimeCleaner : ICleaner
    {
        private readonly long _ticks;

        public TimeCleaner(long ticks)
        {
            _ticks = ticks;
        }
        
        public bool IsWithin(RestorePoint rp)
        {
            return rp.GetTime() <= _ticks;
        }
    }
}