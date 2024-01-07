using BLL.Services.Trader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fair_Farm.Controllers.Trader
{
    public class TraderShowRedListControllerController : ApiController
    {
        [HttpGet]
        [Route("api/TraderShowlistedusers/{region}/{type}")]
        public HttpResponseMessage GetRedListedUserListsbyFarmer(string region, string type)
        {
            try
            {
                var data = TraderShowRedListService.GetRedListedUserbyTraderandbyRegion(region, type);
                if (data.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is No User in the RedList" });
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
        [Route("api/Traderaccessredlistedbyid/{id}/{type}")]
        public HttpResponseMessage GetRedListedSingleUsersbyFarmer(int id, string type)
        {
            try
            {
                var data = TraderShowRedListService.GetRedListedUserbyFarmerandbyId(id, type);

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

