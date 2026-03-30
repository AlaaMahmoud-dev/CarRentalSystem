using CarRental_DataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_BusinessLayar
{
    public class clsReturnRecord
    {
        public ReturnRecordDTO DTO
        {
            get
            {
                return new ReturnRecordDTO(
                    this.ReturnRecordID,
                    this.VehicleBookRecordID,
                    this.ActualReturnDate,
                    this.CurrentMileages,
                    this.VehicleOldMileages,
                    this.AdditionalCharges,
                    this.FinalVehicleCheckNotes
                );
            }
        }

        public int ReturnRecordID { get; set; }
        public int VehicleBookRecordID { get; set; }
        public clsRentalBooking BookingInfo { get; set; }

        public DateTime ActualReturnDate { get; set; }
        public int CurrentMileages { get; set; }
        public int VehicleOldMileages { get; set; }
        public decimal AdditionalCharges { get; set; }
        public string FinalVehicleCheckNotes { get; set; }

        public decimal ActualTotalAmount
        {
            get
            {
                return (((ActualReturnDate - this.BookingInfo.RentedAt).Days) * BookingInfo.VehicleInfo.RentalCostPerDay) + AdditionalCharges;
            }
        }
        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode _Mode = enMode.Update;

        public clsReturnRecord()
        {
            ReturnRecordID = -1;
            VehicleBookRecordID = -1;
            ActualReturnDate = DateTime.Now;
            CurrentMileages = 0;
            VehicleOldMileages = 0;
            AdditionalCharges = 0;
            FinalVehicleCheckNotes = "";

            BookingInfo = new clsRentalBooking();

            _Mode = enMode.AddNew;
        }

        private clsReturnRecord(int returnRecordID, int vehicleBookRecordID,
            DateTime actualReturnDate, int currentMileages, int vehicleOldMileages,
            decimal additionalCharges, string finalVehicleCheckNotes)
        {
            this.ReturnRecordID = returnRecordID;
            this.VehicleBookRecordID = vehicleBookRecordID;
            this.ActualReturnDate = actualReturnDate;
            this.CurrentMileages = currentMileages;
            this.VehicleOldMileages = vehicleOldMileages;
            this.AdditionalCharges = additionalCharges;
            this.FinalVehicleCheckNotes = finalVehicleCheckNotes;

            BookingInfo = clsRentalBooking.FindBookingByID(vehicleBookRecordID);

            _Mode = enMode.Update;
        }

        public static clsReturnRecord FindReturnRecordByID(int id)
        {
            ReturnRecordDTO dto = clsReturnRecordData.GetReturnRecordByID(id);

            if (dto == null)
                return null;

            return new clsReturnRecord(
                dto.ReturnRecordID,
                dto.VehicleBookRecordID,
                dto.ActualReturnDate,
                dto.CurrentMileages,
                dto.VehicleOldMileages,
                dto.AdditionalCharges,
                dto.FinalVehicleCheckNotes
            );
        }
        public static clsReturnRecord FindReturnRecordByBookingID(int id)
        {
            ReturnRecordDTO dto = clsReturnRecordData.GetReturnRecordByBookingID(id);

            if (dto == null)
                return null;

            return new clsReturnRecord(
                dto.ReturnRecordID,
                dto.VehicleBookRecordID,
                dto.ActualReturnDate,
                dto.CurrentMileages,
                dto.VehicleOldMileages,
                dto.AdditionalCharges,
                dto.FinalVehicleCheckNotes
            );
        }

        public static DataTable GetAllReturnRecords()
        {
            return clsReturnRecordData.GetAllReturnRecords();
        }

        bool _AddNew()
        {
            clsRentalBooking bookingInfo = clsRentalBooking.FindBookingByID(VehicleBookRecordID);
            decimal ActualTotalAmount = (((ActualReturnDate - bookingInfo.RentedAt).Days) * BookingInfo.VehicleInfo.RentalCostPerDay) + AdditionalCharges;
            this.ReturnRecordID =
                clsReturnRecordData.AddReturnRecord(DTO, bookingInfo.VehicleID, ActualTotalAmount);

            return ReturnRecordID != -1;
        }

        bool _Update()
        {
            return clsReturnRecordData.UpdateReturnRecord(DTO);
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
                    return false;

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public static bool DeleteReturnRecord(int id)
        {
            return clsReturnRecordData.DeleteReturnRecord(id);
        }
    }
}
