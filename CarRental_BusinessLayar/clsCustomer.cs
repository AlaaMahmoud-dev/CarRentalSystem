using CarRental_DataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_BusinessLayar
{
    public class clsCustomer
    {
        public CustomerDTO CDTO
        {
            get
            {
                return new CustomerDTO
                {
                    CustomerID = this.CustomerID,
                    PersonID = this.PersonID,
                    DriverLicenseNumber = this.DriverLicenseNumber,
                    LicenseIssueDate = this.LicenseIssueDate,
                    LicenseExpiryDate = this.LicenseExpiryDate,
                    LicenseClass = this.LicenseClass,
                    CreatedAt = this.CreatedAt,
                    CreatedByUserID = this.CreatedByUserID
                };
            }
        }

        public int CustomerID { set; get; }
        public int PersonID { set; get; }
        public string DriverLicenseNumber { set; get; }
        public DateTime? LicenseIssueDate { set; get; }
        public DateTime LicenseExpiryDate { set; get; }
        public int LicenseClass { set; get; }
        public DateTime CreatedAt { set; get; }
        public int CreatedByUserID { set; get; }
        public clsUser CreatedByUserInfo { set; get; }
        public clsPerson PersonInfo { set; get; }

        public string LicenseClassName { 
            get
            {
                return clsLicenseClass.GetLicenseClassName((clsLicenseClass.enLicenseClass)this.LicenseClass);
            } 
        }
         enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode _Mode = enMode.AddNew;

        public clsCustomer()
        {
            CustomerID = -1;
            PersonID = -1;
            DriverLicenseNumber = "";
            LicenseIssueDate = null;
            LicenseExpiryDate = DateTime.Now;
            LicenseClass = 0;
            CreatedAt = DateTime.Now;
            CreatedByUserID = -1;

            PersonInfo = new clsPerson();
            CreatedByUserInfo = new clsUser();

            _Mode = enMode.AddNew;
        }

        private clsCustomer(CustomerDTO cDTO)
        {
            this.CustomerID = cDTO.CustomerID;
            this.PersonID = cDTO.PersonID;
            this.DriverLicenseNumber = cDTO.DriverLicenseNumber;
            this.LicenseIssueDate = cDTO.LicenseIssueDate;
            this.LicenseExpiryDate = cDTO.LicenseExpiryDate;
            this.LicenseClass = cDTO.LicenseClass;
            this.CreatedAt = cDTO.CreatedAt;
            this.CreatedByUserID = cDTO.CreatedByUserID;

            PersonInfo = clsPerson.FindPersonByID(PersonID);
            CreatedByUserInfo = clsUser.FindUserByUserID(CreatedByUserID);

            _Mode = enMode.Update;
        }

        public static clsCustomer FindCustomerByCustomerID(int CustomerID)
        {
            CustomerDTO dto = clsCustomerData.FindCustomerByCustomerID(CustomerID);

            if (dto != null)
            {
                return new clsCustomer(dto);
            }
            else { return null; }
        }

        public static clsCustomer FindCustomerByPersonID(int PersonID)
        {
            CustomerDTO dto = clsCustomerData.FindCustomerByPersonID(PersonID);

            if (dto != null)
            {
                return new clsCustomer(dto);
            }
            else { return null; }
        }

        public static bool IsCustomerExists(int CustomerID)
        {
            return clsCustomerData.IsCustomerExists(CustomerID);
        }

        public static bool IsCustomerExistsForPersonID(int PersonID)
        {
            return clsCustomerData.IsCustomerExistsForPersonID(PersonID);
        }

        public static DataTable CustomersList()
        {
            return clsCustomerData.GetCustomersList();
        }

        bool _AddNew()
        {
            this.CustomerID = clsCustomerData.AddNewCustomer(CDTO);

            return this.CustomerID != -1;
        }

        bool _Update()
        {
            return clsCustomerData.UpdateCustomer(CDTO);
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

        public static bool DeleteCustomer(int CustomerID)
        {
            if (clsCustomerData.DeleteCustomer(CustomerID))
            {
                return true;
            }
            return false;
        }
    }
}
