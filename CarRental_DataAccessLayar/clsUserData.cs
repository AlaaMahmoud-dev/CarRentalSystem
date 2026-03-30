using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccessLayar
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PersonID { get; set; }

        public bool IsActive { get; set; }
        public UserDTO()
        {
        }
        public UserDTO(int UserID, int PersonID, string Username, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
        }

    }
    public  class clsUserData
    {
        public static UserDTO FindUserByUserID(int UserID)
        {

            UserDTO userDTO =null;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Users Where UserID=@UserID";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("UserID", UserID);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    userDTO = new UserDTO();
                    userDTO.UserID = UserID;
                    userDTO.PersonID = (int)reader["PersonID"];
                    userDTO.Username = (string)reader["Username"];
                    userDTO.Password = (string)reader["PasswordHash"];
                    userDTO.IsActive = (bool)reader["IsActive"];

                   
                }
                reader.Close();




            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return null;
            }
            finally { connection.Close(); }

            return userDTO;

        }
        
        public static UserDTO FindUserByUserNameAndPassword(string Username, string Password)
        {

            UserDTO userDTO = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = "select * from Users Where Username=@Username and PasswordHash = @Password";

                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {

                        sqlCommand.Parameters.AddWithValue("Username", Username);
                        sqlCommand.Parameters.AddWithValue("Password", Password);

                        connection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                userDTO= new UserDTO();
                                userDTO.Username = Username;
                                userDTO.PersonID = (int)reader["PersonID"];
                                userDTO.UserID = (int)reader["UserID"];
                                userDTO.Password = (string)reader["PasswordHash"];
                                userDTO.IsActive = (bool)reader["IsActive"];

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
            
            return userDTO;

        }
        public static UserDTO FindUserByUserName(string Username)
        {

            UserDTO userDTO = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = "select * from Users Where Username=@Username";

                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {

                        sqlCommand.Parameters.AddWithValue("Username", Username);

                        connection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                userDTO = new UserDTO();
                                userDTO.Username = Username;
                                userDTO.PersonID = (int)reader["PersonID"];
                                userDTO.UserID = (int)reader["UserID"];
                                userDTO.Password = (string)reader["PasswordHash"];
                                userDTO.IsActive = (bool)reader["IsActive"];

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

            return userDTO;

        }

        public static UserDTO FindUserByPersonID(int PersonID)
        {
            UserDTO userDTO = null;

            string query = "SELECT * FROM Users WHERE PersonID = @PersonID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);

                        connection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userDTO = new UserDTO
                                {
                                    PersonID = PersonID,
                                    Username = (string)reader["Username"],
                                    UserID = (int)reader["UserID"],
                                    Password = (string)reader["PasswordHash"],
                                    IsActive = (bool)reader["IsActive"]
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

            return userDTO;
        }
        public static bool IsUserExists(int UserID)
        {

            bool isFound = false;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {


                    string query = "select Found=1 from Users Where UserID=@UserID";

                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.AddWithValue("UserID", UserID);

                        connection.Open();

                        object Result = sqlCommand.ExecuteScalar();

                        if (Result != null)
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
        public static bool IsUserExists(string UserName)
        {

            bool isFound = false;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "select Found=1 from Users Where UserName=@UserName";

                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.AddWithValue("UserName", UserName);



                        connection.Open();

                        object Result = sqlCommand.ExecuteScalar();

                        if (Result != null)
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

        public static bool IsUserExistsForPersonID(int PersonID)
        {

            bool isFound = false;


            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "select Found=1 from Users Where PersonID=@PersonID";

                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {

                        sqlCommand.Parameters.AddWithValue("PersonID", PersonID);


                        connection.Open();

                        object Result = sqlCommand.ExecuteScalar();

                        if (Result != null)
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

        public static DataTable GetUsersList()
        {

            DataTable dt = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"SELECT  Users.UserID,  Users.PersonID, People.FirstName 
                            + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' 
                            + People.LastName as FullName
                          , Users.UserName, Users.IsActive 
                            from People INNER JOIN
                            Users ON People.PersonID = Users.PersonID";



                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {

                        connection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                dt.Load(reader);
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
            return dt;
        }

        public static int AddNewUser(UserDTO userDTO)
        {
            string query = @"INSERT INTO Users (PersonID, Username, PasswordHash, IsActive)
                     VALUES (@PersonID, @Username, @Password, @IsActive);
                     SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", userDTO.PersonID);
                        command.Parameters.AddWithValue("@Username", userDTO.Username);
                        command.Parameters.AddWithValue("@Password", userDTO.Password);
                        command.Parameters.AddWithValue("@IsActive", userDTO.IsActive);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            userDTO.UserID = insertedID;
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

        public static bool UpdateUser(UserDTO userDTO)
        {
            string query = @"UPDATE Users 
                     SET PersonID = @PersonID, 
                         Username = @Username,
                         PasswordHash = @Password,
                         IsActive = @IsActive
                     WHERE UserID = @UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userDTO.UserID);
                        command.Parameters.AddWithValue("@PersonID", userDTO.PersonID);
                        command.Parameters.AddWithValue("@Username", userDTO.Username);
                        command.Parameters.AddWithValue("@Password", userDTO.Password);
                        command.Parameters.AddWithValue("@IsActive", userDTO.IsActive);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return false;
            }
        }
        public static bool ChangePassword(string userName, string newPassword)
        {
            string query = @"UPDATE Users 
                     SET PasswordHash = @NewPassword
                     WHERE UserName = @UserName";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@NewPassword", newPassword);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return false;
            }
        }
        public static bool DeleteUser(int userID)
        {
            string query = "DELETE FROM Users WHERE UserID = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", userID);

                        connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
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
