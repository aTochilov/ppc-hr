
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;

namespace PPC_HR.DataAccess
{
    public class DataSendingService
    {

        private string connStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

        public void SendPersonInfo(PersonInfo employee)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                SqlCommand cmd = new SqlCommand("update hr.employees set " +
                    " iid = @iid, " +
                    "surname = @surname, firstname = @firstName, patronymic = @patronymic, " +
                    "sex = @sex, " +
                    "emplAddress = @address, birthdate = @birthDate, phone = @phone, " +
                    "cyclKomis = @cyclKomis, isMilitaryBound = @milLiable, isRetired = @retired, " +
                    "pedWorkload = @pedWorkload, photo = @photo " +
                    "where emplId = @emplId;", conn);
                    //+ employee.emplid + " , " + employee.iid+ " , " +
                    //employee.firstname + " , " + employee.surname + " , " + employee.patronymic + " , " + employee.phone + " , " + 
                    //employee.emplAddress + " , " + employee.birthdate + " , " + employee.cyclKomis + " , " +
                    //employee.pedWorkload + " , " + employee.isMilitaryBound + " , " + employee.isRetired + " , " + employee.photo + " )"

                    ////"emplId, iid, " +
                    ////"firstName , surname , patronymic, phone, address, birthDate, cyclKomis, " +
                    ////" pedWorkload, milLiable, retired, photo ;", conn);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(employee.emplid);
                    //cmd.Parameters.Add(@"iid", System.Data.SqlDbType.Decimal); cmd.Parameters[@"iid"].Value = Convert.ToDecimal(employee.iid);
                    //cmd.Parameters.Add(@"firstName", System.Data.SqlDbType.VarChar); cmd.Parameters[@"firstName"].Value = Convert.ToString(employee.firstname);
                    //cmd.Parameters.Add(@"surname", System.Data.SqlDbType.VarChar); cmd.Parameters[@"surname"].Value = Convert.ToString(employee.surname);
                    //cmd.Parameters.Add("patronymic", System.Data.SqlDbType.VarChar); cmd.Parameters["patronymic"].Value = Convert.ToString(employee.patronymic);
                    //cmd.Parameters.Add(@"sex", System.Data.SqlDbType.Char); cmd.Parameters[@"sex"].Value = Convert.ToChar(employee.sex);
                    //cmd.Parameters.Add(@"phone", System.Data.SqlDbType.Decimal); cmd.Parameters[@"phone"].Value = Convert.ToDecimal(employee.phone);
                    //cmd.Parameters.Add(@"address", System.Data.SqlDbType.VarChar); cmd.Parameters[@"address"].Value = Convert.ToString(employee.emplAddress);

                    cmd.Parameters.AddWithValue(@"iid", employee.iid);
                    cmd.Parameters.AddWithValue(@"firstName", employee.firstname);
                    cmd.Parameters.AddWithValue(@"surname", employee.surname);
                    cmd.Parameters.AddWithValue(@"patronymic", employee.patronymic);
                    cmd.Parameters.AddWithValue(@"sex", employee.sex);
                    cmd.Parameters.AddWithValue(@"phone", Convert.ToDecimal(employee.phone));
                    cmd.Parameters.AddWithValue(@"address", employee.emplAddress);
                    cmd.Parameters.AddWithValue(@"birthDate", employee.birthdate);
                    cmd.Parameters.AddWithValue(@"cyclKomis", employee.cyclKomis);
                    cmd.Parameters.AddWithValue(@"pedWorkload", employee.pedWorkload);
                    cmd.Parameters.AddWithValue(@"milLiable", employee.isMilitaryBound);
                    cmd.Parameters.AddWithValue(@"retired", employee.isRetired);
                    cmd.Parameters.AddWithValue(@"photo", employee.photo);
                    //SqlCommand cmd = new SqlCommand("update hr.employees set iid = " + employee.iid + ", surname = '" + employee.surname + "', firstname = '" + employee.firstname + "', " +
                    //    "patronymic = '" + employee.patronymic + "', sex = '" + employee.sex + "', emplAddress = '" + employee.emplAddress + "', birthdate = '" + employee.birthdate + "', phone = " + employee.phone + ", " +
                    //    "cyclKomis = '" + employee.cyclKomis + "', isMilitaryBound = " + employee.isMilitaryBound + ", isRetired = " + employee.isRetired + ", pedWorkload = " + employee.pedWorkload + ", photo = " + employee.photo + "  where emplId = " + employee.emplid + ";", conn);  
                    conn.Open();
                    cmd.ExecuteNonQuery();
                        conn.Close();
                    conn.Dispose();
                
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при відправці даних даних (Осн інф).");
            }
        }

        public void InsertPersonInfo(PersonInfo employee)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("insert into hr.employees (iid,  surname, firstname, patronymic, sex, emplAddress, " +
                        "birthdate, phone, cyclKomis, isMilitaryBound, isRetired, pedWorkload, photo) " +
                        "values (@iid, @surname,  @firstName, @patronymic, " +
                        "@sex, @address, @birthDate, @phone, @cyclKomis, @milLiable, @retired, @pedWorkload, @photo);", conn);
                    cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(employee.emplid);
                    cmd.Parameters.AddWithValue(@"iid", employee.iid);
                    cmd.Parameters.AddWithValue(@"firstName", employee.firstname);
                    cmd.Parameters.AddWithValue(@"surname", employee.surname);
                    cmd.Parameters.AddWithValue(@"patronymic", employee.patronymic);
                    cmd.Parameters.AddWithValue(@"sex", employee.sex);
                    cmd.Parameters.AddWithValue(@"phone", Convert.ToDecimal(employee.phone));
                    cmd.Parameters.AddWithValue(@"address", employee.emplAddress);
                    cmd.Parameters.AddWithValue(@"birthDate", employee.birthdate);
                    cmd.Parameters.AddWithValue(@"cyclKomis", employee.cyclKomis);
                    cmd.Parameters.AddWithValue(@"pedWorkload", employee.pedWorkload);
                    cmd.Parameters.AddWithValue(@"milLiable", employee.isMilitaryBound);
                    cmd.Parameters.AddWithValue(@"retired", employee.isRetired);
                    cmd.Parameters.AddWithValue(@"photo", employee.photo);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();

                }
        }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при відправці даних даних (Осн інф).");
            }
}


        public void SendPositionInfo(List<PersonPosition> list)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    foreach (PersonPosition pos in list)
                    { 
                        SqlCommand cmd = new SqlCommand("update hr.positions set positionCode = @positionCode, positionName = @PositionName, positionVolume = @PositionVolume where positionId = @positionId;" , conn);
                        
                        cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(pos.emplid);
                            cmd.Parameters.AddWithValue(@"positionId", pos.positionId);
                            cmd.Parameters.AddWithValue(@"positionCode", pos.positionCode);
                            cmd.Parameters.AddWithValue(@"positionName", pos.positionName);
                            cmd.Parameters.AddWithValue(@"positionVolume", pos.positionVolume);
                            //cmd.Parameters.AddWithValue(@"isMainPosition", pos.isMainPosition);
                        cmd.ExecuteNonQuery();
                        if (pos.isMainPosition == true)
                        {
                            SqlCommand cmdMP = new SqlCommand(" UPDATE hr.employees SET employees.mainPosition = @positionId FROM hr.positions p JOIN hr.employees e ON(e.emplId = p.emplId) WHERE e.emplId = @emplId AND p.positionId = @positionId; ", conn);
                            cmdMP.Parameters.AddWithValue(@"positionId", pos.positionId);
                            cmdMP.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmdMP.Parameters[@"emplId"].Value = Convert.ToInt16(pos.emplid);
                            cmdMP.ExecuteNonQuery();

                        }
                    }    
                    conn.Close();
                    conn.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("помилка при відправці даних даних (посади).");
            }
        }

        public void InsertPositionInfo(List<PersonPosition> list)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    foreach (PersonPosition pos in list)
                    {
                        SqlCommand cmd = new SqlCommand("insert into hr.positions (emplId, positionCode , positionName , positionVolume) " +
                            "values( @positionCode, @PositionName, @PositionVolume);", conn);

                        cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(pos.emplid);
                        cmd.Parameters.AddWithValue(@"positionId", pos.positionId);
                        cmd.Parameters.AddWithValue(@"positionCode", pos.positionCode);
                        cmd.Parameters.AddWithValue(@"positionName", pos.positionName);
                        cmd.Parameters.AddWithValue(@"positionVolume", pos.positionVolume);
                        //cmd.Parameters.AddWithValue(@"isMainPosition", pos.isMainPosition);
                        cmd.ExecuteNonQuery();
                        if (pos.isMainPosition == true)
                        {
                            SqlCommand cmdMP = new SqlCommand(" UPDATE hr.employees SET employees.mainPosition = @positionId FROM hr.positions p JOIN hr.employees e ON(e.emplId = p.emplId) WHERE e.emplId = @emplId AND p.positionId = @positionId; ", conn);
                            cmdMP.Parameters.AddWithValue(@"positionId", pos.positionId);
                            cmdMP.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmdMP.Parameters[@"emplId"].Value = Convert.ToInt16(pos.emplid);
                            cmdMP.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("помилка при відправці даних даних (посади).");
            }
        }


        public void SendPedExp(PersonExperience exp)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                        SqlCommand cmd = new SqlCommand("update hr.pedExperience set totalExp = @totalexp, specializationExp = @specExp, positionExp = @posExp, lastChangesDate = @lastchanges where emplid = @emplid;", conn);

                        cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(exp.emplid);
                        cmd.Parameters.AddWithValue(@"totalexp", Convert.ToInt16(exp.totalExp));
                        cmd.Parameters.AddWithValue(@"specExp", Convert.ToInt16(exp.specializationExp));
                        cmd.Parameters.AddWithValue(@"posExp", Convert.ToInt16(exp.positionExp));
                        cmd.Parameters.AddWithValue(@"lastchanges", Convert.ToDateTime(exp.lastChangesDate));
                        cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("помилка при відправці даних даних (стаж).");
            }
        }

        public void InsertPedExp(PersonExperience exp)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into hr.pedExperience ( totalExp, specializationExp, positionExp, lastChangesDate " +
                        "values (@totalexp, @specExp, @posExp, @lastchanges );", conn);

                    cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(exp.emplid);
                    cmd.Parameters.AddWithValue(@"totalexp", Convert.ToInt16(exp.totalExp));
                    cmd.Parameters.AddWithValue(@"specExp", Convert.ToInt16(exp.specializationExp));
                    cmd.Parameters.AddWithValue(@"posExp", Convert.ToInt16(exp.positionExp));
                    cmd.Parameters.AddWithValue(@"lastchanges", Convert.ToDateTime(exp.lastChangesDate));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("помилка при відправці даних даних (стаж).");
            }
        }



        public void SendDiplomasInfo(List<PersonDiploma> list)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    foreach (PersonDiploma diploma in list)
                    {
                        SqlCommand cmd = new SqlCommand("update hr.diploma set series = @series, serialNumber = @serialNumber, " +
                            "educationalLevel = @educationalLevel,  branch = @branch, issueDate = @issueDate, institution = @institution, " +
                            "pedEducation = @pedEducation where diplomaId = @diplomaId;", conn);

                        cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(diploma.emplId);
                        cmd.Parameters.AddWithValue(@"diplomaId", diploma.diplomaId);
                        cmd.Parameters.AddWithValue(@"series", diploma.diplomaSeries);
                        cmd.Parameters.AddWithValue(@"serialNumber", diploma.diplomaSerialNumber);
                        cmd.Parameters.AddWithValue(@"educationalLevel", diploma.educationalLevel);
                        cmd.Parameters.AddWithValue(@"branch", diploma.branch);
                        cmd.Parameters.AddWithValue(@"issueDate", Convert.ToDateTime(diploma.issueDate));
                        cmd.Parameters.AddWithValue(@"institution", diploma.institution);
                        cmd.Parameters.AddWithValue(@"pedEducation", diploma.pedEducation);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    conn.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("помилка при відправці даних даних (освіта).");
            }
        }

        public void InsertDiplomasInfo(List<PersonDiploma> list)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    foreach (PersonDiploma diploma in list)
                    {
                        SqlCommand cmd = new SqlCommand("insert into hr.diploma ( series, serialNumber, " +
                            "educationalLevel,  branch, issueDate, institution, " +
                            "pedEducation) values (@series, @serialNumber,  @educationalLevel, @branch, @issueDate, @institution, @pedEducation);", conn);

                        cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(diploma.emplId);
                        cmd.Parameters.AddWithValue(@"diplomaId", diploma.diplomaId);
                        cmd.Parameters.AddWithValue(@"series", diploma.diplomaSeries);
                        cmd.Parameters.AddWithValue(@"serialNumber", diploma.diplomaSerialNumber);
                        cmd.Parameters.AddWithValue(@"educationalLevel", diploma.educationalLevel);
                        cmd.Parameters.AddWithValue(@"branch", diploma.branch);
                        cmd.Parameters.AddWithValue(@"issueDate", Convert.ToDateTime(diploma.issueDate));
                        cmd.Parameters.AddWithValue(@"institution", diploma.institution);
                        cmd.Parameters.AddWithValue(@"pedEducation", diploma.pedEducation);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    conn.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("помилка при відправці даних даних (освіта).");
            }
        }



        public void SendMilitaryInfo(PersonMilitary military)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update hr.militaryLiable set series = @series, serialNumber = @serialNumber, militaryDept = @militaryDept, militaryRank = @militaryRank where emplid = @emplid;", conn);

                    cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(military.emplId);
                    cmd.Parameters.AddWithValue(@"series", Convert.ToString(military.series));
                    cmd.Parameters.AddWithValue(@"serialNumber", Convert.ToString(military.serialNumber));
                    cmd.Parameters.AddWithValue(@"militaryDept", Convert.ToString(military.militaryRank));
                    cmd.Parameters.AddWithValue(@"militaryRank", Convert.ToString(military.militaryDept));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("помилка при відправці даних даних (Військ.).");
            }
        }

        public void InsertMilitaryInfo(PersonMilitary military)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into hr.militaryLiable ( emplid, series, serialNumber, militaryDept, militaryRank ) " +
                        "values (@emplId, @series, @serialNumber, @militaryDept, @militaryRank) ;", conn);

                    cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(military.emplId);
                    cmd.Parameters.AddWithValue(@"series", Convert.ToString(military.series));
                    cmd.Parameters.AddWithValue(@"serialNumber", Convert.ToString(military.serialNumber));
                    cmd.Parameters.AddWithValue(@"militaryDept", Convert.ToString(military.militaryRank));
                    cmd.Parameters.AddWithValue(@"militaryRank", Convert.ToString(military.militaryDept));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("помилка при відправці даних даних (Військ.).");
            }
        }


        public void SendDisabilityInfo(PersonDisability disability)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update hr.disabledEmployees set series = @series, serialNumber = @serialNumber," +
                        " msecDateFrom = @msecDateFrom, timeIssued = @timeIssued, disabilityDateFrom = @disabilityDateFrom, " +
                        "disabilityDateTo = @disabilityDateTo, disabilityGroup = @disabilityGroup, " +
                        "reason = @reason, scancopy = @scancopy where emplid = @emplid;", conn);

                    cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(disability.emplId);
                    cmd.Parameters.AddWithValue(@"series", Convert.ToString(disability.disabSeries));
                    cmd.Parameters.AddWithValue(@"serialNumber", Convert.ToString(disability.disabNumber));
                    cmd.Parameters.AddWithValue(@"msecDateFrom", Convert.ToString(disability.msecDateFrom));
                    cmd.Parameters.AddWithValue(@"timeIssued", Convert.ToString(disability.timeIssued));
                    cmd.Parameters.AddWithValue(@"disabilityDateFrom", Convert.ToString(disability.disabilityDateFrom));
                    cmd.Parameters.AddWithValue(@"disabilityDateTo", Convert.ToString(disability.disabilityDateTo));
                    cmd.Parameters.AddWithValue(@"disabilityGroup", Convert.ToChar(disability.disabilityGroup));
                    cmd.Parameters.AddWithValue(@"reason", Convert.ToString(disability.reason));
                    cmd.Parameters.AddWithValue(@"scancopy", (byte[])disability.scancopy);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show("помилка при відправці даних даних (інв.).");
            }
        }

        public void InsertDisabilityInfo(PersonDisability disability)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into hr.disabledEmployees  (emplid, series, serialNumber, " +
                        "msecDateFrom, timeIssued, disabilityDateFrom, disabilityDateTo, disabilityGroup, reason, scancopy) " +
                        "values (@emplid, @series, @serialNumber, @msecDateFrom, @timeIssued, @disabilityDateFrom, @disabilityDateTo, " +
                        "@disabilityGroup, @reason, @scancopy);", conn);

                    cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(disability.emplId);
                    cmd.Parameters.AddWithValue(@"series", Convert.ToString(disability.disabSeries));
                    cmd.Parameters.AddWithValue(@"serialNumber", Convert.ToString(disability.disabNumber));
                    cmd.Parameters.AddWithValue(@"msecDateFrom", Convert.ToString(disability.msecDateFrom));
                    cmd.Parameters.AddWithValue(@"timeIssued", Convert.ToString(disability.timeIssued));
                    cmd.Parameters.AddWithValue(@"disabilityDateFrom", Convert.ToString(disability.disabilityDateFrom));
                    cmd.Parameters.AddWithValue(@"disabilityDateTo", Convert.ToString(disability.disabilityDateTo));
                    cmd.Parameters.AddWithValue(@"disabilityGroup", Convert.ToChar(disability.disabilityGroup));
                    cmd.Parameters.AddWithValue(@"reason", Convert.ToString(disability.reason));
                    cmd.Parameters.AddWithValue(@"scancopy", (byte[])disability.scancopy);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("помилка при відправці даних даних (інв.).");
            }
        }


        public void SendMentalCheckInfo(PersonMentalCheck personMental)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update hr.mentalHealthCheck set series = @series, serialNumber = @serialNumber," +
                        " DateTo = @DateTo, scancopy = @scancopy where emplid = @emplid;", conn);

                    cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(personMental.emplId);
                    cmd.Parameters.AddWithValue(@"series", Convert.ToString(personMental.series));
                    cmd.Parameters.AddWithValue(@"serialNumber", Convert.ToString(personMental.serialNumber));
                    cmd.Parameters.AddWithValue(@"DateTo", Convert.ToDateTime(personMental.dateTo));
                    cmd.Parameters.AddWithValue(@"scancopy", (byte[])personMental.scancopy);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("помилка при відправці даних даних (психдисп.).");
            }
        }

        public void InsertMentalCheckInfo(PersonMentalCheck personMental)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into hr.mentalHealthCheck (emplid, series, serialNumber, DateTo, scancopy )" +
                        "values (@emplid, @series, @serialNumber, @DateTo, @scancopy);", conn);

                    cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(personMental.emplId);
                    cmd.Parameters.AddWithValue(@"series", Convert.ToString(personMental.series));
                    cmd.Parameters.AddWithValue(@"serialNumber", Convert.ToString(personMental.serialNumber));
                    cmd.Parameters.AddWithValue(@"DateTo", Convert.ToDateTime(personMental.dateTo));
                    cmd.Parameters.AddWithValue(@"scancopy", (byte[])personMental.scancopy);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("помилка при відправці даних даних (психдисп.).");
            }
        }


        public void DeletePerson(short emplId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from hr.employees where emplid = @emplid;", conn);
                    cmd.Parameters.Add(@"emplId", System.Data.SqlDbType.SmallInt); cmd.Parameters[@"emplId"].Value = Convert.ToInt16(emplId);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("помилка при видаленні.");
            }
        }


        
    }
}
