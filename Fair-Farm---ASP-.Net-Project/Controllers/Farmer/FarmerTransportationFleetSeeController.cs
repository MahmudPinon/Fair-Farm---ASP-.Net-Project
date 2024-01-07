using BLL.Services.Farmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fair_Farm.Controllers.Farmer
{
    public class FarmerTransportationFleetSeeController : ApiController
    {
        /*[Logged]*/
        [HttpGet]
        [Route("api/transportationfleetsee/{id}")]
        public HttpResponseMessage GetTransportationFleetseeByIdTransportFarmer(int id)
        {
            try
            {
                var data = FarmerTransportationFleetSeeService.GetForFarmerTransport(id);

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
        [Route("api/transportationfleetseeregionsregions/{regions}")]
        public HttpResponseMessage GetTransportationFleetseeByRegionTransportFarmer(string regions)
        {
            try
            {
                var data = FarmerTransportationFleetSeeService.GetByRegionForFarmerTransport(regions);

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
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Invalid Request" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
