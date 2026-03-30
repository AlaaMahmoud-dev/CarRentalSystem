using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccessLayar
{
    public class LicenseClassDTO
    {
        public int LicesneClassID {  get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public LicenseClassDTO() { }
        public LicenseClassDTO(int LicenseClassID, string ClassName, string Description) 
        {
            this.LicesneClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.Description = Description;
        }
    }
    public class clsLicenseClassData
    {
        public static LicenseClassDTO GetLicenseClassByID(int licenseClassID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT LicenseClassID, ClassName, ClassDescription FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";
                    using (SqlCommand command = new SqlCommand(
                        query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);


                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new LicenseClassDTO
                                {
                                    LicesneClassID = (int)reader["LicenseClassID"],
                                    ClassName = reader["ClassName"].ToString(),
                                    Description = reader["ClassDescription"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
            }
            
            return null;
        }
        public static LicenseClassDTO GetLicenseClassByName(string className)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query =
                        "SELECT LicenseClassID, ClassName, ClassDescription FROM LicenseClasses WHERE ClassName = @ClassName";
                    using (SqlCommand command = new SqlCommand(
                      query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassName", className);


                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new LicenseClassDTO
                                {
                                    LicesneClassID = (int)reader["LicenseClassID"],
                                    ClassName = reader["ClassName"].ToString(),
                                    Description = reader["ClassDescription"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
            }
            

            return null;
        }

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT LicenseClassID, ClassName, ClassDescription FROM LicenseClasses ORDER BY ClassName";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return null;
            
            }
        
            return dt;
        }
        public static int AddLicenseClass(LicenseClassDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                                  INSERT INTO LicenseClasses (ClassName, ClassDescription)
                                  VALUES (@ClassName, @ClassDescription);
                                  SELECT SCOPE_IDENTITY();";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassName", dto.ClassName);
                        command.Parameters.AddWithValue("@ClassDescription", dto.Description);


                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int id))
                            return id;
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
            }
            

            return -1;
        }

        public static bool UpdateLicenseClass(LicenseClassDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                                 UPDATE LicenseClasses
                                 SET ClassName = @ClassName,
                                     ClassDescription = @ClassDescription
                                 WHERE LicenseClassID = @LicenseClassID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseClassID", dto.LicesneClassID);
                        command.Parameters.AddWithValue("@ClassName", dto.ClassName);
                        command.Parameters.AddWithValue("@ClassDescription", dto.Description);


                        connection.Open();
                        return command.ExecuteNonQuery() > 0;
                    } }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
            
            }

            return false;
        }


    }
}
