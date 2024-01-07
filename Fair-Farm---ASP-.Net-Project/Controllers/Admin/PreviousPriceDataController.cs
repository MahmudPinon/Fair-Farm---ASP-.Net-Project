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
    public class PreviousPriceDataController : ApiController
    {
        [Logged]

        [HttpGet]
        [Route("api/PreviousPriceData/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = PreviousPriceDataService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);

            }
        }

        [AdminAccess]
        [HttpGet]
        [Route("api/PreviousPriceData/{id}")]
        public HttpResponseMessage GetPreviousPriceById(int id)
        {
            try
            {
                var data = PreviousPriceDataService.Get(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Data not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [AdminAccess]
        [HttpDelete]
        [Route("api/PreviousPriceData/delete/{id}")]
        public HttpResponseMessage DeletePreviousPrice(int id)
        {
            try
            {
                var isDeleted = PreviousPriceDataService.Delete(id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Data deleted successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Data not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

    }
}
