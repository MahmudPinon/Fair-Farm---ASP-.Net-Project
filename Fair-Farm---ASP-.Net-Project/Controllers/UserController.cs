using BLL.DTOs;
using BLL.Services;
using Fair_Farm.Auth;
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
    public class UserController : ApiController
    {

        [AdminAccess]

        [HttpGet]
        [Route("api/users/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);

            }
        }
        
        [HttpPost]
        [Route("api/users/create")]
        public HttpResponseMessage Create(UserDTO s)
        {
            try
            {
                var data = UserService.Add(s);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "User not created check you password and email" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message ="User created" });
               

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);

            }
        }
        [Logged]
        [HttpGet]
        [Route("api/users/{id}")]
        public HttpResponseMessage GetUserById(int id)
        {
            try
            {
                var data = UserService.Get(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
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

        [AdminAccess]
        [HttpPut]
        [Route("api/users/{id}")]
        public HttpResponseMessage UpdateUser(UserDTO user)
        {
            try
            {
                var updatedUser = UserService.Update(user);
                if (updatedUser != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "User updated "});
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found or update failed" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [AdminAccess]
        [HttpDelete]
        [Route("api/users/delete/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                var isDeleted = UserService.Delete(id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "User deleted successfully" });
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

    }
}
