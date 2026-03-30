using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccessLayar
{
    public class VehicleDTO
    {
        public int VehicleID { get; set; }
        public int ModelID { get; set; }
        public int Mileage { get; set; }
        public string PlateNumber { get; set; }
        public decimal RentalCostPerDay { get; set; }
        public byte Status { get; set; }
        public int FuelType { get; set; }
        public int VehicleCategory { get; set; }

        public VehicleDTO() { }

        public VehicleDTO(int VehicleID, int ModelID, int Mileage,
            string PlateNumber, decimal RentalCostPerDay,
            byte Status, int FuelType, int VehicleCategory)
        {
            this.VehicleID = VehicleID;
            this.ModelID = ModelID;
            this.Mileage = Mileage;
            this.PlateNumber = PlateNumber;
            this.RentalCostPerDay = RentalCostPerDay;
            this.Status = Status;
            this.FuelType = FuelType;
            this.VehicleCategory = VehicleCategory;
        }
    }
    public class clsVehicleData
    {
        public static VehicleDTO GetVehicleByID(int vehicleID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Vehicles WHERE VehicleID=@ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", vehicleID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new VehicleDTO(
                                    (int)reader["VehicleID"],
                                    (int)reader["ModelID"],
                                    (int)reader["Mileage"],
                                    reader["PlateNumber"].ToString(),
                                    (decimal)reader["RentalCostPerDay"],
                                    (byte)reader["Status"],
                                    (int)reader["FuelType"],
                                    (int)reader["VehicleCategory"]
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
        public static VehicleDTO GetVehicleByPlateNumber(string plateNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Vehicles WHERE PlateNumber=@plateNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@plateNumber", plateNumber);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new VehicleDTO(
                                    (int)reader["VehicleID"],
                                    (int)reader["ModelID"],
                                    (int)reader["Mileage"],
                                    reader["PlateNumber"].ToString(),
                                    (decimal)reader["RentalCostPerDay"],
                                    (byte)reader["Status"],
                                    (int)reader["FuelType"],
                                    (int)reader["VehicleCategory"]
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
        public static DataTable GetAllVehicles()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Vehicles_View";

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

        public static int AddVehicle(VehicleDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                INSERT INTO Vehicles
                (ModelID, Mileage, PlateNumber, RentalCostPerDay, Status, FuelType, VehicleCategory)
                VALUES
                (@ModelID,@Mileage,@Plate,@Cost,@Status,@Fuel,@Category);
                SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelID", dto.ModelID);
                        command.Parameters.AddWithValue("@Mileage", dto.Mileage);
                        command.Parameters.AddWithValue("@Plate", dto.PlateNumber);
                        command.Parameters.AddWithValue("@Cost", dto.RentalCostPerDay);
                        command.Parameters.AddWithValue("@Status", dto.Status);
                        command.Parameters.AddWithValue("@Fuel", dto.FuelType);
                        command.Parameters.AddWithValue("@Category", dto.VehicleCategory);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (int.TryParse(result.ToString(), out int id))
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

        public static bool UpdateVehicle(VehicleDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                UPDATE Vehicles SET
                ModelID=@ModelID,
                Mileage=@Mileage,
                PlateNumber=@Plate,
                RentalCostPerDay=@Cost,
                Status=@Status,
                FuelType=@Fuel,
                VehicleCategory=@Category
                WHERE VehicleID=@ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", dto.VehicleID);
                        command.Parameters.AddWithValue("@ModelID", dto.ModelID);
                        command.Parameters.AddWithValue("@Mileage", dto.Mileage);
                        command.Parameters.AddWithValue("@Plate", dto.PlateNumber);
                        command.Parameters.AddWithValue("@Cost", dto.RentalCostPerDay);
                        command.Parameters.AddWithValue("@Status", dto.Status);
                        command.Parameters.AddWithValue("@Fuel", dto.FuelType);
                        command.Parameters.AddWithValue("@Category", dto.VehicleCategory);

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

        public static bool DeleteVehicle(int VehicleID)
        {
            string query = "delete from Vehicles where VehicleID=@VehicleID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@VehicleID", VehicleID);

                        connection.Open();

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return false;
            }
        }
    }
}
