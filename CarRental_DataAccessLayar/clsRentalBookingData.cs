using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccessLayar
{
    public class RentalBookingDTO
    {
        public int RentalBookingID { get; set; }

        public int CustomerID { get; set; }

        public int VehicleID { get; set; }

        public DateTime RentedAt { get; set; }

        public DateTime DueDate { get; set; }

        public string PickUpLocation { get; set; }

        public string DropOffLocation { get; set; }

        public string VehicleConditionNotes { get; set; }

        public int Status { get; set; }

        public RentalBookingDTO() { }

        public RentalBookingDTO(
            int RentalBookingID,
            int CustomerID,
            int VehicleID,
            DateTime RentedAt,
            DateTime DueDate,
            string PickUpLocation,
            string DropOffLocation,
            string VehicleConditionNotes,
            int Status)
        {
            this.RentalBookingID = RentalBookingID;
            this.CustomerID = CustomerID;
            this.VehicleID = VehicleID;
            this.RentedAt = RentedAt;
            this.DueDate = DueDate;
            this.PickUpLocation = PickUpLocation;
            this.DropOffLocation = DropOffLocation;
            this.VehicleConditionNotes = VehicleConditionNotes;
            this.Status = Status;
        }
    }
    public class clsRentalBookingData
    {
        
        public static RentalBookingDTO GetBookingByID(int bookingID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM VehicleBookRecords WHERE VehicleBookRecordID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", bookingID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new RentalBookingDTO
                                {
                                    RentalBookingID = (int)reader["VehicleBookRecordID"],
                                    CustomerID = (int)reader["CustomerID"],
                                    VehicleID = (int)reader["VehicleID"],
                                    RentedAt = (DateTime)reader["RentedAt"],
                                    DueDate = (DateTime)reader["DueDate"],
                                    PickUpLocation = reader["PickUpLocation"].ToString(),
                                    DropOffLocation = reader["DropOffLocation"].ToString(),
                                    VehicleConditionNotes = reader["VehicleConditionNotes"].ToString(),
                                    Status = (int)reader["Status"]
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
        
        public static RentalBookingDTO GetBookingByVehicleID(int VehicleID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM VehicleBookRecords WHERE VehicleID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", VehicleID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new RentalBookingDTO
                                {
                                    RentalBookingID = (int)reader["VehicleBookRecordID"],
                                    CustomerID = (int)reader["CustomerID"],
                                    VehicleID = (int)reader["VehicleID"],
                                    RentedAt = (DateTime)reader["RentedAt"],
                                    DueDate = (DateTime)reader["DueDate"],
                                    PickUpLocation = reader["PickUpLocation"].ToString(),
                                    DropOffLocation = reader["DropOffLocation"].ToString(),
                                    VehicleConditionNotes = reader["VehicleConditionNotes"].ToString(),
                                    Status = (int)reader["Status"]
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
        public static DataTable GetAllBookings()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM RentalBookingRecords_View ORDER BY RentedAt DESC";

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

        public static int AddBooking(RentalBookingDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                INSERT INTO VehicleBookRecords
                (CustomerID, VehicleID, RentedAt, DueDate,
                 PickUpLocation, DropOffLocation, VehicleConditionNotes, Status)
                VALUES
                (@CustomerID, @VehicleID, @RentedAt, @DueDate,
                 @PickUpLocation, @DropOffLocation, @VehicleConditionNotes, @Status);
                SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", dto.CustomerID);
                        command.Parameters.AddWithValue("@VehicleID", dto.VehicleID);
                        command.Parameters.AddWithValue("@RentedAt", dto.RentedAt);
                        command.Parameters.AddWithValue("@DueDate", dto.DueDate);
                        command.Parameters.AddWithValue("@PickUpLocation", dto.PickUpLocation);
                        command.Parameters.AddWithValue("@DropOffLocation", (object)dto.DropOffLocation ?? DBNull.Value);
                        command.Parameters.AddWithValue("@VehicleConditionNotes", (object)dto.VehicleConditionNotes ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Status", dto.Status);

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

        public static bool UpdateBooking(RentalBookingDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                UPDATE VehicleBookRecords
                SET CustomerID = @CustomerID,
                    VehicleID = @VehicleID,
                    RentedAt = @RentedAt,
                    DueDate = @DueDate,
                    PickUpLocation = @PickUpLocation,
                    DropOffLocation = @DropOffLocation,
                    VehicleConditionNotes = @VehicleConditionNotes,
                    Status = @Status
                WHERE VehicleBookRecordID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", dto.RentalBookingID);
                        command.Parameters.AddWithValue("@CustomerID", dto.CustomerID);
                        command.Parameters.AddWithValue("@VehicleID", dto.VehicleID);
                        command.Parameters.AddWithValue("@RentedAt", dto.RentedAt);
                        command.Parameters.AddWithValue("@DueDate", dto.DueDate);
                        command.Parameters.AddWithValue("@PickUpLocation", dto.PickUpLocation);
                        command.Parameters.AddWithValue("@DropOffLocation", (object)dto.DropOffLocation ?? DBNull.Value);
                        command.Parameters.AddWithValue("@VehicleConditionNotes", (object)dto.VehicleConditionNotes ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Status", dto.Status);

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

        public static bool DeleteBooking(int bookingID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM VehicleBookRecords WHERE VehicleBookRecordID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", bookingID);

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
    //public class RentalBookingDTO
    //{
    //    public int RentalBookingID { get; set; }
    //    public int? PaymentID { get; set; }
    //    public int CustomerID { get; set; }
    //    public int VehicleID { get; set; }
    //    public DateTime RentedAt { get; set; }
    //    public DateTime DueDate { get; set; }
    //    public string PickUpLocation { get; set; }
    //    public string DropOffLocation { get; set; }
    //    public string VehicleConditionNotes { get; set; }
    //    public int Status { get; set; }

    //    public RentalBookingDTO() { }

    //    public RentalBookingDTO(int RentalBookingID, int? PaymentID, int CustomerID,
    //        int VehicleID, DateTime RentedAt, DateTime DueDate,
    //        string PickUpLocation, string DropOffLocation,
    //        string VehicleConditionNotes, int Status)
    //    {
    //        this.RentalBookingID = RentalBookingID;
    //        this.PaymentID = PaymentID;
    //        this.CustomerID = CustomerID;
    //        this.VehicleID = VehicleID;
    //        this.RentedAt = RentedAt;
    //        this.DueDate = DueDate;
    //        this.PickUpLocation = PickUpLocation;
    //        this.DropOffLocation = DropOffLocation;
    //        this.VehicleConditionNotes = VehicleConditionNotes;
    //        this.Status = Status;
    //    }
    //}
    //public class clsRentalBookingData
    //{
    //    public static RentalBookingDTO GetBookingByID(int bookingID)
    //    {
    //        try
    //        {
    //            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    //            {
    //                string query = "SELECT * FROM VehicleBookRecords WHERE VehicleBookRecordID = @ID";

    //                using (SqlCommand command = new SqlCommand(query, connection))
    //                {
    //                    command.Parameters.AddWithValue("@ID", bookingID);

    //                    connection.Open();

    //                    using (SqlDataReader reader = command.ExecuteReader())
    //                    {
    //                        if (reader.Read())
    //                        {
    //                            return new RentalBookingDTO
    //                            {
    //                                RentalBookingID = (int)reader["VehicleBookRecordID"],
    //                                PaymentID = reader["PaymentID"] as int?,
    //                                CustomerID = (int)reader["CustomerID"],
    //                                VehicleID = (int)reader["VehicleID"],
    //                                RentedAt = (DateTime)reader["RentedAt"],
    //                                DueDate = (DateTime)reader["DueDate"],
    //                                PickUpLocation = reader["PickUpLocation"].ToString(),
    //                                DropOffLocation = reader["DropOffLocation"].ToString(),
    //                                VehicleConditionNotes = reader["VehicleConditionNotes"].ToString(),
    //                                Status = (int)reader["Status"]
    //                            };
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            clsEventLogger.LogEvent(ex.Message);
    //        }

    //        return null;
    //    }
    //     public static RentalBookingDTO GetBookingByPaymentID(int paymentID)
    //    {
    //        try
    //        {
    //            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    //            {
    //                string query = "SELECT * FROM VehicleBookRecords WHERE PaymentID = @ID";

    //                using (SqlCommand command = new SqlCommand(query, connection))
    //                {
    //                    command.Parameters.AddWithValue("@ID", paymentID);

    //                    connection.Open();

    //                    using (SqlDataReader reader = command.ExecuteReader())
    //                    {
    //                        if (reader.Read())
    //                        {
    //                            return new RentalBookingDTO
    //                            {
    //                                RentalBookingID = (int)reader["VehicleBookRecordID"],
    //                                PaymentID = reader["PaymentID"] as int?,
    //                                CustomerID = (int)reader["CustomerID"],
    //                                VehicleID = (int)reader["VehicleID"],
    //                                RentedAt = (DateTime)reader["RentedAt"],
    //                                DueDate = (DateTime)reader["DueDate"],
    //                                PickUpLocation = reader["PickUpLocation"].ToString(),
    //                                DropOffLocation = reader["DropOffLocation"].ToString(),
    //                                VehicleConditionNotes = reader["VehicleConditionNotes"].ToString(),
    //                                Status = (int)reader["Status"]
    //                            };
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            clsEventLogger.LogEvent(ex.Message);
    //        }

    //        return null;
    //    }
    //    public static DataTable GetAllBookings()
    //    {
    //        DataTable dt = new DataTable();

    //        try
    //        {
    //            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    //            {
    //                string query = "select * from RentalBookingRecords_View ORDER BY RentedAt DESC";

    //                using (SqlCommand command = new SqlCommand(query, connection))
    //                {
    //                    connection.Open();

    //                    using (SqlDataReader reader = command.ExecuteReader())
    //                    {
    //                        dt.Load(reader);
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            clsEventLogger.LogEvent(ex.Message);
    //            return null;
    //        }

    //        return dt;
    //    }

    //    public static int AddBooking(RentalBookingDTO dto)
    //    {
    //        try
    //        {
    //            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    //            {
    //                string query = @"
    //            INSERT INTO VehicleBookRecords
    //            (PaymentID, CustomerID, VehicleID, RentedAt, DueDate,
    //             PickUpLocation, DropOffLocation, VehicleConditionNotes, Status)
    //            VALUES
    //            (@PaymentID, @CustomerID, @VehicleID, @RentedAt, @DueDate,
    //             @PickUpLocation, @DropOffLocation, @VehicleConditionNotes, @Status);
    //            SELECT SCOPE_IDENTITY();";

    //                using (SqlCommand command = new SqlCommand(query, connection))
    //                {
    //                    command.Parameters.AddWithValue("@PaymentID", (object)dto.PaymentID ?? DBNull.Value);
    //                    command.Parameters.AddWithValue("@CustomerID", dto.CustomerID);
    //                    command.Parameters.AddWithValue("@VehicleID", dto.VehicleID);
    //                    command.Parameters.AddWithValue("@RentedAt", dto.RentedAt);
    //                    command.Parameters.AddWithValue("@DueDate", dto.DueDate);
    //                    command.Parameters.AddWithValue("@PickUpLocation", dto.PickUpLocation);
    //                    command.Parameters.AddWithValue("@DropOffLocation", (object)dto.DropOffLocation ?? DBNull.Value);
    //                    command.Parameters.AddWithValue("@VehicleConditionNotes", (object)dto.VehicleConditionNotes ?? DBNull.Value);
    //                    command.Parameters.AddWithValue("@Status", dto.Status);

    //                    connection.Open();

    //                    object result = command.ExecuteScalar();

    //                    if (result != null && int.TryParse(result.ToString(), out int id))
    //                        return id;
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            clsEventLogger.LogEvent(ex.Message);
    //        }

    //        return -1;
    //    }

    //    public static bool UpdateBooking(RentalBookingDTO dto)
    //    {
    //        try
    //        {
    //            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    //            {
    //                string query = @"
    //            UPDATE VehicleBookRecords
    //            SET PaymentID = @PaymentID,
    //                CustomerID = @CustomerID,
    //                VehicleID = @VehicleID,
    //                RentedAt = @RentedAt,
    //                DueDate = @DueDate,
    //                PickUpLocation = @PickUpLocation,
    //                DropOffLocation = @DropOffLocation,
    //                VehicleConditionNotes = @VehicleConditionNotes,
    //                Status = @Status
    //            WHERE VehicleBookRecordID = @ID";

    //                using (SqlCommand command = new SqlCommand(query, connection))
    //                {
    //                    command.Parameters.AddWithValue("@ID", dto.RentalBookingID);
    //                    command.Parameters.AddWithValue("@PaymentID", (object)dto.PaymentID ?? DBNull.Value);
    //                    command.Parameters.AddWithValue("@CustomerID", dto.CustomerID);
    //                    command.Parameters.AddWithValue("@VehicleID", dto.VehicleID);
    //                    command.Parameters.AddWithValue("@RentedAt", dto.RentedAt);
    //                    command.Parameters.AddWithValue("@DueDate", dto.DueDate);
    //                    command.Parameters.AddWithValue("@PickUpLocation", dto.PickUpLocation);
    //                    command.Parameters.AddWithValue("@DropOffLocation", (object)dto.DropOffLocation ?? DBNull.Value);
    //                    command.Parameters.AddWithValue("@VehicleConditionNotes", (object)dto.VehicleConditionNotes ?? DBNull.Value);
    //                    command.Parameters.AddWithValue("@Status", dto.Status);

    //                    connection.Open();
    //                    return command.ExecuteNonQuery() > 0;
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            clsEventLogger.LogEvent(ex.Message);
    //        }

    //        return false;
    //    }

    //    public static bool DeleteBooking(int bookingID)
    //    {
    //        try
    //        {
    //            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    //            {
    //                string query = "DELETE FROM VehicleBookRecords WHERE VehicleBookRecordID = @ID";

    //                using (SqlCommand command = new SqlCommand(query, connection))
    //                {
    //                    command.Parameters.AddWithValue("@ID", bookingID);

    //                    connection.Open();
    //                    return command.ExecuteNonQuery() > 0;
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            clsEventLogger.LogEvent(ex.Message);
    //        }

    //        return false;
    //    }
    //}
}
