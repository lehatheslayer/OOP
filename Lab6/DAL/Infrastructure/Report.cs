using Report.DAL.Infrastructure;

namespace Report.DAL.Entity
{
    public class Report : IEntity
    {
        protected string Text;
        public int Id { get; set; }

        public void AddText(string text)
        {
            Text = text;
        }
        
        public string GetText()
        {
            return Text;
        }
    }
}