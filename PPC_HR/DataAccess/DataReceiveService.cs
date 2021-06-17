using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;

namespace PPC_HR.DataAccess
{
    public class DataReceiveService
    {
        private string connStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();


        //Employee previews on main screen
        public List<PersonPreview> GetPreviews()
        {
            List<PersonPreview> personPreviews = new List<PersonPreview>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
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




        //Disabled Employees Report
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


        //Military report employees
        public List<MilReportEmployees> GetMilReportEmployees()
        {
            List<MilReportEmployees> milEmployees = new List<MilReportEmployees>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from hr.MilEmployeesReport;", conn);
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        MilReportEmployees employee = new MilReportEmployees()
                        {
                            id = Convert.ToInt16(reader.GetValue(0)),
                            personInfo = reader.GetValue(1).ToString(),
                            birthDate = reader.GetValue(2).ToString(),
                            milRank = reader.GetValue(3).ToString(),
                            emplAddress = reader.GetValue(4).ToString(),
                            position = reader.GetValue(5).ToString()
                        };
                        milEmployees.Add(employee);
                    }
                    return milEmployees;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні даних.");
                return null;
            }
        }



        //Main info about employee
        public async Task<PersonInfo> GetPersonInfo(short emplid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    PersonInfo employee = new PersonInfo();
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("EXECUTE hr.GetPersonInfo " + emplid.ToString(), conn);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        employee.iid = Convert.ToDecimal(reader.GetValue(0));
                        employee.position = reader.GetValue(1).ToString();
                        employee.surname = reader.GetValue(2).ToString();
                        employee.firstname = reader.GetValue(3).ToString();
                        employee.patronymic = reader.GetValue(4).ToString();
                        employee.sex = Convert.ToChar(reader.GetValue(5));
                        employee.emplAddress = reader.GetValue(6).ToString();
                        employee.birthdate = reader.GetValue(7).ToString();
                        employee.phone = (decimal)reader.GetValue(8);
                        employee.cyclKomis = reader.GetValue(9).ToString();
                        employee.isMilitaryBound = reader.GetBoolean(10);
                        employee.isRetired = reader.GetBoolean(11);
                        employee.pedWorkload = reader.GetBoolean(12);
                        if (reader.GetValue(13) == (object)0) employee.photo = null;
                        else employee.photo = (byte[])reader.GetValue(13);
                        employee.emplid = emplid;
                    }
                    reader.Close();
                    return employee;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні даних (Осн інф).");
                return null;
            }
        }


        //Positions and experience info about employee
        public async Task<(List<PersonPosition>, PersonExperience)> GetPersonPositions(short emplid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    List<PersonPosition> positions = new List<PersonPosition>();
                    await conn.OpenAsync();
                    SqlCommand cmdPositions = new SqlCommand("exec hr.GetPositions " + emplid + " ;", conn);
                    SqlDataReader reader = await cmdPositions.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        PersonPosition position = new PersonPosition()
                        {
                            positionId = (short)reader.GetValue(0),
                            positionCode = (short)reader.GetValue(1),
                            positionName = reader.GetValue(2).ToString(),
                            positionVolume = (decimal)reader.GetValue(3),
                            isMainPosition = Convert.ToBoolean(reader.GetValue(4))
                        };
                        positions.Add(position);
                    }
                    reader.Close();
                    PersonExperience experience = new PersonExperience();
                    SqlCommand cmdExp = new SqlCommand("exec hr.GetExp " + emplid + " ;", conn);
                    SqlDataReader readerExp = await cmdExp.ExecuteReaderAsync();
                    while (await readerExp.ReadAsync())
                    {
                        experience.emplid = (short)readerExp.GetValue(0);
                        experience.totalExp = (short)readerExp.GetValue(1);
                        experience.specializationExp = (short)readerExp.GetValue(2);
                        experience.positionExp = (short)readerExp.GetValue(3);
                        experience.lastChangesDate = readerExp.GetValue(4).ToString();
                    }
                    readerExp.Close();
                    return (positions, experience);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні даних (посади).");
                return (null, null);
            }
        }


        //Diplomas info
        public async Task<List<PersonDiploma>> GetPersonDiplomas(short emplid)
        {
            try
            {
                List<PersonDiploma> list = new List<PersonDiploma>();
                using (SqlConnection conn = new SqlConnection(connStr))
                {

                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("EXECUTE hr.GetDiplomas " + emplid.ToString(), conn);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        PersonDiploma diploma = new PersonDiploma()
                        {
                            diplomaId = reader.GetInt16(0),
                            diplomaSeries = reader.GetString(1),
                            diplomaSerialNumber = reader.GetString(2),
                            educationalLevel = reader.GetString(3),
                            branch = reader.GetString(4),
                            issueDate = reader.GetString(5),
                            institution = reader.GetString(6),
                            pedEducation = reader.GetBoolean(7)
                        };
                        list.Add(diploma);
                    }
                    reader.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні даних (Освіта).");
                return null;
            }
        }


        //military info about employee
        public async Task<PersonMilitary> GetPersonMilitaryInfo(short emplid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    PersonMilitary employee = new PersonMilitary();
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("EXECUTE hr.GetMilInfo " + emplid.ToString(), conn);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        employee.emplId = reader.GetInt16(0);
                        employee.series = reader.GetString(1);
                        employee.serialNumber = reader.GetString(2);
                        employee.militaryDept = reader.GetString(3);
                        employee.militaryRank = reader.GetString(4);
                    }
                    reader.Close();
                    return employee;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні даних (військовозоб.).");
                return null;
            }
        }


        //disability info about employee
        public async Task<PersonDisability> GetPersonDisabilityInfo(short emplid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    PersonDisability employee = new PersonDisability();
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("EXECUTE hr.GetDisabilityInfo " + emplid.ToString(), conn);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        employee.emplId = reader.GetInt16(0);
                        employee.disabSeries = reader.GetString(1);
                        employee.disabNumber = reader.GetString(2);
                        employee.msecDateFrom = reader.GetString(3);
                        employee.timeIssued = reader.GetString(4);
                        employee.disabilityDateFrom = reader.GetString(5);
                        employee.disabilityDateTo = reader.GetString(6);
                        employee.disabilityGroup = reader.GetString(7);
                        employee.reason = reader.GetString(8);
                        if (reader.GetValue(9) == (object)0) employee.scancopy = null;
                        else employee.scancopy = (byte[])reader.GetValue(9);
                    }
                    reader.Close();
                    return employee;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні даних (інв.).");
                return null;
            }
        }



        //mentalhealth info about employee
        public async Task<PersonMentalCheck> GetPersonmentalHealthInfo(short emplid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    PersonMentalCheck employee = new PersonMentalCheck();
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("EXECUTE hr.GetmentalCheckInfo " + emplid.ToString(), conn);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        employee.emplId = reader.GetInt16(0);
                        employee.series = reader.GetString(1);
                        employee.serialNumber = reader.GetString(2);
                        employee.dateTo = reader.GetString(3);
                        if (reader.GetValue(4) == (object)0) employee.scancopy = null;
                        else employee.scancopy = (byte[])reader.GetValue(4);
                    }
                    reader.Close();
                    return employee;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні даних (психічна довідка).");
                return null;
            }
        }


        //Orders
        public List<Order> GetOrders()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    List<Order> list = new List<Order>();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from hr.orderView;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.orderId = reader.GetInt32(0);
                        order.emplId = reader.GetInt16(1);
                        order.orderName = reader.GetString(2);
                        order.emplName = reader.GetString(3);
                        order.orderTheme = reader.GetString(4);
                        order.orderThemeId = reader.GetInt32(5);
                        order.orderDate = reader.GetValue(6).ToString();
                        if (reader.GetValue(7) == (object)0) order.orderScan = null;
                        else order.orderScan = (byte[])reader.GetValue(7);
                        list.Add(order);
                    }
                    reader.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні даних (накази).");
                return null;
            }
        }


        public List<short> SearchEmpl(string input)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    List<short> list = new List<short>();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("exec hr.SearchWithIfEmpl " + input, conn);
                    //cmd.Parameters.AddWithValue(@"input", input);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader.GetInt16(0));
                    }
                    reader.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при пошуку.");
                return null;
            }
        }

        public List<PersonPreview> GetPreviews(List<short> idlist)
        {
            List<PersonPreview> personPreviews = new List<PersonPreview>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
            {
                foreach (short empl in idlist)
                {
                    PersonPreview preview = new PersonPreview();
                        conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from hr.employeePreview where emplid = " + empl, conn);
                    //cmd.Parameters.AddWithValue(@"emplId", empl);
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        preview.id = Convert.ToInt16(reader.GetValue(0));
                        preview.fullname = reader.GetValue(1).ToString();
                        preview.position = reader.GetValue(2).ToString();
                        preview.phone = reader.GetValue(3).ToString();
                    }
                    conn.Close();
                    personPreviews.Add(preview);

                }
            }
            return personPreviews;
        }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при виведенні результатів.");
                return null;
            }
}
    }
}
