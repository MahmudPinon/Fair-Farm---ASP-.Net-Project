using BLL.DTOs;
using BLL.Services.Trader;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fair_Farm.Controllers.Trader
{
    public class TransportController : ApiController
    {
        [HttpGet]
        [Route("api/transport")]
        public HttpResponseMessage ShowAllTransport()
        {
            try
            {
                var value = TransportService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, value);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpPost]
        [Route("api/addtransport")]
        public HttpResponseMessage AddTransport(TransportationFleetRegisterDTO obj)
        {
            try
            {
                var value = TransportService.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, value);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
