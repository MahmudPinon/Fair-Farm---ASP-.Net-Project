using BLL.DTOs;
using BLL.Services;
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
    public class FreeSeedsDistributionManagementController : ApiController
    {
        [Logged]

        [HttpGet]
        [Route("api/freeSeeds/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = FreeSeedsDistributionManagementService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);

            }
        }

        [HttpPost]
        [Route("api/freeSeeds/create")]
        public HttpResponseMessage Create(FreeSeedsDistributionDTO s)
        {
            try
            {
                var data = FreeSeedsDistributionManagementService.Add(s);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Free seeds request not created " });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Free seeds Request created" });


            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);

            }
        }
        [Logged]
        [HttpGet]
        [Route("api/freeSeeds/{id}")]
        public HttpResponseMessage GetFreeSeedRequestById(int id)
        {
            try
            {
                var data = FreeSeedsDistributionManagementService.Get(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Seed Request not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Logged]
        [HttpPut]
        [Route("api/freeSeeds/{id}")]
        public HttpResponseMessage UpdateFreeSeedsRequest(FreeSeedsDistributionDTO fs)
        {
            try
            {
                var updatedUser = FreeSeedsDistributionManagementService.Update(fs);
                if (updatedUser != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Free seeds request updated " });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Free seeds Request not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [AdminAccess]
        [HttpDelete]
        [Route("api/freeSeeds/delete/{id}")]
        public HttpResponseMessage DeleteFreeSeedsRequest(int id)
        {
            try
            {
                var isDeleted = FreeSeedsDistributionManagementService.Delete(id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Free seeds request deleted successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Free seeds request not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

    }
}
