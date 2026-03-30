using CarRental_DataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_BusinessLayar
{
    public class clsPayment
    {
        public PaymentDTO PDTO
        {
            get
            {
                return new PaymentDTO(
                    this.PaymentID,
                    this.VehicleBookRecordID,
                    this.InitialPaidAmount,
                    this.TotalActualDueAmount,
                    this.PaymentDate,
                    this.UpdatedPaymentDate);
            }
        }

        public int PaymentID { get; set; }
        public int VehicleBookRecordID { get; set; } 

        public decimal InitialPaidAmount { get; set; }
        public decimal? TotalActualDueAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime? UpdatedPaymentDate { get; set; }
        public clsRentalBooking BookingInfo {  get; set; }
        enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.Update;
        public decimal Remaining
        {
            get
            {
                return Math.Max(0, BookingInfo.InitialTotalAmount - InitialPaidAmount);
            }
        }

        public decimal Refunded
        {
            get
            {

                return Math.Max(0, InitialPaidAmount - BookingInfo.InitialTotalAmount);
            }
        }
        public clsPayment()
        {
            PaymentID = -1;
            VehicleBookRecordID = -1;
            InitialPaidAmount = 0;
            TotalActualDueAmount = null;
            PaymentDate = DateTime.Now;
            UpdatedPaymentDate = null;
            BookingInfo = new clsRentalBooking() ;
            _Mode = enMode.AddNew;
        }

        private clsPayment(int PaymentID, int VehicleBookRecordID,
            decimal InitialPaidAmount, decimal? TotalActualDueAmount,
            DateTime PaymentDate, DateTime? UpdatedPaymentDate)
        {
            this.PaymentID = PaymentID;
            this.VehicleBookRecordID = VehicleBookRecordID;
            this.InitialPaidAmount = InitialPaidAmount;
            this.TotalActualDueAmount = TotalActualDueAmount;
            this.PaymentDate = PaymentDate;
            this.UpdatedPaymentDate = UpdatedPaymentDate;
            this.BookingInfo=clsRentalBooking.FindBookingByID(VehicleBookRecordID);
            _Mode = enMode.Update;
        }

        public static clsPayment FindPaymentByID(int paymentID)
        {
            PaymentDTO dto = clsPaymentData.GetPaymentByID(paymentID);
            if (dto == null) return null;

            return new clsPayment(dto.PaymentID, dto.VehicleBookRecordID,
                dto.InitialPaidAmount, dto.TotalActualDueAmount,
                dto.PaymentDate, dto.UpdatedPaymentDate);
        }

        public static clsPayment FindByBookingID(int bookingID)
        {
            PaymentDTO dto = clsPaymentData.GetPaymentByBookingID(bookingID);
            if (dto == null) return null;

            return new clsPayment(dto.PaymentID, dto.VehicleBookRecordID,
                dto.InitialPaidAmount, dto.TotalActualDueAmount,
                dto.PaymentDate, dto.UpdatedPaymentDate);
        }

        public static DataTable GetAllPayments()
        {
            return clsPaymentData.GetAllPayments();
        }

        bool _AddNew()
        {
            this.PaymentID = clsPaymentData.AddPayment(PDTO);
            return PaymentID != -1;
        }

        bool _Update()
        {
            return clsPaymentData.UpdatePayment(PDTO);
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

        public static bool DeletePayment(int paymentID)
        {
            return clsPaymentData.DeletePayment(paymentID);
        }
    }
    //public class clsPayment
    //{
    //    public PaymentDTO PDTO
    //    {
    //        get
    //        {
    //            return new PaymentDTO(this.PaymentID,
    //                this.InitialPaidAmount,
    //                this.TotalActualDueAmount,
    //                this.PaymentDate,
    //                this.UpdatedPaymentDate);
    //        }
    //    }

    //    public int PaymentID { get; set; }
    //    public decimal InitialPaidAmount { get; set; }
    //    public decimal? TotalActualDueAmount { get; set; }
    //    public DateTime PaymentDate { get; set; }
    //    public DateTime? UpdatedPaymentDate { get; set; }

    //    enum enMode
    //    {
    //        AddNew = 1,
    //        Update = 2
    //    }

    //    private enMode _Mode = enMode.Update;

    //    public clsPayment()
    //    {
    //        PaymentID = -1;
    //        InitialPaidAmount = 0;
    //        TotalActualDueAmount = null;
    //        PaymentDate = DateTime.Now;
    //        UpdatedPaymentDate = null;

    //        _Mode = enMode.AddNew;
    //    }

    //    private clsPayment(int PaymentID, decimal InitialPaidAmount,
    //        decimal? TotalActualDueAmount, DateTime PaymentDate, DateTime? UpdatedPaymentDate)
    //    {
    //        this.PaymentID = PaymentID;
    //        this.InitialPaidAmount = InitialPaidAmount;
    //        this.TotalActualDueAmount = TotalActualDueAmount;
    //        this.PaymentDate = PaymentDate;
    //        this.UpdatedPaymentDate = UpdatedPaymentDate;

    //        _Mode = enMode.Update;
    //    }

    //    public static clsPayment FindPaymentByID(int paymentID)
    //    {
    //        PaymentDTO dto = clsPaymentData.GetPaymentByID(paymentID);

    //        if (dto == null)
    //            return null;

    //        return new clsPayment(dto.PaymentID, dto.InitialPaidAmount,
    //            dto.TotalActualDueAmount, dto.PaymentDate, dto.UpdatedPaymentDate);
    //    }

    //    public static DataTable GetAllPayments()
    //    {
    //        return clsPaymentData.GetAllPayments();
    //    }

    //    bool _AddNew()
    //    {
    //        this.PaymentID = clsPaymentData.AddPayment(PDTO);

    //        return PaymentID != -1;
    //    }

    //    bool _Update()
    //    {
    //        return clsPaymentData.UpdatePayment(PDTO);
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

    //    public static bool DeletePayment(int paymentID)
    //    {
    //        return clsPaymentData.DeletePayment(paymentID);
    //    }
    //}
}
