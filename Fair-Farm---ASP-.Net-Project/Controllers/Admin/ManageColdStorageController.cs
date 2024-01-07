using BLL.DTOs;
using BLL.Services.Admin;
using Fair_Farm.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fair_Farm.Controllers.Admin
{
    public class ManageColdStorageController : ApiController
    {
        [Logged]

        [HttpGet]
        [Route("api/coldstorage/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = ManageColdStorageService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);

            }
        }
        [AdminAccess]
        [HttpPost]
        [Route("api/coldstorage/create")]
        public HttpResponseMessage Create(ManageColdStorageDTO s)
        {
            try
            {
                var data = ManageColdStorageService.Add(s);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Cold Storage not created " });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "ColdStorage created" });


            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);

            }
        }
        [AdminAccess]
        [HttpGet]
        [Route("api/coldstorage/{id}")]
        public HttpResponseMessage GetColdStorageById(int id)
        {
            try
            {
                var data = ManageColdStorageService.Get(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "ColdStorage not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [AdminAccess]
        [HttpPut]
        [Route("api/coldstorage/{id}")]
        public HttpResponseMessage UpdateColdStorage(ManageColdStorageDTO tr)
        {
            try
            {
                var updatedUser = ManageColdStorageService.Update(tr);
                if (updatedUser != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Cold storage updated " });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Cold storage not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [AdminAccess]
        [HttpDelete]
        [Route("api/coldstorage/delete/{id}")]
        public HttpResponseMessage DeleteColdStorage(int id)
        {
            try
            {
                var isDeleted = ManageColdStorageService.Delete(id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Cold storage deleted successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Cold storage not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
