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
    public class FarmerColdStorageItemController : ApiController
    {
        /*[Logged]*/
        /*[FarmerAccess]*/
        [HttpPost]
        [Route("api/farmercoldstorageitemF/create")]
        public HttpResponseMessage Create(List<ColdStorageItemListDTO> s)
        {
            try
            {
                var data = FarmerColdStorageItemService.Add(s);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Item is not Added" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Cold Storage Items are Added Successfully" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Emptry List Submitted.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Invalid Request Id is Provided.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You Have Provided Some Empty Field.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Your Request Type is not Cold Storage.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while creating Your Request.");
            }
        }


        /*[Logged]*/
        /*[FarmerAccess]*/
        [HttpDelete]
        [Route("api/farmercoldstorageitemF/{id1}/{userid}")]
        public HttpResponseMessage DeleteMyRequestSingleItem(int id1)
        {
            try
            {
                var isDeleted = FarmerColdStorageItemService.Delete(id1);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Single Item has been Deleted Successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "This Request Does Not Exists in the System." });
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
        [Route("api/farmercoldstorageitemupdatemultipleF/update/{userid}")]
        public HttpResponseMessage UpdateMyColdStorageRequestitem(List<ColdStorageItemListDTO> s, int userid)
        {
            try
            {
                var data = FarmerColdStorageItemService.UpdateData(s, userid);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Data is not Updated" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Request is Updated Successfully" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Emptry List Submitted.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Invalid Request Id is Provided.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You can not Modify Approve Request Data.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You Have Provided Some Empty Field.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Your Request Type is not Cold Storage.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while Updating Your Request.");
            }
        }


        /*[Logged]*/
        [HttpGet]
        [Route("api/farmercoldstorageitemunderasinglerequestF/{requestid}")]
        public HttpResponseMessage GetColdStorageItemListsByaRequestId(int requestid)
        {
            try
            {
                var data = FarmerColdStorageItemService.GetAll(requestid);

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
        [Route("api/farmercoldstorageitemgetitbyasingletableidF/{id}/{requestid}")]
        public HttpResponseMessage GetColdStorageItemSingleEntryByaRequestIdandId(int Id, int requestid)
        {
            try
            {
                var data = FarmerColdStorageItemService.GetSinle(Id, requestid);

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
    }
}
