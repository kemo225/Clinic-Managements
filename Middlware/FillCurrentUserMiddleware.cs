using _BussinessLayerClinics.Global;
using _DataAccessLayerClinics.Login;
using System.Security.Claims;

namespace Middlware
{
    public class FillCurrentUserMiddleware
{
        private readonly RequestDelegate _Next;
        public FillCurrentUserMiddleware(RequestDelegate next)
        {
            _Next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                int userID =Convert.ToInt32(context.User.FindFirst("ID")?.Value);
                var Name = context.User.FindFirst(ClaimTypes.Name)?.Value;
                var Phone = context.User.FindFirst(ClaimTypes.MobilePhone)?.Value;
                var Role = context.User.FindFirst("Role")?.Value;
                ClsGlobal.Currentuser=new CurrentUser(userID, Name, Phone, Role);


            }
            await _Next(context);
        }
    }
}
