using BLL.DTOs;
using BLL.Services.Trader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fair_Farm.Controllers.Trader
{
    public class TraderEqupmentRentController : ApiController
    {

        [HttpPost]
        [Route("api/traderequip/create")]
        public HttpResponseMessage Create(EquipmentRentDTO s)
        {
            try
            {
                var data = TraderEqupmentRentService.Add(s);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Equipment Rent Post is not Created" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Equipment Rent Post is Advertise Successfully" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Your Profile Does not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Per day Rent Can not be 0 or Negative Number.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Your Profile Does not Match With the Farmer or Trader.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while Advertise the Equipment For Rent.");
            }
        }

        /*[Logged]*/
        [HttpGet]
        [Route("api/traderequip/{id}")]
        public HttpResponseMessage GetEquipmentRentByIdEquipmentFarmer(int id)
        {
            try
            {
                var data = TraderEqupmentRentService.Get(id);

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
        [Route("api/traderequipregion/{regions}")]
        public HttpResponseMessage GetEquipmentRentByRegion(string regions)
        {
            try
            {
                var data = TraderEqupmentRentService.GetByRegion(regions);

                if (data.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no Record of this Region" });
                }
                else if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Item not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }


        /*[Logged]*/
        [HttpGet]
        [Route("api/traderequiprent/{id}/{renterid}")]
        public HttpResponseMessage GetMyRentRequestStatus(int id, int renterid)
        {
            try
            {
                var data = TraderEqupmentRentService.GetOwnRequestStatus(id, renterid);

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
                if (ex.Message == "This Equpment Does not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You are not Renter of this Eqipment.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Invalid Request.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /*[Logged]*/
        [HttpGet]
        [Route("api/traderequiprentadvertise/{ownerid}")]
        public HttpResponseMessage GetMyAdvertiseEquipmentsRequestStatus(int ownerid)
        {
            try
            {
                var data = TraderEqupmentRentService.GetRentRequestsofMyAdvertise(ownerid);

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



        [HttpPut]
        [Route("api/equiprenttouser/{renteruserid}/{equipmentid}")]
        public HttpResponseMessage RentRequestDataFromUser(int renteruserid, int equipmentid)
        {
            try
            {
                var data = TraderEqupmentRentService.UpdateforMyRentRequest(renteruserid, equipmentid);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Request Has been Posted" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Requested Data not found" });
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "You are not a Registered User in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Equpment Does not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You Can not Rent Your Equipment.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "This Equpment Does not Belongs to Your Region.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "This Equpment is Already Rented.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You have Already Requested for this Equpment.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Another User is Already Requested For the Equipment Please Try Another.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [HttpPut]
        [Route("api/equipmentrenttrader/{id}/{ownerid}")]
        public HttpResponseMessage UpdateMyEquipments(int id, int ownerid, EquipmentRentDTO s)
        {
            try
            {
                var data = TraderEqupmentRentService.UpdatebyEqupmentOwner(id, ownerid, s);
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
                if (ex.Message == "You are not a Registered User in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Equpment Does not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You are not Owner of the Equipment.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You Can not Update the Region.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "This Equipment is Rented You can not Modify it.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You are Providing Invalid Rent Status.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpDelete]
        [Route("api/traderrentdelete/{id}/{ownerid}")]
        public HttpResponseMessage DeletePlantingCalender(int id, int ownerid)
        {
            try
            {
                var isDeleted = TraderEqupmentRentService.Delete(id, ownerid);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Advertised Equipment has been Deleted Successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Your Advertised Equipment not found" });
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "This Equipment Does Not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Your Profile Does not Match With This Eqipment Owner.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You can not Delete a Rented Equipment.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpGet]
        [Route("api/renthitory/{id}")]
        public HttpResponseMessage UserRentRelatedHistory(int id)
        {
            try
            {
                var data = TraderEqupmentRentService.GetRentRelatedHistory(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                if (ex.Message == "Invalid Access to the Equipment Rent Data.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You Do not Have Any Data in the Equipment Rent.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

