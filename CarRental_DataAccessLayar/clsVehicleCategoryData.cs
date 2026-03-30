using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccessLayar
{
    public class VehicleCategoryDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public VehicleCategoryDTO() { }

        public VehicleCategoryDTO(int CategoryID, string CategoryName)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
        }
    }
    public class clsVehicleCategoryData
    {
        public static VehicleCategoryDTO GetVehicleCategoryByID(int categoryID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT CategoryID, CategoryName FROM VehicleCategories WHERE CategoryID = @CategoryID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new VehicleCategoryDTO
                                {
                                    CategoryID = (int)reader["CategoryID"],
                                    CategoryName = reader["CategoryName"].ToString()
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

        public static VehicleCategoryDTO GetVehicleCategoryByName(string categoryName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT CategoryID, CategoryName FROM VehicleCategories WHERE CategoryName = @CategoryName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryName", categoryName);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new VehicleCategoryDTO
                                {
                                    CategoryID = (int)reader["CategoryID"],
                                    CategoryName = reader["CategoryName"].ToString()
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

        public static DataTable GetAllVehicleCategories()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT CategoryID, CategoryName FROM VehicleCategories ORDER BY CategoryName";
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

        public static int AddVehicleCategory(VehicleCategoryDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    INSERT INTO VehicleCategories (CategoryName)
                    VALUES (@CategoryName);
                    SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryName", dto.CategoryName);

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

        public static bool UpdateVehicleCategory(VehicleCategoryDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    UPDATE VehicleCategories
                    SET CategoryName = @CategoryName
                    WHERE CategoryID = @CategoryID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", dto.CategoryID);
                        command.Parameters.AddWithValue("@CategoryName", dto.CategoryName);

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

        public static bool DeleteVehicleCategory(int categoryID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM VehicleCategories WHERE CategoryID = @CategoryID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryID);

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
