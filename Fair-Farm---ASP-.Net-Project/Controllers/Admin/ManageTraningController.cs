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
    public class ManageTraningController : ApiController
    {

        [Logged]

        [HttpGet]
        [Route("api/training/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = ManageTraningService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);

            }
        }
        [AdminAccess]
        [HttpPost]
        [Route("api/training/create")]
        public HttpResponseMessage Create(TrainingTableDTO s)
        {
            try
            {
                var data = ManageTraningService.Add(s);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Training not created " });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Training created" });


            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);

            }
        }
        [AdminAccess]
        [HttpGet]
        [Route("api/training/{id}")]
        public HttpResponseMessage GetTrainingById(int id)
        {
            try
            {
                var data = ManageTraningService.Get(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Training not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [AdminAccess]
        [HttpPut]
        [Route("api/training/{id}")]
        public HttpResponseMessage UpdateTraining(TrainingTableDTO tr)
        {
            try
            {
                var updatedUser = ManageTraningService.Update(tr);
                if (updatedUser != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Traing updated " });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Training not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [AdminAccess]
        [HttpDelete]
        [Route("api/training/delete/{id}")]
        public HttpResponseMessage DeleteTraining(int id)
        {
            try
            {
                var isDeleted = ManageTraningService.Delete(id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Training deleted successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Training not found" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

    }
}
