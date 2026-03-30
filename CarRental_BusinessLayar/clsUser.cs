using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental_DataAccessLayar;
namespace CarRental_BusinessLayar
{
    public class clsUser
    {
        public UserDTO UDTO {
            get
            {
                return new UserDTO(this.UserID,
                    this.PersonID, this.Username,
                    this.Password, this.IsActive);
            }
        }
        public int UserID { set; get; }
        public int PersonID { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }

        public clsPerson PersonInfo { set; get; }
        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode _Mode = enMode.Update;
        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            Username = "";
            Password = "";
            IsActive = false;
            PersonInfo = new clsPerson();
            _Mode = enMode.AddNew;

        }

        private clsUser(UserDTO cUserDTO, enMode cMode = enMode.AddNew)
        {
            this.UserID = cUserDTO.UserID;
            this.PersonID = cUserDTO.PersonID;
            this.Username = cUserDTO.Username;
            this.Password = cUserDTO.Password;
            this.IsActive = cUserDTO.IsActive;
            PersonInfo = clsPerson.FindPersonByID(PersonID);

            _Mode = cMode;

        }

        public static clsUser FindUserByUserID(int UserID)
        {

           
            UserDTO userDTO = clsUserData.FindUserByUserID(UserID);

            if (userDTO != null)
            {
                return new clsUser(userDTO, enMode.Update);
            }
            else { return null; }
        }

        public static clsUser FindUserByUserName(string UserName)
        {

            UserDTO userDTO = clsUserData.FindUserByUserName(UserName);
            if (userDTO != null)
            {
                return new clsUser(userDTO, enMode.Update);
            }
            else { return null; }
        }

        public static clsUser FindUserByUserNameAndPassword(string UserName, string Password)
        {

            UserDTO userDTO = clsUserData.FindUserByUserNameAndPassword(UserName, Password);
            if (userDTO != null)
            {
                return new clsUser(userDTO, enMode.Update);
            }
            else { return null; }
        }


        public static clsUser FindUserByPersonID(int PersonID)
        {

            UserDTO userDTO = clsUserData.FindUserByPersonID(PersonID);

            if (userDTO != null)
            {
                return new clsUser(userDTO, enMode.Update);
            }
            else { return null; }
        }

        public static bool IsUserExists(int UserID)
        {


            return clsUserData.IsUserExists(UserID);


        }
        public static bool IsUserExists(string UserName)
        {


            return clsUserData.IsUserExists(UserName);


        }
        public static bool IsUserExistsForPersonID(int PersonID)
        {


            return clsUserData.IsUserExistsForPersonID(PersonID);


        }


        public static DataTable UsersList()
        {

            return clsUserData.GetUsersList();
        }



        bool _AddNew()
        {
            this.UserID = clsUserData.AddNewUser(UDTO);

            return this.UserID != -1;


        }
        bool _Update()
        {
            return clsUserData.UpdateUser(UDTO);
        }

        public bool ChangePassword(string NewPassword)
        {
            return clsUserData.ChangePassword(this.Username, NewPassword);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _Update();


            }
            return false;
        }

        public static bool DeleteUser(int UserID)
        {
            if (clsUserData.DeleteUser(UserID))
            {
                return true;
            }
            return false;

        }
    }
}
