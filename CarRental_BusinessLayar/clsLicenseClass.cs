using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental_DataAccessLayar;
namespace CarRental_BusinessLayar
{
    public class clsLicenseClass
    {
        public LicenseClassDTO LCDTO { get
            {
                return new LicenseClassDTO(this.LicenseClassID, this.ClassName,this.ClassDescription);
            }
        }
        public int LicenseClassID { get; set; }

        public string ClassName { get; set; }

        public string ClassDescription { get; set; }


        public enum enLicenseClass
        {
            SmallMotorcycle = 1,
            HeavyMotorcycleLicense,
            OrdinaryDrivingLicense,
            Commercial,
            Agricultural,
            SmallAndMediumBus,
            TruckAndHeavyVehicle,

        }
        public static string GetLicenseClassName(enLicenseClass licenseClass)
        {
            switch (licenseClass)
            {
                case enLicenseClass.SmallMotorcycle:
                    return "Class 1 - Small Motorcycle";
                case enLicenseClass.HeavyMotorcycleLicense:
                    return "Class 2 - Heavy Motorcycle License";
                case enLicenseClass.OrdinaryDrivingLicense:
                    return "Class 3 - Ordinary driving license";
                case enLicenseClass.Commercial:
                    return "Class 4 - Commercial";
                case enLicenseClass.Agricultural:
                    return "Class 5 - Agricultural";
                case enLicenseClass.SmallAndMediumBus:
                    return "Class 6 - Small and medium bus";
                default:
                    return "Class 7 - Truck and heavy vehicle";
            }





        }
        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode _Mode = enMode.Update;



        public clsLicenseClass()
        {
            LicenseClassID = -1;
            ClassName = "";
            ClassDescription = "";
         
            _Mode = enMode.AddNew;

        }

        private clsLicenseClass(int LicenseClassID, string ClassName,
            string ClassDescription)
        {
            this.LicenseClassID = LicenseClassID;
           
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            _Mode = enMode.Update;

        }

        public static clsLicenseClass FindLicenseClassByID(int licenseClassID)
        {
            LicenseClassDTO dto = clsLicenseClassData.GetLicenseClassByID(licenseClassID);

            if (dto == null)
                return null;

            return new clsLicenseClass(dto.LicesneClassID, dto.ClassName, dto.Description);
        }
        public static clsLicenseClass FindLicenseClassByClassName(string className)
        {
            LicenseClassDTO dto = clsLicenseClassData.GetLicenseClassByName(className);

            if (dto == null)
                return null;

            return new clsLicenseClass(dto.LicesneClassID, dto.ClassName, dto.Description);
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }

      
        bool _Update()
        {
            return clsLicenseClassData.UpdateLicenseClass(LCDTO);
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


        bool _AddNew()
        {
            this.LicenseClassID =
                clsLicenseClassData.AddLicenseClass(LCDTO);

            return LicenseClassID != -1;
        }
    }
}
