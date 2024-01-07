using BLL.DTOs;
using BLL.Services.Farmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fair_Farm.Controllers.Farmer
{
    public class BuySellBetweenFarmerandTraderController : ApiController
    {
        /*[Logged]*/
        [HttpGet]
        [Route("api/farmerbuysellbetweenFarmerandTraderbyregion/{region}")]
        public HttpResponseMessage GetBuySellRequestBetweenFarmeranTraderByFarmer(string region)
        {
            try
            {
                var data = FarmerBuySellRequestBetweenFarmerandTraderService.GetBuySellRequestBetweenFarmerandTraderbyRegion(region);

                if (data.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No Record found" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }



        /*[Logged]*/
        [HttpGet]
        [Route("api/farmerbuysellbetweenFarmerandTraderbyId/{Id}")]
        public HttpResponseMessage GetBuySellRequestBetweenFarmeranTraderByFarmerById(int Id)
        {
            try
            {
                var data = FarmerBuySellRequestBetweenFarmerandTraderService.GetBuySellRequestBetweenFarmerandTraderbyId(Id);

                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No Record found" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /*[Logged]*/
        /*[FarmerAccess]*/
        [HttpPut]
        [Route("api/farmerbuysellbetweenFarmerandTraderbyUpdate/{userid}")]
        public HttpResponseMessage GetBuySellRequestBetweenFarmeranTraderByFarmerByUpdate(BuySellRequestBetweenFarmerAndTraderDTO s, int userid)
        {
            try
            {
                var data = FarmerBuySellRequestBetweenFarmerandTraderService.Update(s, userid);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "An Error Occured." });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Congratulation You have Successfuly Completed the Deal." });
            }
            catch (Exception ex)
            {
                if (ex.Message == "You are not a Registered User of the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You Have Provided Empty Data.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "This Crops Does not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "This Request Does not Belongs to Your Region.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "This Request is Already Taken by Another Farmer.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Invalid Input.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while Updating Your Request.");
            }
        }





    }
}
