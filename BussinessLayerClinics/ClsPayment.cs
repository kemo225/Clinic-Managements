using _DataAccessLayerClinics.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BussinessLayerClinics
{
    public class ClsPayment
    {
        public int ID { get; set; }
        public int BookingID { get; set; }
        public int DetectionCost { get; set; }
        public string PaymentMethod { get; set; }
        public string PhoneNumberPaymentTo { get; set; }
        public bool IsCash { get; set; }
        public string DoctorName { get; set; }

        public string PatientName { get; set; }

        public string phoneNumberpaymentTo { get; set; }

        public string CreatedBy { get; set; }
        public DtopaymentRead DtoPaymentread
        {
            get
            {
                return new DtopaymentRead(ID, BookingID, DetectionCost, PaymentMethod, PhoneNumberPaymentTo, IsCash, DoctorName, PatientName, CreatedBy);
            }
            set
            {                 ID = value.ID;
                BookingID = value.BookingID;
                DetectionCost = value.DetectionCost;
                PaymentMethod = value.PaymentMethod;
                PhoneNumberPaymentTo = value.phoneNumberpaymentTo;
                IsCash = value.IsCash;
                DoctorName = value.DoctorName;
                PatientName = value.PatientName;
                CreatedBy = value.CreatedBy;
            }
        }
        public DTOPaymentAdd DTOPaymentAdd
        {
            get
            {
                return new DTOPaymentAdd( BookingID, DetectionCost, PaymentMethod, PhoneNumberPaymentTo, IsCash);
            }
            set
            {
             this.BookingID = value.BookingID;
                this.DetectionCost = value.DetectionCost;
                this.PaymentMethod = value.PaymentMethod;
                this.PhoneNumberPaymentTo = value.phoneNumberpaymentTo;
                this.IsCash = value.IsCash;

            }
        }
        public DTOPaymentUpdate DTOPaymentUpdate
        {
            get
            {
                return new DTOPaymentUpdate(ID, BookingID, DetectionCost, PaymentMethod, PhoneNumberPaymentTo, IsCash);
            }
            set
            {
                this.ID = value.ID;
                this.BookingID = value.BookingID;
                this.DetectionCost = value.DetectionCost;
                this.PaymentMethod = value.PaymentMethod;
                this.PhoneNumberPaymentTo = value.phoneNumberpaymentTo;
                this.IsCash = value.IsCash;
            }
        }

        public enum enMode { update, add }
        public enMode Mode { get; set; }
        public ClsPayment(DtopaymentRead dtopayment,enMode mode)
        {
            this.DtoPaymentread = dtopayment;
            this.Mode = mode;
        }
        public ClsPayment(DTOPaymentAdd dtopayment, enMode mode)
        {
            this.DTOPaymentAdd = dtopayment;
            this.Mode = mode;
        }
        public static ClsPayment GetPaymentByID(int ID)
        {
            DtopaymentRead dto =clsdataaccessPayment.GetPaymentByID(ID);
            if(dto != null)
            {
                return new ClsPayment(dto, enMode.update);
            }
            return null;
        }
        public static List<DtopaymentRead> GetAllPayments()
        {
            return clsdataaccessPayment.GetallPayment();
        }
        private bool Addpayment()
        {
                       this.ID=clsdataaccessPayment.AddPayment(this.DTOPaymentAdd);
            return (this.ID > 0) ;
        }
        private bool UpdatePayment()
        {
            return clsdataaccessPayment.UpdatePayment(this.DTOPaymentUpdate);
        }
        public static bool DeletePayment(int ID)
        {
            return clsdataaccessPayment.deletePayment(ID);
        }
        public static List<DtopaymentRead> GetAllPaymentsWithDoctorByID(int DoctorID)
        {
            return clsdataaccessPayment.GetallPaymentWithDoctorbyID(DoctorID);
        }
        public static DtopaymentRead GetPaymentByBookingID(int BookingID)
        {
            return clsdataaccessPayment.GetallPaymentBookingbyID(BookingID);
        }
       
        public bool Save()
        {
            switch
                (this.Mode)
            {
                case enMode.update:
                    return UpdatePayment();
                case enMode.add:
                    this.Mode = enMode.update;
                    return Addpayment();
                default:
                    return false; // Invalid mode
            }







        }

    }
}
