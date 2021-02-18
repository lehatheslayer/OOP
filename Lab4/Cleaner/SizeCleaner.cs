namespace ConsoleApplication1.Cleaner
{
    public class SizeCleaner : ICleaner
    {
        private readonly int _size;

        public SizeCleaner(int size)
        {
            _size = size;
        }
       
        public bool IsWithin(RestorePoint rp)
        {
            return rp.GetSize() <= _size;
        }
    }
}