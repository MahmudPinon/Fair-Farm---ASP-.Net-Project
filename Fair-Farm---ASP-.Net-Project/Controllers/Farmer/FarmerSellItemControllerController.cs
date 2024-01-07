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
    public class FarmerSellItemControllerController : ApiController
    {
        /*[Logged]*/
        /*[FarmerAccess]*/
        /*[HttpPost]
        [Route("api/farmersellandcoldstorageitem/create")]
        public HttpResponseMessage Create(List<RequestTableItemDTO> s)
        {
            try
            {
                var data = FarmerSellItemService.Add(s);
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
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while creating Your Request.");
            }
        }


        /*[Logged]*/
        /*[FarmerAccess]*/
        /*[HttpDelete]
        [Route("api/farmersellandcoldstorageitemdeletesingleitem/{id1}/{userid}")]
        public HttpResponseMessage DeleteMyRequestSingleItem(int id1)
        {
            try
            {
                var isDeleted = FarmerSellItemService.Delete(id1);
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
        }*/

        /*[Logged]*/
        /*[FarmerAccess]*/
       /* [HttpPut]
        [Route("api/farmersellandcoldstorageitemdeletesingleitemupdate/update")]
        public HttpResponseMessage UpdateMyRequest(List<RequestTableItemDTO> s, int userid)
        {
            try
            {
                var data = FarmerSellItemService.UpdateData(s, userid);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Data is not Updated" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Request is Updated Successfully" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "This Request Does Not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "This User Does Not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You are not Owner of this Request.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "In-Appropriate Request Type.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "You can Update this Request.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while Updating Your Request.");
            }
        }*/




    }
}
