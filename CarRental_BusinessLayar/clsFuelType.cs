using CarRental_DataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_BusinessLayar
{
    public class clsFuelType
    {
        public FuelTypeDTO FDTO
        {
            get
            {
                return new FuelTypeDTO(this.FuelTypeID, this.FuelTypeName);
            }
        }

        public int FuelTypeID { get; set; }
        public string FuelTypeName { get; set; }

        enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.Update;

        public clsFuelType()
        {
            FuelTypeID = -1;
            FuelTypeName = "";
            _Mode = enMode.AddNew;
        }

        private clsFuelType(int id, string name)
        {
            FuelTypeID = id;
            FuelTypeName = name;
            _Mode = enMode.Update;
        }

        public static clsFuelType FindFuelTypeByID(int id)
        {
            var dto = clsFuelTypeData.GetFuelTypeByID(id);
            if (dto == null) return null;

            return new clsFuelType(dto.FuelTypeID, dto.FuelTypeName);
        }
        public static clsFuelType FindFuelTypeByName(string name)
        {
            var dto = clsFuelTypeData.GetFuelTypeByName(name);
            if (dto == null) return null;

            return new clsFuelType(dto.FuelTypeID, dto.FuelTypeName);
        }
        public static DataTable GetAllFuelTypes()
        {
            return clsFuelTypeData.GetAllFuelTypes();
        }

        bool _AddNew()
        {
            FuelTypeID = clsFuelTypeData.AddFuelType(FDTO);
            return FuelTypeID != -1;
        }

        bool _Update()
        {
            return clsFuelTypeData.UpdateFuelType(FDTO);
        }

        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                if (_AddNew())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                return false;
            }
            return _Update();
        }
    }
}
