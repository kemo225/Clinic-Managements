using _BussinessLayerClinics;
using _BussinessLayerClinics.Global;
using _DataAccessLayerClinics.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _ClinicsManaegment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("LoginDoctor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public ActionResult LoginDoctor(DtoLogin login)
        {
            if (login == null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest("Invalid login credentials.");
            }
            bool isAuthenticated = ClsAuth.LoginDoctor(login);
            if (isAuthenticated)
            {
     
                return Ok(ClsAuth.GenerateJWTokenDoctor(login));
            }
            else
            {
                return Unauthorized("Invalid username or password.");
            }


        }
        [HttpPost("LoginNurse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public ActionResult LoginNurse(DtoLogin login)
        {
            if (login == null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest("Invalid login credentials.");
            }
            bool isAuthenticated = ClsAuth.LoginNurse(login);
            if (isAuthenticated)
            {
                return Ok(ClsAuth.GenerateJWTokenNurse(login));
            }
            else
            {
                return Unauthorized("Invalid username or password.");
                //}


            }

        }
    }
}
