using CarRental_DataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_BusinessLayar
{
    public class clsVehicleCategory
    {
        public VehicleCategoryDTO VCDTO
        {
            get
            {
                return new VehicleCategoryDTO(this.CategoryID, this.CategoryName);
            }
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode _Mode = enMode.Update;

        public clsVehicleCategory()
        {
            CategoryID = -1;
            CategoryName = "";
            _Mode = enMode.AddNew;
        }

        private clsVehicleCategory(int CategoryID, string CategoryName)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
            _Mode = enMode.Update;
        }

        public static clsVehicleCategory FindVehicleCategoryByID(int categoryID)
        {
            VehicleCategoryDTO dto = clsVehicleCategoryData.GetVehicleCategoryByID(categoryID);

            if (dto == null)
                return null;

            return new clsVehicleCategory(dto.CategoryID, dto.CategoryName);
        }

        public static clsVehicleCategory FindVehicleCategoryByName(string categoryName)
        {
            VehicleCategoryDTO dto = clsVehicleCategoryData.GetVehicleCategoryByName(categoryName);

            if (dto == null)
                return null;

            return new clsVehicleCategory(dto.CategoryID, dto.CategoryName);
        }

        public static DataTable GetAllVehicleCategories()
        {
            return clsVehicleCategoryData.GetAllVehicleCategories();
        }

        bool _Update()
        {
            return clsVehicleCategoryData.UpdateVehicleCategory(VCDTO);
        }

        bool _AddNew()
        {
            this.CategoryID = clsVehicleCategoryData.AddVehicleCategory(VCDTO);
            return CategoryID != -1;
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
