using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccessLayar
{
    public class PersonDTO
    {
        public PersonDTO()
        {

        }
        public PersonDTO(int PersonID, string NationalNo, 
            string FirstName,string SecondName,
            string ThirdName,string LastName,
            DateTime DateOfBirth,byte Gendor,
            string Phone,string Email)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Email = Email;
            this.Phone = Phone;
        }
        public int PersonID { get; set; } = -1;


        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte Gendor { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }


    }
    public class clsPersonData
    {



        public static DataTable GetPeopleList()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"SELECT People.PersonID, People.NationalNo,
                             People.FirstName, People.SecondName, People.ThirdName, People.LastName,
                             People.DateOfBirth, People.Gendor,
                             case when People.Gendor= 0 then 'Male' else 'Femail'
                             end as GendorCaption, People.Phone, People.Email
                             FROM People
";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return null;

            }
            finally { connection.Close(); }
            return dt;
        }



        public static PersonDTO FindPersonByID(int ID)
        {

            PersonDTO PDTO = null ;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from People Where PersonID=@PersonID";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("PersonID", ID);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    PDTO = new PersonDTO();
                    PDTO.PersonID = ID;
                    PDTO.FirstName = (string)reader["FirstName"];
                    PDTO.SecondName = (string)reader["SecondName"];
                    PDTO.ThirdName = (string)reader["ThirdName"];
                    PDTO.LastName = (string)reader["LastName"];
                    PDTO.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    PDTO.NationalNo = (string)reader["NationalNo"];
                    PDTO.Gendor = (byte)reader["Gendor"];

                    PDTO.Phone = (string)reader["Phone"];
                    PDTO.Email = (string)reader["Email"];

                }
                reader.Close();




            }
            catch (Exception ex)
            {

                clsEventLogger.LogEvent(ex.Message);
                return null;

            }
            finally { connection.Close(); }

            return PDTO;

        }


        public static PersonDTO FindPersonByNationalNo(string NationalNo)
        {

            PersonDTO PDTO = null;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from People Where NationalNo=@NationalNo";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("NationalNo", NationalNo);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    PDTO = new PersonDTO();
                    PDTO.NationalNo = NationalNo;
                    PDTO.FirstName = (string)reader["FirstName"];
                    PDTO.SecondName = (string)reader["SecondName"];
                    PDTO.ThirdName = (string)reader["ThirdName"];
                    PDTO.LastName = (string)reader["LastName"];
                    PDTO.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    PDTO.PersonID = (int)reader["PersonID"];
                    PDTO.Gendor = (byte)reader["Gendor"];

                    PDTO.Phone = (string)reader["Phone"];
                    PDTO.Email = (string)reader["Email"];



                }
                reader.Close();




            }
            catch (Exception ex)
            {

                clsEventLogger.LogEvent(ex.Message);

                return null;

            }
            finally { connection.Close(); }

            return PDTO;

        }

        public static int AddNewPerson(PersonDTO PDTO)
        {

            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into People (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Email,Phone)
                           Values(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Email,@Phone);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("NationalNo", PDTO.NationalNo);
            command.Parameters.AddWithValue("FirstName", PDTO.FirstName);
            command.Parameters.AddWithValue("SecondName", PDTO.SecondName);
            command.Parameters.AddWithValue("ThirdName", PDTO.ThirdName);
            command.Parameters.AddWithValue("LastName", PDTO.LastName);
            command.Parameters.AddWithValue("DateOfBirth", PDTO.DateOfBirth);
            command.Parameters.AddWithValue("Phone", PDTO.Phone);
            command.Parameters.AddWithValue("Email", PDTO.Email);
            command.Parameters.AddWithValue("Gendor", PDTO.Gendor);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }

            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return PersonID;

        }



        public static bool UpdatePerson(PersonDTO PDTO)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update People 
                           set NationalNo=@NationalNo, 
                           FirstName=@FirstName,
                           SecondName=@SecondName,
                           ThirdName=@ThirdName,
                           LastName=@LastName,
                           Gendor=@Gendor,
                           Email=@Email,
                           Phone=@Phone,
                           DateOfBirth=@DateOfBirth
                           where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PersonID", PDTO.PersonID);
            command.Parameters.AddWithValue("NationalNo", PDTO.NationalNo);
            command.Parameters.AddWithValue("FirstName", PDTO.FirstName);
            command.Parameters.AddWithValue("SecondName", PDTO.SecondName);
            command.Parameters.AddWithValue("ThirdName", PDTO.ThirdName);
            command.Parameters.AddWithValue("LastName", PDTO.LastName);
            command.Parameters.AddWithValue("DateOfBirth", PDTO.DateOfBirth);

            command.Parameters.AddWithValue("Phone", PDTO.Phone);
            command.Parameters.AddWithValue("Email", PDTO.Email);
            command.Parameters.AddWithValue("Gendor", PDTO.Gendor);
            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return RowsAffected > 0;
        }

       
        public static bool IsPersonExistsByPersonID(int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = "select found=1 from People where PersonID=@ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ID", PersonID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
                }


            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return false;
            }
            finally { connection.Close(); }


            return IsFound;






        }
        public static bool IsPersonExistsByNationalNo(string NationalNo)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = "select found=1 from People where NationalNo=@NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("NationalNo", NationalNo);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
                }


            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return false;
            }
            finally { connection.Close(); }


            return IsFound;






        }

        public static bool DeletePerson(int PersonID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from People where PersonID=@ID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("ID", PersonID);

            try
            {
                connection.Open();

                RowsAffected = cmd.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                clsEventLogger.LogEvent(ex.Message);
                return false;
            }
            finally { connection.Close(); }


            return RowsAffected > 0;


        }


      
    }
}
