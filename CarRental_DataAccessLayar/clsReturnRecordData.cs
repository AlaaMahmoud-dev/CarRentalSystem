using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccessLayar
{
    public class ReturnRecordDTO
    {
        public int ReturnRecordID { get; set; }
        public int VehicleBookRecordID { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public int CurrentMileages { get; set; }
        public int VehicleOldMileages { get; set; }
        public decimal AdditionalCharges { get; set; }
        public string FinalVehicleCheckNotes { get; set; }

        public ReturnRecordDTO() { }

        public ReturnRecordDTO(int returnRecordID, int vehicleBookRecordID,
            DateTime actualReturnDate, int currentMileages, int vehicleOldMileages,
            decimal additionalCharges, string finalVehicleCheckNotes)
        {
            this.ReturnRecordID = returnRecordID;
            this.VehicleBookRecordID = vehicleBookRecordID;
            this.ActualReturnDate = actualReturnDate;
            this.CurrentMileages = currentMileages;
            this.VehicleOldMileages = vehicleOldMileages;
            this.AdditionalCharges = additionalCharges;
            this.FinalVehicleCheckNotes = finalVehicleCheckNotes;
        }
    }
    public class clsReturnRecordData
    {
        public static ReturnRecordDTO GetReturnRecordByID(int returnRecordID)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM ReturnRecords WHERE ReturnRecordID=@ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", returnRecordID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ReturnRecordDTO
                                {
                                    ReturnRecordID = (int)reader["ReturnRecordID"],
                                    VehicleBookRecordID = (int)reader["VehicleBookRecordID"],
                                    ActualReturnDate = (DateTime)reader["ActualReturnDate"],
                                    CurrentMileages = (int)reader["CurrentMileages"],
                                    VehicleOldMileages = (int)reader["VehicleOldMileages"],
                                    AdditionalCharges = (decimal)reader["AdditionalCharges"],
                                    FinalVehicleCheckNotes = reader["FinalVehicleCheckNotes"].ToString()
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
        
        public static ReturnRecordDTO GetReturnRecordByBookingID(int BookingID)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM ReturnRecords WHERE VehicleBookRecordID=@ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", BookingID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ReturnRecordDTO
                                {
                                    ReturnRecordID = (int)reader["ReturnRecordID"],
                                    VehicleBookRecordID = (int)reader["VehicleBookRecordID"],
                                    ActualReturnDate = (DateTime)reader["ActualReturnDate"],
                                    CurrentMileages = (int)reader["CurrentMileages"],
                                    VehicleOldMileages = (int)reader["VehicleOldMileages"],
                                    AdditionalCharges = (decimal)reader["AdditionalCharges"],
                                    FinalVehicleCheckNotes = reader["FinalVehicleCheckNotes"].ToString()
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

        public static DataTable GetAllReturnRecords()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM VehicleReturnRecords_View ORDER BY ActualReturnDate DESC";

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

        public static int AddReturnRecord(ReturnRecordDTO dto, int VehicleID, decimal TotalActualDueAmount)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"Update Vehicles set Mileage = @CurrentMileages, Status=1 where VehicleID=@VehicleID;
Update VehicleBookRecords set Status = 3 where VehicleBookRecordID=@VehicleBookRecordID;
Update Payments set TotalActualDueAmount = @TotalActualDueAmount where VehicleBookRecordID=@VehicleBookRecordID;
                INSERT INTO ReturnRecords
                (VehicleBookRecordID, ActualReturnDate, CurrentMileages,
                 VehicleOldMileages, AdditionalCharges, FinalVehicleCheckNotes)
                VALUES
                (@VehicleBookRecordID, @ActualReturnDate, @CurrentMileages,
                 @VehicleOldMileages, @AdditionalCharges, @FinalVehicleCheckNotes);
                SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        command.Parameters.AddWithValue("@TotalActualDueAmount", TotalActualDueAmount);
                        command.Parameters.AddWithValue("@VehicleBookRecordID", dto.VehicleBookRecordID);
                        command.Parameters.AddWithValue("@ActualReturnDate", dto.ActualReturnDate);
                        command.Parameters.AddWithValue("@CurrentMileages", dto.CurrentMileages);
                        command.Parameters.AddWithValue("@VehicleOldMileages", dto.VehicleOldMileages);
                        command.Parameters.AddWithValue("@AdditionalCharges", dto.AdditionalCharges);
                        command.Parameters.AddWithValue("@FinalVehicleCheckNotes",
                            (object)dto.FinalVehicleCheckNotes ?? DBNull.Value);

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

        public static bool UpdateReturnRecord(ReturnRecordDTO dto)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                UPDATE ReturnRecords
                SET VehicleBookRecordID = @VehicleBookRecordID,
                    ActualReturnDate = @ActualReturnDate,
                    CurrentMileages = @CurrentMileages,
                    VehicleOldMileages = @VehicleOldMileages,
                    AdditionalCharges = @AdditionalCharges,
                    FinalVehicleCheckNotes = @FinalVehicleCheckNotes
                WHERE ReturnRecordID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", dto.ReturnRecordID);
                        command.Parameters.AddWithValue("@VehicleBookRecordID", dto.VehicleBookRecordID);
                        command.Parameters.AddWithValue("@ActualReturnDate", dto.ActualReturnDate);
                        command.Parameters.AddWithValue("@CurrentMileages", dto.CurrentMileages);
                        command.Parameters.AddWithValue("@VehicleOldMileages", dto.VehicleOldMileages);
                        command.Parameters.AddWithValue("@AdditionalCharges", dto.AdditionalCharges);
                        command.Parameters.AddWithValue("@FinalVehicleCheckNotes",
                            (object)dto.FinalVehicleCheckNotes ?? DBNull.Value);

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

        public static bool DeleteReturnRecord(int returnRecordID)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM ReturnRecords WHERE ReturnRecordID=@ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", returnRecordID);

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
