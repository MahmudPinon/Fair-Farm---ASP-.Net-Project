using BLL.Services;
using Fair_Farm.Auth;
using Fair_Farm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Fair_Farm.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/auth/login")]
        public HttpResponseMessage Login(LoginModel model)
        {
            try
            {
                var isAuthenticated = AuthServices.Login(model.Username, model.Password);

                if (isAuthenticated != null)
                {
           
                    return Request.CreateResponse(HttpStatusCode.OK, isAuthenticated);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
                }
            }
            catch (Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /*     [Logged]
             [HttpGet]
             [Route("api/logout")]
             public HttpResponseMessage Logout()
             {
                 var token = Request.Headers.Authorization.ToString();
                 try
                 {
                     var res = AuthServices.Logout(token);
                     return Request.CreateResponse(HttpStatusCode.OK, res);
                 }
                 catch (Exception ex)
                 {
                     return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                 }

             }*/


        [Logged] 
        [HttpGet]
        [Route("api/auth/logout")]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            try
            {
                var isLoggedOut = AuthServices.Logout(token);
                if (isLoggedOut)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Logged out successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Logout failed" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        /**/

        [Logged] 
        [HttpGet]
        [Route("api/auth/validate")]
        public HttpResponseMessage ValidateToken()
        {
            var token = Request.Headers.Authorization.ToString();
            try
            {
                var isValid = AuthServices.IsTokenValid(token);
                return Request.CreateResponse(HttpStatusCode.OK, new { IsValid = isValid });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [Logged] 
        [HttpGet]
        [Route("api/auth/isadmin")]
        public HttpResponseMessage IsAdmin()
        {
            var token = Request.Headers.Authorization.ToString();
            try
            {
                var isAdmin = AuthServices.IsAdmin(token);
                return Request.CreateResponse(HttpStatusCode.OK, new { IsAdmin = isAdmin });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

    }
}
