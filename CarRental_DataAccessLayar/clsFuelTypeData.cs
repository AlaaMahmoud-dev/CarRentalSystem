using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccessLayar
{
    public class FuelTypeDTO
    {
        public int FuelTypeID { get; set; }
        public string FuelTypeName { get; set; }

        public FuelTypeDTO() { }

        public FuelTypeDTO(int FuelTypeID, string FuelTypeName)
        {
            this.FuelTypeID = FuelTypeID;
            this.FuelTypeName = FuelTypeName;
        }
    }
    public class clsFuelTypeData
    {
        public static FuelTypeDTO GetFuelTypeByID(int fuelTypeID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT FuelTypeID, FuelTypeName FROM FuelTypes WHERE FuelTypeID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", fuelTypeID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new FuelTypeDTO(
                                    (int)reader["FuelTypeID"],
                                    reader["FuelTypeName"].ToString()
                                );
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
        public static FuelTypeDTO GetFuelTypeByName(string fuelTypeName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT FuelTypeID, FuelTypeName FROM FuelTypes WHERE FuelTypeName = @fuelTypeName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fuelTypeName", fuelTypeName);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new FuelTypeDTO(
                                    (int)reader["FuelTypeID"],
                                    reader["FuelTypeName"].ToString()
                                );
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
        public static DataTable GetAllFuelTypes()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT FuelTypeID, FuelTypeName FROM FuelTypes ORDER BY FuelTypeName";

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

        public static int AddFuelType(FuelTypeDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    INSERT INTO FuelTypes (FuelTypeName)
                    VALUES (@Name);
                    SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", dto.FuelTypeName);

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

        public static bool UpdateFuelType(FuelTypeDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "UPDATE FuelTypes SET FuelTypeName=@Name WHERE FuelTypeID=@ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", dto.FuelTypeID);
                        command.Parameters.AddWithValue("@Name", dto.FuelTypeName);

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
