
using PPC_HR.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC_HR.Models
{

    public class PersonInfoModel
    {
        private short employeeId;
        public PersonInfo Info { get; set; }
        public (List<PersonPosition>, PersonExperience) Positions { get; set; }
        public List<PersonDiploma> Diplomas { get; set; }
        public PersonMilitary Military { get; set; }
        public PersonDisability Disability { get; set; }
        public PersonMentalCheck MentalCheck { get; set; }

        public PersonInfoModel(short emplId)
        {
            this.employeeId = emplId;          
        }

        DataSendingService sendingService = new DataSendingService();

        public void RunTasksPersonInfo()
        {
            DataReceiveService DataReceiveService = new DataReceiveService();
            var getpersinfo = Task.Run(async () => await DataReceiveService.GetPersonInfo(employeeId));
            var getpositions = Task.Run(async () => await DataReceiveService.GetPersonPositions(employeeId));
            var getdiplomas = Task.Run(async () => await DataReceiveService.GetPersonDiplomas(employeeId));
            var getmilitaryinfo = Task.Run(async () => await DataReceiveService.GetPersonMilitaryInfo(employeeId));
            var getdisabilityinfo = Task.Run(async () => await DataReceiveService.GetPersonDisabilityInfo(employeeId));
            var getmentalhealthinfo = Task.Run(async () => await DataReceiveService.GetPersonmentalHealthInfo(employeeId));

            Task.WhenAll(getpersinfo, getpositions);
            Info = getpersinfo.Result;
            Positions = getpositions.Result;
            Diplomas = getdiplomas.Result;
            Military = getmilitaryinfo.Result;
            Disability = getdisabilityinfo.Result;
            MentalCheck = getmentalhealthinfo.Result;
        }

        public void UpdatePersonInfo(PersonInfo personInfo)
        {
            if (personInfo.emplid != 0)
                sendingService.SendPersonInfo(personInfo);
            else sendingService.InsertPersonInfo(personInfo);
        }

        public void UpdatePersonPosition(List<PersonPosition> positions)
        {
            if (positions[1].emplid != 0)
                sendingService.SendPositionInfo(positions);
            else sendingService.InsertPositionInfo(positions);
        }

        public void UpdatePedExp(PersonExperience experience)
        {
            if (experience.emplid != 0)
                sendingService.SendPedExp(experience);
            else sendingService.InsertPedExp(experience);
        }

        public void UpdateDiplomasInfo(List<PersonDiploma> list)
        {
            if (list[1].emplId != 0)
                sendingService.SendDiplomasInfo(list);
            else sendingService.InsertDiplomasInfo(list);
        }

        public void UpdateMilitary(PersonMilitary military)
        {
            if (military.emplId != 0)
                sendingService.SendMilitaryInfo(military);
            else sendingService.InsertMilitaryInfo(military);
        }

        public void UpdateDisability(PersonDisability d)
        {
            if (d.emplId != 0)
                sendingService.SendDisabilityInfo(d);
            else sendingService.InsertDisabilityInfo(d);
        }

        public void UpdateMentalCheck(PersonMentalCheck check)
        {
            if (check.emplId != 0)
                sendingService.SendMentalCheckInfo(check);
            else sendingService.InsertMentalCheckInfo(check);
        }

        public void DeleteEmployee(short emplId) => sendingService.DeletePerson(emplId); 
    }

}
