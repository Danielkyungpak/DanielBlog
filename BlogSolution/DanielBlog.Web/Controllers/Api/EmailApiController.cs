using System;
using System.Collections.Generic;
using DanielBlog.Web.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DanielBlog.Web.Models.Shared;
using DanielBlog.Web.Models.Requests;
using DanielBlog.Web.Models.Response;
using System.Threading.Tasks;

namespace DanielBlog.Web.Controllers.Api
{
    [RoutePrefix("api/email")]
    public class EmailApiController : ApiController
    {
        [Route("contactme"), HttpPost]
        public async Task<HttpResponseMessage> CharacterInsert([FromBody] ContactMeEmailRequest payload)
        {
            try
            {
                SuccessResponse response = new SuccessResponse();
                await Services.EmailService.ContactMe(payload);
                response.IsSuccessful = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Ambiguous, ex.Message);
            }
        }

    }
}
