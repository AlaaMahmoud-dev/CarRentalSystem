using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccessLayar
{
    public class VehicleMakeDTO
    {
        public int MakeID { get; set; }
        public string MakeName { get; set; }
        public VehicleMakeDTO() { }
        public VehicleMakeDTO(int MakeID, string MakeName)
        {
            this.MakeID = MakeID;
            this.MakeName = MakeName;
        }
    }
    public class clsVehicleMakeData
    {
        public static VehicleMakeDTO GetVehicleMakeByID(int makeID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT MakeID, MakeName FROM VehicleMakes WHERE MakeID = @MakeID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MakeID", makeID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new VehicleMakeDTO
                                {
                                    MakeID = (int)reader["MakeID"],
                                    MakeName = reader["MakeName"].ToString()
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

        public static VehicleMakeDTO GetVehicleMakeByName(string makeName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT MakeID, MakeName FROM VehicleMakes WHERE MakeName = @MakeName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MakeName", makeName);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new VehicleMakeDTO
                                {
                                    MakeID = (int)reader["MakeID"],
                                    MakeName = reader["MakeName"].ToString()
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

        public static DataTable GetAllVehicleMakes()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT MakeID, MakeName FROM VehicleMakes ORDER BY MakeName";
                    using (SqlCommand command = new SqlCommand(query, connection))
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

        public static int AddVehicleMake(VehicleMakeDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    INSERT INTO VehicleMakes (MakeName)
                    VALUES (@MakeName);
                    SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MakeName", dto.MakeName);

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

        public static bool UpdateVehicleMake(VehicleMakeDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    UPDATE VehicleMakes
                    SET MakeName = @MakeName
                    WHERE MakeID = @MakeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MakeID", dto.MakeID);
                        command.Parameters.AddWithValue("@MakeName", dto.MakeName);

                        connection.Open();
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
            }

            return false;
        }
    }
}
