using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccessLayar
{
    public class PaymentDTO
    {
        public int PaymentID { get; set; }
        public int VehicleBookRecordID { get; set; } 

        public decimal InitialPaidAmount { get; set; }
        public decimal? TotalActualDueAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime? UpdatedPaymentDate { get; set; }

        public PaymentDTO() { }

        public PaymentDTO(int PaymentID, int VehicleBookRecordID,
            decimal InitialPaidAmount, decimal? TotalActualDueAmount,
            DateTime PaymentDate, DateTime? UpdatedPaymentDate)
        {
            this.PaymentID = PaymentID;
            this.VehicleBookRecordID = VehicleBookRecordID;
            this.InitialPaidAmount = InitialPaidAmount;
            this.TotalActualDueAmount = TotalActualDueAmount;
            this.PaymentDate = PaymentDate;
            this.UpdatedPaymentDate = UpdatedPaymentDate;
        }
    }
    public class clsPaymentData
    {
        public static PaymentDTO GetPaymentByID(int paymentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Payments WHERE PaymentID = @PaymentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", paymentID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new PaymentDTO
                                {
                                    PaymentID = (int)reader["PaymentID"],
                                    VehicleBookRecordID = (int)reader["VehicleBookRecordID"],
                                    InitialPaidAmount = (decimal)reader["InitialPaidAmount"],
                                    TotalActualDueAmount = reader["TotalActualDueAmount"] as decimal?,
                                    PaymentDate = (DateTime)reader["PaymentDate"],
                                    UpdatedPaymentDate = reader["UpdatedPaymentDate"] as DateTime?
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

        public static PaymentDTO GetPaymentByBookingID(int bookingID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Payments WHERE VehicleBookRecordID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", bookingID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new PaymentDTO
                                {
                                    PaymentID = (int)reader["PaymentID"],
                                    VehicleBookRecordID = (int)reader["VehicleBookRecordID"],
                                    InitialPaidAmount = (decimal)reader["InitialPaidAmount"],
                                    TotalActualDueAmount = reader["TotalActualDueAmount"] as decimal?,
                                    PaymentDate = (DateTime)reader["PaymentDate"],
                                    UpdatedPaymentDate = reader["UpdatedPaymentDate"] as DateTime?
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

        public static DataTable GetAllPayments()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Payments ORDER BY PaymentDate DESC";

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

        public static int AddPayment(PaymentDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"Update VehicleBookRecords set Status=2;
                INSERT INTO Payments
                (VehicleBookRecordID, InitialPaidAmount, TotalActualDueAmount, PaymentDate, UpdatedPaymentDate)
                VALUES
                (@VehicleBookRecordID, @InitialPaidAmount, @TotalActualDueAmount, @PaymentDate, @UpdatedPaymentDate);
                SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VehicleBookRecordID", dto.VehicleBookRecordID);
                        command.Parameters.AddWithValue("@InitialPaidAmount", dto.InitialPaidAmount);
                        command.Parameters.AddWithValue("@TotalActualDueAmount", (object)dto.TotalActualDueAmount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentDate", dto.PaymentDate);
                        command.Parameters.AddWithValue("@UpdatedPaymentDate", (object)dto.UpdatedPaymentDate ?? DBNull.Value);

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

        public static bool UpdatePayment(PaymentDTO dto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                UPDATE Payments
                SET VehicleBookRecordID = @VehicleBookRecordID,
                    InitialPaidAmount = @InitialPaidAmount,
                    TotalActualDueAmount = @TotalActualDueAmount,
                    PaymentDate = @PaymentDate,
                    UpdatedPaymentDate = @UpdatedPaymentDate
                WHERE PaymentID = @PaymentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", dto.PaymentID);
                        command.Parameters.AddWithValue("@VehicleBookRecordID", dto.VehicleBookRecordID);
                        command.Parameters.AddWithValue("@InitialPaidAmount", dto.InitialPaidAmount);
                        command.Parameters.AddWithValue("@TotalActualDueAmount", (object)dto.TotalActualDueAmount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentDate", dto.PaymentDate);
                        command.Parameters.AddWithValue("@UpdatedPaymentDate", (object)dto.UpdatedPaymentDate ?? DBNull.Value);

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

        public static bool DeletePayment(int paymentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM Payments WHERE PaymentID = @PaymentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", paymentID);

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
    //public class PaymentDTO
    //{
    //    public int PaymentID { get; set; }
    //    public decimal InitialPaidAmount { get; set; }
    //    public decimal? TotalActualDueAmount { get; set; }
    //    public DateTime PaymentDate { get; set; }
    //    public DateTime? UpdatedPaymentDate { get; set; }

    //    public PaymentDTO() { }

    //    public PaymentDTO(int PaymentID, decimal InitialPaidAmount,
    //        decimal? TotalActualDueAmount, DateTime PaymentDate, DateTime? UpdatedPaymentDate)
    //    {
    //        this.PaymentID = PaymentID;
    //        this.InitialPaidAmount = InitialPaidAmount;
    //        this.TotalActualDueAmount = TotalActualDueAmount;
    //        this.PaymentDate = PaymentDate;
    //        this.UpdatedPaymentDate = UpdatedPaymentDate;
    //    }
    //}
    //public class clsPaymentData
    //{
    //    public static PaymentDTO GetPaymentByID(int paymentID)
    //    {
    //        try
    //        {
    //            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    //            {
    //                string query = "SELECT * FROM Payments WHERE PaymentID = @PaymentID";

    //                using (SqlCommand command = new SqlCommand(query, connection))
    //                {
    //                    command.Parameters.AddWithValue("@PaymentID", paymentID);

    //                    connection.Open();

    //                    using (SqlDataReader reader = command.ExecuteReader())
    //                    {
    //                        if (reader.Read())
    //                        {
    //                            return new PaymentDTO
    //                            {
    //                                PaymentID = (int)reader["PaymentID"],
    //                                InitialPaidAmount = (decimal)reader["InitialPaidAmount"],
    //                                TotalActualDueAmount = reader["TotalActualDueAmount"] as decimal?,
    //                                PaymentDate = (DateTime)reader["PaymentDate"],
    //                                UpdatedPaymentDate = reader["UpdatedPaymentDate"] as DateTime?
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

    //    public static DataTable GetAllPayments()
    //    {
    //        DataTable dt = new DataTable();

    //        try
    //        {
    //            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    //            {
    //                string query = "SELECT * FROM Payments ORDER BY PaymentDate DESC";

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

    //    public static int AddPayment(PaymentDTO dto)
    //    {
    //        try
    //        {
    //            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    //            {
    //                string query = @" 
    //            INSERT INTO Payments (InitialPaidAmount, TotalActualDueAmount, PaymentDate, UpdatedPaymentDate)
    //            VALUES (@InitialPaidAmount, @TotalActualDueAmount, @PaymentDate, @UpdatedPaymentDate);
    //            SELECT SCOPE_IDENTITY();";

    //                using (SqlCommand command = new SqlCommand(query, connection))
    //                {
    //                    command.Parameters.AddWithValue("@InitialPaidAmount", dto.InitialPaidAmount);
    //                    command.Parameters.AddWithValue("@TotalActualDueAmount", (object)dto.TotalActualDueAmount ?? DBNull.Value);
    //                    command.Parameters.AddWithValue("@PaymentDate", dto.PaymentDate);
    //                    command.Parameters.AddWithValue("@UpdatedPaymentDate", (object)dto.UpdatedPaymentDate ?? DBNull.Value);

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

    //    public static bool UpdatePayment(PaymentDTO dto)
    //    {
    //        try
    //        {
    //            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    //            {
    //                string query = @"
    //            UPDATE Payments
    //            SET InitialPaidAmount = @InitialPaidAmount,
    //                TotalActualDueAmount = @TotalActualDueAmount,
    //                PaymentDate = @PaymentDate,
    //                UpdatedPaymentDate = @UpdatedPaymentDate
    //            WHERE PaymentID = @PaymentID";

    //                using (SqlCommand command = new SqlCommand(query, connection))
    //                {
    //                    command.Parameters.AddWithValue("@PaymentID", dto.PaymentID);
    //                    command.Parameters.AddWithValue("@InitialPaidAmount", dto.InitialPaidAmount);
    //                    command.Parameters.AddWithValue("@TotalActualDueAmount", (object)dto.TotalActualDueAmount ?? DBNull.Value);
    //                    command.Parameters.AddWithValue("@PaymentDate", dto.PaymentDate);
    //                    command.Parameters.AddWithValue("@UpdatedPaymentDate", (object)dto.UpdatedPaymentDate ?? DBNull.Value);

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

    //    public static bool DeletePayment(int paymentID)
    //    {
    //        try
    //        {
    //            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    //            {
    //                string query = "DELETE FROM Payments WHERE PaymentID = @PaymentID";

    //                using (SqlCommand command = new SqlCommand(query, connection))
    //                {
    //                    command.Parameters.AddWithValue("@PaymentID", paymentID);

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
