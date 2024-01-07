using BLL.Services.Farmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fair_Farm.Controllers.Farmer
{
    public class FarmerTrainingController : ApiController
    {
        /*[Logged]*/
        [HttpGet]
        [Route("api/farmertrainingsee/{id}")]
        public HttpResponseMessage GetFarmerTrainingById(int id)
        {
            try
            {
                var data = FarmerTrainingServices.GetTrainigDetailsById(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No Record found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }


        /*[Logged]*/
        [HttpGet]
        [Route("api/farmertrainingseeregions/{region}")]
        public HttpResponseMessage GetFarmerTrainingDetailsbyRegion(string region)
        {
            try
            {
                var data = FarmerTrainingServices.GetTrainigDetailsByRegion(region);

                if (data.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No Record found" });

                }
                else if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No Record found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }

}

