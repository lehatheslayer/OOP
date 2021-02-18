namespace ConsoleApplication1.Cleaner
{
    public class CountCleaner : ICleaner
    {
        private readonly int _count;

        public CountCleaner(int count)
        {
            _count = count;
        }
        
        public bool IsWithin(RestorePoint rp)
        {
            if (rp.GetType() == 1)
                return true;
            var length = 0;
            while (rp != null)
            {
                length++;
                rp = rp.GetDepend();
            }

            return length <= _count;
        }
    }
}