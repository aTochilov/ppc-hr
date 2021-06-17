
namespace PPC_HR.DataAccess
{

    public class PersonPosition
    {
        public short emplid { get; set; }
        public short positionId { get; set; }
        public short positionCode { get; set; }
        public string positionName { get; set; }
        public decimal positionVolume { get; set; }
        public bool isMainPosition { get; set; }
    }

    public class PersonExperience
    {
        public short emplid { get; set; }
        public short totalExp { get; set; }
        public short specializationExp { get; set; }
        public short positionExp { get; set; }
        public string lastChangesDate { get; set; }
    }
}