using BLL.Services.Farmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fair_Farm.Controllers.Farmer
{
    public class FarmerPreviousPriceController : ApiController
    {
        /*[Logged]*/
        [HttpGet]
        [Route("api/farmerpreviousprices")]
        public HttpResponseMessage GetAllRegularPricebyFarmer()
        {
            try
            {
                var data = FarmerPreviousPriceService.GetallPreviousPriceData();

                if (data.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There ia Not any Item" });
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


        /*[Logged]*/
        [HttpGet]
        [Route("api/farmerpreviousprice/{id}")]
        public HttpResponseMessage GetRegularPricebyIdbyFarmer(int id)
        {
            try
            {
                var data = FarmerPreviousPriceService.GetPreviousPriceDatabyId(id);

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
    }
}
