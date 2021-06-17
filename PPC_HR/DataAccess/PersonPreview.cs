
namespace PPC_HR.DataAccess
{
    public interface IPersonPreview
    {
        short id { get; set; }
        string fullname { get; set; }
        string position { get; set; }
        string phone { get; set; }
        void update(IPersonPreview preview);
    }
    public class PersonPreview : IPersonPreview
    {
        public short id { get; set; }
        public string fullname { get; set; }
        public string position { get; set; }
        public string phone { get; set; }
        public void update(IPersonPreview preview)
        {
            fullname = preview.fullname;
            position = preview.position;
            phone = preview.phone;
        }
    }
}
