using _3_DataAccessLayerClinics.Models;
using _DataAccessLayerClinics.Login;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace _BussinessLayerClinics
{

    //token 
    // Header Alg Type
    // Payload Claims expire
    //Signuture ( secretKet + header + payload ) hash
    public class ClsAuth
    {
        public static bool LoginDoctor(DtoLogin login)
        {
            return ClsDataAccessLogin.LoginDoctor(login);
        }
        public static bool LoginNurse(DtoLogin login)
        {
            return ClsDataAccessLogin.LoginNurse(login);
        }
        public static string GenerateJWTokenDoctor(DtoLogin login)
        {
            List<Claim> claimss = new List<Claim>();
            string Secretkey = "osidcfgw#$%#$@_()_!+_PWOSLX>W)EF(GIKFLD";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secretkey));

            var doctor = ClsDoctor.GetDoctorbyUserName(login.Username);

            claimss.Add(new Claim("ID", doctor.ID.ToString()));
            claimss.Add(new Claim(ClaimTypes.Name, doctor.FirstName + " " + doctor.LastName));
            claimss.Add(new Claim(ClaimTypes.MobilePhone, doctor.Phone));
            claimss.Add(new Claim("Role", "Doctor"));

            var signcDoctor = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var TokenDoctor = new JwtSecurityToken(
                claims: claimss,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signcDoctor
                );
            return new JwtSecurityTokenHandler().WriteToken(TokenDoctor);







        }

        public static string GenerateJWTokenNurse(DtoLogin login)
        {
            List<Claim> claimss = new List<Claim>();
            string Secretkey = "osidcfgw#$%#$@_()_!+_PWOSLX>W)EF(GIKFLD";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secretkey));


                 var Nurse = ClsNurse.GetNurseByUserName(login.Username);


                claimss.Add(new Claim("ID", Nurse.ID.ToString()));
                claimss.Add(new Claim(ClaimTypes.Name, Nurse.FirstName + " " + Nurse.LastName));
                claimss.Add(new Claim(ClaimTypes.MobilePhone, Nurse.Phone));
                 claimss.Add(new Claim("Role", "Nurse"));


            var signcNurse = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var TokenNurse = new JwtSecurityToken(
                    claims: claimss,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signcNurse
                    );
                return new JwtSecurityTokenHandler().WriteToken(TokenNurse);










        }
    }
    }

