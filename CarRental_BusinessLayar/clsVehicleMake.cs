using CarRental_DataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_BusinessLayar
{
    public class clsVehicleMake
    {
        public VehicleMakeDTO VMDTO
        {
            get
            {
                return new VehicleMakeDTO(this.MakeID, this.MakeName);
            }
        }

        public int MakeID { get; set; }
        public string MakeName { get; set; }

        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode _Mode = enMode.Update;

        public clsVehicleMake()
        {
            MakeID = -1;
            MakeName = "";
            _Mode = enMode.AddNew;
        }

        private clsVehicleMake(int MakeID, string MakeName)
        {
            this.MakeID = MakeID;
            this.MakeName = MakeName;
            _Mode = enMode.Update;
        }

        public static clsVehicleMake FindVehicleMakeByID(int makeID)
        {
            VehicleMakeDTO dto = clsVehicleMakeData.GetVehicleMakeByID(makeID);

            if (dto == null)
                return null;

            return new clsVehicleMake(dto.MakeID, dto.MakeName);
        }

        public static clsVehicleMake FindVehicleMakeByName(string makeName)
        {
            VehicleMakeDTO dto = clsVehicleMakeData.GetVehicleMakeByName(makeName);

            if (dto == null)
                return null;

            return new clsVehicleMake(dto.MakeID, dto.MakeName);
        }

        public static DataTable GetAllVehicleMakes()
        {
            return clsVehicleMakeData.GetAllVehicleMakes();
        }

        bool _Update()
        {
            return clsVehicleMakeData.UpdateVehicleMake(VMDTO);
        }

        bool _AddNew()
        {
            this.MakeID = clsVehicleMakeData.AddVehicleMake(VMDTO);
            return MakeID != -1;
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
                        return false;

                case enMode.Update:
                    return _Update();
            }

            return false;
        }
    }
}
