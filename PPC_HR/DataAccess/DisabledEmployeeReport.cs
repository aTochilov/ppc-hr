using System;
using System.Collections.Generic;
using System.Text;

namespace PPC_HR.DataAccess
{
    public interface IDisabledEmployeeReport
    {
        short idx { get; set; }
        short id { get; set; }
        string personInfo { get; set; }
        string msecInfo { get; set; }
        string group { get; set; }
        string dateFrom { get; set; }
        string dateTo { get; set; }
        string address { get; set; }
        short monthInWork { get; set; }
        string position { get; set; }
        string orderHired { get; set; }
        string orderFired { get; set; }
    }

    public class DisabledEmployeeReport : IDisabledEmployeeReport
    {
        public short idx { get; set; }
        public short id { get; set; }
        public string personInfo { get; set; }
        public string msecInfo { get; set; }
        public string group { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
        public string address { get; set; }
        public short monthInWork { get; set; }
        public string position { get; set; }
        public string orderHired { get; set; }
        public string orderFired { get; set; }

    }
}
