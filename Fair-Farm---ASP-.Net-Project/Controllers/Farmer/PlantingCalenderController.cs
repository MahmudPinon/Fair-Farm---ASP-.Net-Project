using BLL.DTOs;
using BLL.Services.Admin;
using BLL.Services.Farmer;
using Fair_Farm.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fair_Farm.Controllers.Farmer
{
    public class PlantingCalenderController : ApiController
    {
        /*[Logged]*/
        [HttpGet]
        [Route("api/PlantingCalender/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = FarmerPlantingCalenderService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);

            }
        }

        /*[Logged]*/
        /*[FarmerAccess]*/
        [HttpPost]
        [Route("api/PlantingCalender/create")]
        public HttpResponseMessage Create(PlantingCalendarDTO s)
        {
            try
            {
                var data = FarmerPlantingCalenderService.Add(s);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Planting Calender is not Created" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Planting Calender is Created Successfully" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Entry with similar characteristics already exists from your Profile.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                /*else if (ex.Message == "Your Profile Region Does not Match With the Planting Calender Region.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }*/
                else if (ex.Message == "Your Profile Does not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Your Profile Does not Match With the Farmer.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while creating the planting calendar.");
            }
        }

        /*[Logged]*/
        [HttpGet]
        [Route("api/PlantingCalender/{id}")]
        public HttpResponseMessage GetPlantingCalenderById(int id)
        {
            try
            {
                var data = FarmerPlantingCalenderService.Get(id);

                if (data != null)
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
        /*[FarmerAccess]*/
        [HttpPut]
        [Route("api/PlantingCalender/{id}")]
        public HttpResponseMessage UpdatePlantingCalenderData(PlantingCalendarDTO updata, int id)
        {
            try
            {
                var data = FarmerPlantingCalenderService.Update(updata, id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Calender updated " });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Your Calender For the item not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
        /*[Logged]*/
        /*[FarmerAccess]*/
        [HttpDelete]
        [Route("api/PlantingCalender/{id1}/{id2}")]
        public HttpResponseMessage DeletePlantingCalender(int id1, int id2)
        {
            try
            {
                var isDeleted = FarmerPlantingCalenderService.Delete(id1, id2);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Planting Calender deleted successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Your Planting Calender item not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }


        /*[Logged]*/
        [HttpGet]
        [Route("api/PlantingCalendermycrops/{id}")]
        public HttpResponseMessage UserWithCalenderCrops(int id)
        {
            try
            {
                var data = FarmerPlantingCalenderService.GetwithCalenderCrops(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                if (ex.Message == "Invalid Access to the Planting Calender Data.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
