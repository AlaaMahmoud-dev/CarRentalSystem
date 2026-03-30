using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccessLayar
{
    public class VehicleModelDTO
    {
        public int ModelID { get; set; }
        public int MakeID { get; set; }
        public string ModelName { get; set; }
        public int Year { get; set; }
        public VehicleModelDTO() { }
        public VehicleModelDTO(int ModelID, string ModelName, int MakeID, int Year)
        {
            this.ModelID = ModelID;
            this.MakeID = MakeID;
            this.ModelName = ModelName;
            this.Year = Year;
        }
    }
    public class clsVehicleModelData
    {
        public static VehicleModelDTO GetVehicleModelByID(int modelID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT ModelID, MakeID, ModelName, Year FROM VehicleModels WHERE ModelID = @ModelID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelID", modelID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new VehicleModelDTO
                                {
                                    ModelID = (int)reader["ModelID"],
                                    MakeID = (int)reader["MakeID"],
                                    ModelName = reader["ModelName"].ToString(),
                                    Year = (int)reader["Year"]
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

        public static VehicleModelDTO GetVehicleModelByName(string modelName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM VehicleModels WHERE ModelName = @ModelName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelName", modelName);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new VehicleModelDTO
                                {
                                    ModelID = (int)reader["ModelID"],
                                    MakeID = (int)reader["MakeID"],
                                    ModelName = reader["ModelName"].ToString(),
                                    Year = (int)reader["Year"]
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

        public static DataTable GetAllVehicleModels()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT ModelID, MakeID, ModelName, Year FROM VehicleModels ORDER BY ModelName";
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
       
        public static int AddVehicleModel(VehicleModelDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    INSERT INTO VehicleModels (MakeID, ModelName, Year)
                    VALUES (@MakeID, @ModelName, @Year);
                    SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MakeID", dto.MakeID);
                        command.Parameters.AddWithValue("@ModelName", dto.ModelName);
                        command.Parameters.AddWithValue("@Year", dto.Year);

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

        public static bool UpdateVehicleModel(VehicleModelDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    UPDATE VehicleModels
                    SET MakeID = @MakeID,
                        ModelName = @ModelName,
                        Year = @Year
                    WHERE ModelID = @ModelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelID", dto.ModelID);
                        command.Parameters.AddWithValue("@MakeID", dto.MakeID);
                        command.Parameters.AddWithValue("@ModelName", dto.ModelName);
                        command.Parameters.AddWithValue("@Year", dto.Year);

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
        public static bool DeleteVehicleModel(int modelID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM VehicleModels WHERE ModelID = @ModelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelID", modelID);

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
        public static DataTable GetModelsByMakeID(int makeID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT ModelID, MakeID, ModelName, Year
                FROM VehicleModels
                WHERE MakeID = @MakeID
                ORDER BY ModelName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MakeID", makeID);

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
    }
}
