using CarRental_DataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_BusinessLayar
{
    public class clsVehicleModel
    {
        public VehicleModelDTO VMDTO
        {
            get
            {
                return new VehicleModelDTO(this.ModelID, this.ModelName, this.MakeID, this.Year);
            }
        }

        public int ModelID { get; set; }
        public int MakeID { get; set; }
        public clsVehicleMake MakeInfo { get; set; }
        public string ModelName { get; set; }
        public int Year { get; set; }

        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode _Mode = enMode.Update;

        public clsVehicleModel()
        {
            ModelID = -1;
            MakeID = -1;
            ModelName = "";
            Year = 0;
            MakeInfo = new clsVehicleMake();
            _Mode = enMode.AddNew;
        }

        private clsVehicleModel(int ModelID, string ModelName, int MakeID, int Year)
        {
            this.ModelID = ModelID;
            this.MakeID = MakeID;
            this.ModelName = ModelName;
            this.Year = Year;
            MakeInfo = clsVehicleMake.FindVehicleMakeByID(MakeID);
            _Mode = enMode.Update;
        }

        public static clsVehicleModel FindVehicleModelByID(int modelID)
        {
            VehicleModelDTO dto = clsVehicleModelData.GetVehicleModelByID(modelID);

            if (dto == null)
                return null;

            return new clsVehicleModel(dto.ModelID, dto.ModelName, dto.MakeID, dto.Year);
        }

        public static clsVehicleModel FindVehicleModelByName(string modelName)
        {
            VehicleModelDTO dto = clsVehicleModelData.GetVehicleModelByName(modelName);

            if (dto == null)
                return null;

            return new clsVehicleModel(dto.ModelID, dto.ModelName, dto.MakeID, dto.Year);
        }

        public static DataTable GetAllVehicleModels()
        {
            return clsVehicleModelData.GetAllVehicleModels();
        }
        public static DataTable GetModelsByMakeID(int makeID)
        {
            return clsVehicleModelData.GetModelsByMakeID(makeID);
        }

        bool _Update()
        {
            return clsVehicleModelData.UpdateVehicleModel(VMDTO);
        }

        bool _AddNew()
        {
            this.ModelID = clsVehicleModelData.AddVehicleModel(VMDTO);
            return ModelID != -1;
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
