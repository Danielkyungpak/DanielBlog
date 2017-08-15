using DanielBlog.Web.Models.Requests;
using DanielBlog.Web.Models.Shared;
using DanielBlog.Web.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DanielBlog.Web.Controllers.Api
{
    [RoutePrefix("api/user")]
    public class UserApiController : ApiController
    {
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<HttpResponseMessage> Register(UserRegisterRequest payload)
        {
            UserService service = new UserService();
            ItemResponse<int> response = new ItemResponse<int>();
            IdentityUser user = await service.Register(payload);
            return Request.CreateResponse(response);

        }
    }
}
