using _BussinessLayerClinics.Global;
using _DataAccessLayerClinics.Login;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;

namespace _ClinicsManaegment.Middlware
{
    public class AuthorizationMiddelware

    {
        private readonly RequestDelegate _Next;
        public AuthorizationMiddelware(RequestDelegate next)
        {
            _Next = next;
        }
        public async Task Invoke(HttpContext context)
        {

            if (ClsGlobal.Currentuser != null)
            { 
            string Path = context.Request.Path.ToString();
            if (ClsGlobal.IsDoctor())
            {
                if (context.Request.Path== "/api/Bookings/DeleteBooking/{id}"
                    || context.Request.Path == "/api/Bookings/AddBooking" || context.Request.Path == "/api/Bookings/ConfirmBooking"
                    || context.Request.Path == "/api/Bookings/UpdateBooking")
                {
                    context.Response.StatusCode = 403;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Access Denide");
                    return;// m4 hi3ml processing request w return 
                }

            }
            else
            {
                if (Path.Contains("/Reviews") || Path.Contains("/Payments"))
                {
                    context.Response.StatusCode = 403;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Access Denide");
                    return;// m4 hi3ml processing request w return 
                }

            }
            }

            await _Next(context);
        }
    }
}
