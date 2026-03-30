using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccessLayar
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public int PersonID { get; set; }
        public string DriverLicenseNumber { get; set; }
        public DateTime? LicenseIssueDate { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
        public int LicenseClass { get; set; }
        public DateTime CreatedAt{ get; set; }

        public int CreatedByUserID { get; set; }
    }
    public class clsCustomerData
    {
        public static CustomerDTO FindCustomerByCustomerID(int CustomerID)
        {
            CustomerDTO customerDTO = new CustomerDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "select * from Customers where CustomerID=@CustomerID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {

                        cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customerDTO.CustomerID = CustomerID;
                                customerDTO.PersonID = (int)reader["PersonID"];
                                customerDTO.DriverLicenseNumber = (string)reader["DriverLicenseNumber"];
                                customerDTO.LicenseIssueDate = reader["LicenseIssueDate"] != DBNull.Value ? (DateTime?)reader["LicenseIssueDate"] : null;
                                customerDTO.LicenseExpiryDate = (DateTime)reader["LicenseExpiryDate"];
                                customerDTO.LicenseClass = (int)reader["LicenseClass"];
                                customerDTO.CreatedAt = (DateTime)reader["CreatedAt"];
                                customerDTO.CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return null;
            }

            return customerDTO;
        }

        public static CustomerDTO FindCustomerByPersonID(int PersonID)
        {
            CustomerDTO customerDTO = null;

            string query = "select * from Customers where PersonID=@PersonID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PersonID", PersonID);

                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customerDTO = new CustomerDTO
                                {
                                    CustomerID = (int)reader["CustomerID"],
                                    PersonID = (int)reader["PersonID"],
                                    DriverLicenseNumber = (string)reader["DriverLicenseNumber"],
                                    LicenseIssueDate = reader["LicenseIssueDate"] != DBNull.Value ? (DateTime?)reader["LicenseIssueDate"] : null,
                                    LicenseExpiryDate = (DateTime)reader["LicenseExpiryDate"],
                                    LicenseClass = (int)reader["LicenseClass"],
                                    CreatedAt = (DateTime)reader["CreatedAt"],
                                    CreatedByUserID = (int)reader["CreatedByUserID"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return null;
            }

            return customerDTO;
        }

        public static bool IsCustomerExists(int CustomerID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "select 1 from Customers where CustomerID=@CustomerID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                        connection.Open();

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                            isFound = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return false;
            }

            return isFound;
        }

        public static bool IsCustomerExistsForPersonID(int PersonID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "select 1 from Customers where PersonID=@PersonID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PersonID", PersonID);

                        connection.Open();

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                            isFound = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return false;
            }

            return isFound;
        }

        public static DataTable GetCustomersList()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT Customers.CustomerID, Customers.PersonID,
                                People.NationalNo,
                                People.FirstName + ' ' + People.SecondName + ' ' + 
                                ISNULL('',People.ThirdName) + ' ' + People.LastName as FullName,
                                Customers.DriverLicenseNumber,Customers.LicenseClass,Customers.LicenseExpiryDate,
                                Customers.LicenseIssueDate
                                FROM Customers 
                                INNER JOIN People ON Customers.PersonID = People.PersonID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
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

        public static int AddNewCustomer(CustomerDTO customerDTO)
        {
            string query = @"INSERT INTO Customers
                (PersonID, DriverLicenseNumber, LicenseIssueDate, LicenseExpiryDate, LicenseClass, CreatedAt, CreatedByUserID)
                VALUES
                (@PersonID, @DriverLicenseNumber, @LicenseIssueDate, @LicenseExpiryDate, @LicenseClass, @CreatedAt, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PersonID", customerDTO.PersonID);
                        cmd.Parameters.AddWithValue("@DriverLicenseNumber", customerDTO.DriverLicenseNumber);
                        cmd.Parameters.AddWithValue("@LicenseIssueDate", (object)customerDTO.LicenseIssueDate ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@LicenseExpiryDate", customerDTO.LicenseExpiryDate);
                        cmd.Parameters.AddWithValue("@LicenseClass", customerDTO.LicenseClass);
                        cmd.Parameters.AddWithValue("@CreatedAt", customerDTO.CreatedAt);
                        cmd.Parameters.AddWithValue("@CreatedByUserID", customerDTO.CreatedByUserID);

                        connection.Open();

                        object result = cmd.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            customerDTO.CustomerID = insertedID;
                            return insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return -1;
            }

            return -1;
        }

        public static bool UpdateCustomer(CustomerDTO customerDTO)
        {
            string query = @"UPDATE Customers SET
                PersonID=@PersonID,
                DriverLicenseNumber=@DriverLicenseNumber,
                LicenseIssueDate=@LicenseIssueDate,
                LicenseExpiryDate=@LicenseExpiryDate,
                LicenseClass=@LicenseClass
                WHERE CustomerID=@CustomerID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerDTO.CustomerID);
                        cmd.Parameters.AddWithValue("@PersonID", customerDTO.PersonID);
                        cmd.Parameters.AddWithValue("@DriverLicenseNumber", customerDTO.DriverLicenseNumber);
                        cmd.Parameters.AddWithValue("@LicenseIssueDate", (object)customerDTO.LicenseIssueDate ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@LicenseExpiryDate", customerDTO.LicenseExpiryDate);
                        cmd.Parameters.AddWithValue("@LicenseClass", customerDTO.LicenseClass);

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

        public static bool DeleteCustomer(int CustomerID)
        {
            string query = "delete from Customers where CustomerID=@CustomerID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

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
