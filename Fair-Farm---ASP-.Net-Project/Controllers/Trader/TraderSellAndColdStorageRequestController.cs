﻿using BLL.DTOs;
using BLL.Services.Trader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fair_Farm.Controllers.Trader
{
    public class TraderSellAndColdStorageRequestController : ApiController
    {
        /*[Logged]*/
        /*[FarmerAccess]*/
        [HttpPost]
        [Route("api/tradersellandcoldstoragerequest/create")]
        public HttpResponseMessage Create(RequestTableDTO s)
        {
            try
            {
                var data = TraderSellandColdStorageRequestService.Add(s);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Request is not Created" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Request is Created Successfully" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Your Profile Does not Exists in the System.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                else if (ex.Message == "Invalid Request Type.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while creating Your Request.");
            }
        }


        /*[Logged]*/
        [HttpGet]
        [Route("api/traderRequestTableDatabyUserIdandsingleResendData/{userid}")]
        public HttpResponseMessage GetRequestTableByUserIdandRecent(int userid)
        {
            try
            {
                var data = TraderSellandColdStorageRequestService.GetSinlebyUserId(userid);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No Data Found" });
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
        [Route("api/tradersellandcoldstoragerequestupupdate/{userid}")]
        public HttpResponseMessage UpdateMyRequest(RequestTableDTO s, int userid)
        {
            try
            {
                var data = TraderSellandColdStorageRequestService.Update(s, userid);
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
                else if (ex.Message == "You can not Update this Request.")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while Updating Your Request.");
            }
        }


        /*[Logged]*/
        /*[FarmerAccess]*/
        [HttpDelete]
        [Route("api/tradersellandcoldstoragerequestdelete/{id1}/{userid}")]
        public HttpResponseMessage DeleteMyRequest(int id1, int userid)
        {
            try
            {
                var isDeleted = TraderSellandColdStorageRequestService.Delete(id1, userid);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Your Request has been Deleted Successfully." });
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
        [HttpGet]
        [Route("api/traderrequesttabledatabyuseridandspecifictype/{userid}/{type}")]
        public HttpResponseMessage GetFarmerRequestTableDatabyTypeofRequestandUserId(int userid, string type)
        {
            try
            {
                var data = TraderSellandColdStorageRequestService.Get(userid, type);

                if (data.Count != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No Data Found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

    }
}
