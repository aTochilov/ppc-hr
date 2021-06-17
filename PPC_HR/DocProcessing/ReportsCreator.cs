using PPC_HR.DataAccess;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using System.IO;

namespace PPC_HR.DocProcessing
{
    public class ReportsCreator
    {

        private object currDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public ReportsCreator()
        {

        }

        public void DisabledEmployeesReportCreator(List<DisabledEmployeeReport> list)
        {
            string emplData = "";
            foreach (DisabledEmployeeReport empl in list)
            {
                emplData += empl.idx.ToString() + ";" + empl.personInfo + ";" + empl.msecInfo + ";" +
                    empl.group + ";" + empl.dateFrom + ";" + empl.dateTo + ";" + empl.address + ";" +
                    empl.monthInWork.ToString() + ";" + empl.position + ";" + empl.orderHired + ";" +
                    empl.orderFired + "\n";
            }

            object m = System.Reflection.Missing.Value;
            object templateFile = currDir + "\\disabledEmplTemplate.docx";
            object readOnly = (object)false;

            _Application word = new Application();
            word.Visible = true;
            _Document document = word.Documents.Add(ref templateFile, ref m, ref m, ref m);

            Table templateTable = document.Tables[1];
            Range rngTbl = templateTable.Range;
            rngTbl.Collapse(WdCollapseDirection.wdCollapseEnd);
            Range rng = document.Content;
            rng.Collapse(WdCollapseDirection.wdCollapseEnd);
            rng.Text = emplData;
            rng.Font.Size = 12;
            Table tblExtend = rng.ConvertToTable(";", m, m, m, m,
                    m, m, m, m, m, m, m, m, m,
                    m, WdDefaultTableBehavior.wdWord8TableBehavior);
            tblExtend.Range.Cut();
            rngTbl.PasteAppendTable();
        }


        public void MilReportEmployeesCreator(List<MilReportEmployees> list)
        {
            string emplData = "";
            foreach (MilReportEmployees empl in list)
            {
                emplData += empl.idx.ToString() + ";" + empl.personInfo + ";" + empl.birthDate + ";" +
                    empl.milRank + ";" + empl.emplAddress + ";" + empl.position + "\n";
            }

            object m = System.Reflection.Missing.Value;
            object templateFile = currDir + "\\milEmplTemplate.docx";
            object readOnly = (object)false;

            _Application word = new Application();
            word.Visible = true;
            _Document document = word.Documents.Add(ref templateFile, ref m, ref m, ref m);

            Table templateTable = document.Tables[1];
            Range rngTbl = templateTable.Range;
            rngTbl.Collapse(WdCollapseDirection.wdCollapseEnd);
            Range rng = document.Content;
            rng.Collapse(WdCollapseDirection.wdCollapseEnd);
            rng.Text = emplData;
            rng.Font.Size = 12;
            Table tblExtend = rng.ConvertToTable(";", m, m, m, m,
                    m, m, m, m, m, m, m, m, m,
                    m, WdDefaultTableBehavior.wdWord8TableBehavior);
            tblExtend.Range.Cut();
            rngTbl.PasteAppendTable();
        }
    }
}
