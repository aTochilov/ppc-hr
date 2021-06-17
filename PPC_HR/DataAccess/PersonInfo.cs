
namespace PPC_HR.DataAccess
{

    public class PersonInfo
    {
        public short emplid { get; set; }
        public string position { get; set; }
        public decimal iid { get; set; }
        public string surname { get; set; }
        public string firstname { get; set; }
        public string patronymic { get; set; }
        public char sex { get; set; }
        public string emplAddress { get; set; }
        public string birthdate { get; set; }
        public decimal phone { get; set; }
        public string cyclKomis { get; set; }
        public bool isMilitaryBound { get; set; }
        public bool isRetired { get; set; }
        public bool pedWorkload { get; set; }
        public byte[] photo { get; set; }

    }
}
