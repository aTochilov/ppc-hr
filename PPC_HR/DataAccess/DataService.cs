using System.Configuration;
using System.Collections.Generic;
using System;
using System.Windows;
using System.Data.SqlClient;

namespace PPC_HR.DataAccess
{
    public interface IDataService
    {
        List<PersonPreview> GetPreviews();
    }

    public class DataService : IDataService
    {
        private string connStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

        public List<PersonPreview> GetPreviews()
        {
            List<PersonPreview> personPreviews = new List<PersonPreview>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr)) {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from hr.employeePreview;", conn);
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        PersonPreview preview = new PersonPreview()
                        {
                            id = Convert.ToInt16(reader.GetValue(0)),
                            fullname = reader.GetValue(1).ToString(),
                            position = reader.GetValue(2).ToString(),
                            phone = reader.GetValue(3).ToString()
                        };
                        personPreviews.Add(preview);
                    }
                    return personPreviews;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні даних.");
                return null;
            }
        }


        public List<DisabledEmployeeReport> GetDisabledEmployeesReport()
        {
            List<DisabledEmployeeReport> disabledEmployees = new List<DisabledEmployeeReport>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from hr.disabledEmployeesReport;", conn);
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        DisabledEmployeeReport employee = new DisabledEmployeeReport()
                        {
                            id = Convert.ToInt16(reader.GetValue(0)),
                            personInfo = reader.GetValue(1).ToString(),
                            msecInfo = reader.GetValue(2).ToString(),
                            group = reader.GetValue(3).ToString(),
                            dateFrom = reader.GetValue(4).ToString(),
                            dateTo = reader.GetValue(5).ToString(),
                            address = reader.GetValue(6).ToString(),
                            monthInWork = Convert.ToInt16(reader.GetValue(7)),
                            position = reader.GetValue(8).ToString(),
                            orderHired = reader.GetValue(9).ToString(),
                            orderFired = reader.GetValue(10).ToString(),
                        };
                        disabledEmployees.Add(employee);
                    }
                    return disabledEmployees;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні даних.");
                return null;
            }
        }
    }
}
