using PPC_HR.DataAccess;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;

namespace PPC_HR.DocProcessing
{
    public class ReportsCreator
    {
        public ReportsCreator()
        {

        }

        public void DisabledEmployeesReportCreator(List<DisabledEmployeeReport> list)
        {
            string emplData = "";

            //object m = System.Reflection.Missing.Value;
            //object templateFile = @"C:\\Users\\andre\\Documents\\Учеба\\Диплом\\disabledEmplTemplate.docx";
            //object readOnly = (object)false;
            //Application ac = null;
            //ac = new Application();

            //Document template = ac.Documents.Open(ref templateFile, ref m, ref readOnly,
            //     ref m, ref m, ref m, ref m, ref m, ref m, ref m,
            //     ref m, ref m, ref m, ref m, ref m, ref m);
            //Table table = ac.ActiveDocument.Tables[1];
            foreach (DisabledEmployeeReport empl in list)
            {
                //emplString[0] = empl.idx.ToString();
                //emplString[1] = empl.personInfo;
                //emplString[2] = empl.msecInfo;
                //emplString[3] = empl.group;
                //emplString[4] = empl.dateFrom;
                //emplString[5] = empl.dateTo;
                //emplString[6] = empl.address;
                //emplString[7] = empl.monthInWork.ToString();
                //emplString[8] = empl.position;
                //emplString[9] = empl.orderHired;
                //emplString[10] = empl.orderFired;

                emplData += empl.idx.ToString() + ";" + empl.personInfo + ";" + empl.msecInfo + ";" +
                    empl.group + ";" + empl.dateFrom + ";" + empl.dateTo + ";" + empl.address + ";" +
                    empl.monthInWork.ToString() + ";" + empl.position + ";" + empl.orderHired + ";" +
                    empl.orderFired + "\n";
                //Row lastRow = table.Rows.Last;
                
                //for (int i = 0; i < 11; i++)
                //{
                //    lastRow.Cells[i].Range.Text = emplString[i];
                //}
            }

            object m = System.Reflection.Missing.Value;
            object templateFile = @"C:\\Users\\andre\\Documents\\Учеба\\Диплом\\disabledEmplTemplate.docx";
            object readOnly = (object)false;

            _Application word = new Application();
            word.Visible = true;
            _Document document = word.Documents.Add(ref templateFile, ref m, ref m, ref m);

            Table templateTable = document.Tables[1];
            Range rngTbl = templateTable.Range;
            rngTbl.Collapse(WdCollapseDirection.wdCollapseEnd);
            //Target for inserting the data (end of the document)
            Range rng = document.Content;
            rng.Collapse(WdCollapseDirection.wdCollapseEnd);
            rng.Text = emplData;
            Table tblExtend = rng.ConvertToTable(";", m, m, m, m,
                    m, m, m, m, m, m, m, m, m,
                    m, WdDefaultTableBehavior.wdWord8TableBehavior);
            //Move the new table content to the end of the target table
            tblExtend.Range.Cut();
            rngTbl.PasteAppendTable();
            object fileName = @"звіт.docx";
            //document.Close(true, m, fileName);
            word.Quit(WdSaveOptions.wdSaveChanges, WdOriginalFormat.wdWordDocument);
            //ac.ActiveDocument.SaveAs(ref fileName,
            //    ref m, ref m, ref m, ref m, ref m,
            //    ref m, ref m, ref m, ref m, ref m,
            //    ref m, ref m, ref m, ref m, ref m);

        }
    }
}
