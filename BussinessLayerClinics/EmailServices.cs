using _BussinessLayerClinics;
using DataAccessLayerClinics.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmailServices
{
        private readonly string EmailFrom = "Ka4766311@gmail.com";

        private readonly string Password = "gubo kmns iivi yuoj";
        public void SendEmail(string Emailto, string subject, string body)
        {
            try {
            // Implement email sending logic here using EmailFrom and Password
            // This is a placeholder for the actual email sending code
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(EmailFrom, Password),
                EnableSsl = true,
            };
            var MailMessage = new MailMessage
            {
                From = new MailAddress(EmailFrom),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            MailMessage.To.Add(Emailto);

            smtpClient.Send(MailMessage);
            } 
            catch (Exception)
            {
                return;
            }





        }
    
        public void SendMonthlyReportForDoctors()
        {
            List<DTODoctorRead> Doctors = ClsDoctor.GetAllDoctors();
            int CountBooks = 0;
            int MonthlyRevenue = 0;
            foreach (var doctor in Doctors)
            {
                CountBooks=ClsBooking.GetallBookingWithDoctorbyID(doctor.ID).Count;
                MonthlyRevenue=ClsBooking.GetMonthlyreVenueforDoctor(doctor.ID,ClsValidation.ToDateDateOnly(DateTime.Now));
                
                SendEmail(doctor.Email,"Monthly Report", 
                    $"Doctor Name: {doctor.FirstName} <br> Total Bookings: {CountBooks} <br> Monthly Revenue: {MonthlyRevenue} EGP <br> Thank you for your service!");
            }
        }
    }
}
