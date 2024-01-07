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
    public class TraderSellItemController : ApiController
    {
        /*[Logged]*/
        /*[FarmerAccess]*/
        [HttpPost]
        [Route("api/tradersellandcoldstorageitem/create")]
        public HttpResponseMessage Create(List<RequestTableItemDTO> s)
        {
            try
            {
                var data = TraderSellItemService.Add(s);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Item is not Added" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Selling Items are Added Successfully" });
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
                else if (ex.Message == "Request is Already Approved You can not Add More Item.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Your Request Type is not Sell.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while creating Your Request.");
            }
        }


        /*[Logged]*/
        /*[FarmerAccess]*/
        [HttpDelete]
        [Route("api/tradersellandcoldstorageitemdeletesingleitem/{id1}/{userid}")]
        public HttpResponseMessage DeleteMyRequestallItemunderarequest(int id1)
        {
            try
            {
                var isDeleted = TraderSellItemService.Delete(id1);
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
        [Route("api/tradersellandcoldstorageitemupdatemultiple/update")]
        public HttpResponseMessage UpdateMyRequestitem(List<RequestTableItemDTO> s, int userid)
        {
            try
            {
                var data = TraderSellItemService.UpdateData(s, userid);
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
                else if (ex.Message == "Your Request Type is not Sell.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while Updating Your Request.");
            }
        }


        /*[Logged]*/
        [HttpGet]
        [Route("api/tradersellandcoldstorageitemgetitemunderasinglerequest/{requestid}")]
        public HttpResponseMessage GetSellItemListsByaRequestId(int requestid)
        {
            try
            {
                var data = TraderSellItemService.GetAll(requestid);

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
        [Route("api/tradersellandcoldstorageitemgetitbyasingletableid/{id}/{requestid}")]
        public HttpResponseMessage GetSellItemSingleEntryByaRequestIdandId(int Id, int requestid)
        {
            try
            {
                var data = TraderSellItemService.GetSinle(Id, requestid);

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
