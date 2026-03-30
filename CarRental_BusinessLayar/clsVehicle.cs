using CarRental_DataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_BusinessLayar
{
    public class clsVehicle
    {
        public VehicleDTO VDTO
        {
            get
            {
                return new VehicleDTO(
                    this.VehicleID,
                    this.ModelID,
                    this.Mileage,
                    this.PlateNumber,
                    this.RentalCostPerDay,
                    this.Status,
                    this.FuelType,
                    this.VehicleCategory);
            }
        }

        public int VehicleID { get; set; }
        public int ModelID { get; set; }
        public clsVehicleModel ModelInfo { get; set; }
        public int Mileage { get; set; }
        public string PlateNumber { get; set; }
        public decimal RentalCostPerDay { get; set; }
        public byte Status { get; set; }
        public int FuelType { get; set; }
        public clsFuelType FuelTypeInfo { get; set; }
        public int VehicleCategory { get; set; }
        public clsVehicleCategory VehicleCategoryInfo { get; set; }


        enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.Update;
        public enum enStatus
        {
            Available=1,
            Rented,
            Maintenace
        }
        public string StatusCaption
        {
            get
            {
                switch ((enStatus)Status)
                {
                    case enStatus.Available:
                        return "Available";
                    case enStatus.Rented:
                        return "Rented";
                    case enStatus.Maintenace:
                        return "Maintenance";
                    default:
                        return "Unknown";
                }
            }
        }
        public clsVehicle()
        {
            VehicleID = -1;
            ModelID = -1;
            ModelInfo = new clsVehicleModel();
            Mileage = -1;
            PlateNumber = "";
            RentalCostPerDay = -1;
            Status = (byte)enStatus.Available;
            FuelType = -1;
            FuelTypeInfo = new clsFuelType();
            VehicleCategory = -1;
            VehicleCategoryInfo = new clsVehicleCategory();

            _Mode = enMode.AddNew;
        }

        private clsVehicle(VehicleDTO dto)
        {
            VehicleID = dto.VehicleID;
            ModelID = dto.ModelID;
            Mileage = dto.Mileage;
            PlateNumber = dto.PlateNumber;
            RentalCostPerDay = dto.RentalCostPerDay;
            Status = dto.Status;
            FuelType = dto.FuelType;
            VehicleCategory = dto.VehicleCategory;
            ModelInfo = clsVehicleModel.FindVehicleModelByID(ModelID);
            FuelTypeInfo = clsFuelType.FindFuelTypeByID(FuelType);
            VehicleCategoryInfo = clsVehicleCategory.FindVehicleCategoryByID(VehicleCategory);


            _Mode = enMode.Update;
        }

        public static clsVehicle FindVehicleByID(int id)
        {
            var dto = clsVehicleData.GetVehicleByID(id);
            if (dto == null) return null;

            return new clsVehicle(dto);
        }
        public static clsVehicle FindVehicleByPlateNumber(string plateNumber)
        {
            var dto = clsVehicleData.GetVehicleByPlateNumber(plateNumber);
            if (dto == null) return null;

            return new clsVehicle(dto);
        }
        public static DataTable GetAllVehicles()
        {
            return clsVehicleData.GetAllVehicles();
        }

        bool _AddNew()
        {
            VehicleID = clsVehicleData.AddVehicle(VDTO);
            return VehicleID != -1;
        }

        bool _Update()
        {
            return clsVehicleData.UpdateVehicle(VDTO);
        }
        public static bool DeleteVehicle(int VehicleID)
        {
            return clsVehicleData.DeleteVehicle(VehicleID);
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
        public bool IsAvailable()
        {
            return (enStatus)Status == enStatus.Available;
        }

    }
}
