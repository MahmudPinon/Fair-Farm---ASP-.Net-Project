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
    public class FarmerTransportationFleetRentController : ApiController
    {
        /*[Logged]*/
        /*[FarmerAccess]*/
        [HttpPost]
        [Route("api/transportationfleetRent/create")]
        public HttpResponseMessage CreateF(TransportationFleetRentDTO s)
        {
            try
            {
                var data = FarmerTransportationFleetRentService.Add(s);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Transportation Fleet Rent Request is not Created" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Transportation Fleet Rent Request is Advertise Successfully" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Your Profile Does not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "This Transport Does not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You Can Not Rent Your Transport.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "This Transport Does not Belongs to Your Region.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "This Transportation is Already Rented You Can not Rent It.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Days Can not be Negative or 0.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Location Can not be Null or Empty.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Admin Can not Rent the Transport.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You Already Requested For this Transport.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while creating your Request.");
            }
        }


        /*[Logged]*/
        /*[FarmerAccess]*/
        [HttpPut]
        [Route("api/transportationfleetRentfarmer/{id}/{renterid}")]
        public HttpResponseMessage UpdateFarmerTransportationRentRequestF(int id, int renterid, TransportationFleetRentDTO s)
        {
            try
            {
                var data = FarmerTransportationFleetRentService.UpdatebyFarmer(id, renterid, s);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Updated Successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Requested Data not found" });
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "This Transportation Does not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You are not Renter of this Transport.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You Do not Provided Any Data To Update.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You Do not Provided Correct Data To Update.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You can Not Modify this Record as itis Already Approved.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        /*[Logged]*/
        /*[FarmerAccess]*/
        [HttpDelete]
        [Route("api/transportationfleetRent/{id}/{renterid}")]
        public HttpResponseMessage DeleteFarmerTransportationRentRequestF(int id, int renterid)
        {
            try
            {
                var isDeleted = FarmerTransportationFleetRentService.Delete(id, renterid);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Request has been Deleted Successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Your Request not found" });
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "This Transport Does Not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Your Profile Does not Match With This Transport Renter.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You can not Delete This Request.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You can not Delete a Approved Transport.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        /*[Logged]*/
        [HttpGet]
        [Route("api/transportationfleetRentfarmerrenthistroy/{renterid}")]
        public HttpResponseMessage GetMyTransportastionRentHistoryF(int renterid)
        {
            try
            {
                var data = FarmerTransportationFleetRentService.GetFarmerRentTransportHistory(renterid);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Item not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        /*[Logged]*/
        [HttpGet]
        [Route("api/transportationfleetRent/{id}/{renterid}")]
        public HttpResponseMessage GetMyTransportRentRequestStatusF(int id, int renterid)
        {
            try
            {
                var data = FarmerTransportationFleetRentService.GetOwnRentedTransport(id, renterid);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Item not found" });
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "This Transport Record Does not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You are not Renter of this Transport.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




    }
}
