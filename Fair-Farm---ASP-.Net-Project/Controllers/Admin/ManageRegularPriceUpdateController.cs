using BLL.DTOs;
using BLL.Services.Admin;
using Fair_Farm.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fair_Farm.Controllers.Admin
{
    public class ManageRegularPriceUpdateController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("api/RegularPrice/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = ManageRegularPriceUpdateService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);

            }
        }
        [AdminAccess]
        [HttpPost]
        [Route("api/RegularPrice/create")]
        public HttpResponseMessage Create(RegularPriceUpdateDTO s)
        {
            try
            {
                var data = ManageRegularPriceUpdateService.Add(s);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Regular price not created" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Regular Price created" });


            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);

            }
        }

        [Logged]
        [HttpGet]
        [Route("api/RegularPrice/{id}")]
        public HttpResponseMessage GetRegularPriceById(int id)
        {
            try
            {
                var data = ManageRegularPriceUpdateService.Get(id);

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

        [Logged]
        [HttpPut]
        [Route("api/RegularPrice/{id}")]
        public HttpResponseMessage UpdateRegularPrice(RegularPriceUpdateDTO price)
        {
            try
            {
                var data = ManageRegularPriceUpdateService.Update(price);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Price updated " });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "item not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [AdminAccess]
        [HttpDelete]
        [Route("api/RegularPrice/{id}")]
        public HttpResponseMessage DeleteRegularPrice(int id)
        {
            try
            {
                var isDeleted = ManageRegularPriceUpdateService.Delete(id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Regular price deleted successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "item not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }




    }
}
