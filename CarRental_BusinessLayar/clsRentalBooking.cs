using CarRental_DataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_BusinessLayar
{
    public class clsRentalBooking
    {
        public RentalBookingDTO DTO
        {
            get
            {
                return new RentalBookingDTO(
                    this.RentalBookingID,
                    this.CustomerID,
                    this.VehicleID,
                    this.RentedAt,
                    this.DueDate,
                    this.PickUpLocation,
                    this.DropOffLocation,
                    this.VehicleConditionNotes,
                    this.Status
                );
            }
        }

        public int RentalBookingID { get; set; }


        public int CustomerID { get; set; }
        public clsCustomer CustomerInfo { get; set; }

        public int VehicleID { get; set; }
        public clsVehicle VehicleInfo { get; set; }

        public DateTime RentedAt { get; set; }
        public DateTime DueDate { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public string VehicleConditionNotes { get; set; }
        public int Status { get; set; }

        public string StatusCaption
        {
            get
            {
                switch ((enStatus)Status)
                {
                    case enStatus.Pending: return "Pending";
                    case enStatus.Confirmed: return "Confirmed";
                    case enStatus.Completed: return "Completed";
                    default: return "Unknown";
                }
            }
        }

        public decimal InitialTotalAmount
        {
            get
            {
                return (DueDate - RentedAt).Days * VehicleInfo.RentalCostPerDay;
            }
        }

       

        enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.Update;

        public enum enStatus
        {
            Pending = 1,
            Confirmed,
            Completed
        }

        public clsRentalBooking()
        {
            RentalBookingID = -1;
            CustomerID = -1;
            VehicleID = -1;
            RentedAt = DateTime.Now;
            DueDate = DateTime.Now;
            PickUpLocation = "";
            DropOffLocation = "";
            VehicleConditionNotes = "";
            Status = 1;

            CustomerInfo = new clsCustomer();
            VehicleInfo = new clsVehicle();

            _Mode = enMode.AddNew;
        }

        private clsRentalBooking(int id, int customerID, int vehicleID,
            DateTime rentedAt, DateTime dueDate,
            string pick, string drop, string notes, int status)
        {
            RentalBookingID = id;
            CustomerID = customerID;
            VehicleID = vehicleID;
            RentedAt = rentedAt;
            DueDate = dueDate;
            PickUpLocation = pick;
            DropOffLocation = drop;
            VehicleConditionNotes = notes;
            Status = status;

            CustomerInfo = clsCustomer.FindCustomerByCustomerID(CustomerID);
            VehicleInfo = clsVehicle.FindVehicleByID(VehicleID);

            _Mode = enMode.Update;
        }

        public static clsRentalBooking FindBookingByID(int id)
        {
            RentalBookingDTO dto = clsRentalBookingData.GetBookingByID(id);
            if (dto == null) return null;

            return new clsRentalBooking(
                dto.RentalBookingID,
                dto.CustomerID,
                dto.VehicleID,
                dto.RentedAt,
                dto.DueDate,
                dto.PickUpLocation,
                dto.DropOffLocation,
                dto.VehicleConditionNotes,
                dto.Status
            );
        }
        public static clsRentalBooking FindBookingByVehicleID(int id)
        {
            RentalBookingDTO dto = clsRentalBookingData.GetBookingByVehicleID(id);
            if (dto == null) return null;

            return new clsRentalBooking(
                dto.RentalBookingID,
                dto.CustomerID,
                dto.VehicleID,
                dto.RentedAt,
                dto.DueDate,
                dto.PickUpLocation,
                dto.DropOffLocation,
                dto.VehicleConditionNotes,
                dto.Status
            );
        }
        public static DataTable GetAllBookings()
        {
            return clsRentalBookingData.GetAllBookings();
        }

        bool _AddNew()
        {
            this.RentalBookingID = clsRentalBookingData.AddBooking(DTO);
            return RentalBookingID != -1;
        }

        bool _Update()
        {
            return clsRentalBookingData.UpdateBooking(DTO);
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

        public static bool DeleteBooking(int id)
        {
            return clsRentalBookingData.DeleteBooking(id);
        }
    }
    //public class clsRentalBooking
    //{
    //    public RentalBookingDTO DTO
    //    {
    //        get
    //        {
    //            return new RentalBookingDTO(
    //                this.RentalBookingID,
    //                this.PaymentID,
    //                this.CustomerID,
    //                this.VehicleID,
    //                this.RentedAt,
    //                this.DueDate,
    //                this.PickUpLocation,
    //                this.DropOffLocation,
    //                this.VehicleConditionNotes,
    //                this.Status
    //            );
    //        }
    //    }

    //    public int RentalBookingID { get; set; }
    //    public int? PaymentID { get; set; }
    //    public clsPayment PaymentInfo { get; set; }

    //    public int CustomerID { get; set; }
    //    public clsCustomer CustomerInfo { get; set; }

    //    public int VehicleID { get; set; }
    //    public clsVehicle VehicleInfo { get; set; }

    //    public DateTime RentedAt { get; set; }
    //    public DateTime DueDate { get; set; }
    //    public string PickUpLocation { get; set; }
    //    public string DropOffLocation { get; set; }
    //    public string VehicleConditionNotes { get; set; }
    //    public int Status { get; set; }
    //    public string StatusCaption
    //    {
    //        get
    //        {
    //            switch ((enStatus)Status)
    //            {
    //                case enStatus.Pending:
    //                    return "Pending";

    //                case enStatus.Confirmed:
    //                    return "Confirmed";
    //                case enStatus.Completed:
    //                    return "Completed";
    //                default:
    //                    return "Unknown";
    //            }
    //        }
    //    }

    //    //public int ActualTotalDueAmount
    //    //{
    //    //    get
    //    //    {
    //    //        if((enStatus)Status == enStatus.Completed)

    //    //    }
    //    //}

    //    public decimal InitialTotalAmount
    //    {
    //        get
    //        {
    //            return (DueDate - RentedAt).Days * VehicleInfo.RentalCostPerDay;
    //        }
    //    }
    //    public decimal Remaining
    //    {
    //        get
    //        {
    //            if (PaymentInfo?.InitialPaidAmount >= InitialTotalAmount)
    //            {
    //                return 0;
    //            }
    //            else
    //            {

    //                return InitialTotalAmount - PaymentInfo.InitialPaidAmount; 
    //            }
    //        }

    //    }
    //    public decimal Refunded
    //    {
    //        get
    //        {
    //            if (PaymentInfo?.InitialPaidAmount <= InitialTotalAmount)
    //            {
    //                return 0;
    //            }
    //            else
    //            {

    //                return PaymentInfo.InitialPaidAmount - InitialTotalAmount ;
    //            }
    //        }

    //    }

    //    enum enMode
    //    {
    //        AddNew = 1,
    //        Update = 2
    //    }

    //    private enMode _Mode = enMode.Update;

    //    public enum enStatus
    //    {
    //        Pending =1,
    //        Confirmed,
    //        Completed
    //    }
    //    public clsRentalBooking()
    //    {
    //        RentalBookingID = -1;
    //        PaymentID = null;
    //        CustomerID = -1;
    //        VehicleID = -1;
    //        RentedAt = DateTime.Now;
    //        DueDate = DateTime.Now;
    //        PickUpLocation = "";
    //        DropOffLocation = "";
    //        VehicleConditionNotes = "";
    //        Status = 1;
    //        CustomerInfo = new clsCustomer();
    //        PaymentInfo = new clsPayment();
    //        VehicleInfo = new clsVehicle();
    //        _Mode = enMode.AddNew;
    //    }

    //    private clsRentalBooking(int id, int? paymentID, int customerID, int vehicleID,
    //        DateTime rentedAt, DateTime dueDate, string pick, string drop,
    //        string notes, int status)
    //    {
    //        RentalBookingID = id;
    //        PaymentID = paymentID;
    //        CustomerID = customerID;
    //        VehicleID = vehicleID;
    //        RentedAt = rentedAt;
    //        DueDate = dueDate;
    //        PickUpLocation = pick;
    //        DropOffLocation = drop;
    //        VehicleConditionNotes = notes;
    //        Status = status;
    //        CustomerInfo = clsCustomer.FindCustomerByCustomerID(CustomerID);
    //        if (PaymentID.HasValue)
    //            PaymentInfo = clsPayment.FindPaymentByID(paymentID.Value);

    //        VehicleInfo = clsVehicle.FindVehicleByID(VehicleID);
    //        _Mode = enMode.Update;
    //    }

    //    public static clsRentalBooking FindBookingByID(int id)
    //    {
    //        RentalBookingDTO dto = clsRentalBookingData.GetBookingByID(id);

    //        if (dto == null)
    //            return null;

    //        return new clsRentalBooking(
    //            dto.RentalBookingID,
    //            dto.PaymentID,
    //            dto.CustomerID,
    //            dto.VehicleID,
    //            dto.RentedAt,
    //            dto.DueDate,
    //            dto.PickUpLocation,
    //            dto.DropOffLocation,
    //            dto.VehicleConditionNotes,
    //            dto.Status
    //        );
    //    }
    //    public static clsRentalBooking FindBookingByPaymentID(int id)
    //    {
    //        RentalBookingDTO dto = clsRentalBookingData.GetBookingByPaymentID(id);

    //        if (dto == null)
    //            return null;

    //        return new clsRentalBooking(
    //            dto.RentalBookingID,
    //            dto.PaymentID,
    //            dto.CustomerID,
    //            dto.VehicleID,
    //            dto.RentedAt,
    //            dto.DueDate,
    //            dto.PickUpLocation,
    //            dto.DropOffLocation,
    //            dto.VehicleConditionNotes,
    //            dto.Status
    //        );
    //    }

    //    public static DataTable GetAllBookings()
    //    {
    //        return clsRentalBookingData.GetAllBookings();
    //    }

    //    bool _AddNew()
    //    {
    //        this.RentalBookingID = clsRentalBookingData.AddBooking(DTO);
    //        return RentalBookingID != -1;
    //    }

    //    bool _Update()
    //    {
    //        return clsRentalBookingData.UpdateBooking(DTO);

    //    }

    //    public bool Save()
    //    {
    //        switch (_Mode)
    //        {
    //            case enMode.AddNew:
    //                if (_AddNew())
    //                {
    //                    _Mode = enMode.Update;
    //                    return true;
    //                }
    //                return false;

    //            case enMode.Update:
    //                return _Update();
    //        }

    //        return false;
    //    }

    //    public static bool DeleteBooking(int id)
    //    {
    //        return clsRentalBookingData.DeleteBooking(id);
    //    }
    //}
}
