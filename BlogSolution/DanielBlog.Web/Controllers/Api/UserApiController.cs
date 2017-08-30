using DanielBlog.Web.Exceptions;
using DanielBlog.Web.Models.Requests;
using DanielBlog.Web.Models.Response;
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
        // POST: /User/Register
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<HttpResponseMessage> Register(UserRegisterRequest payload)
        {
            try
            {
                UserService service = new UserService();
                IdentityUser user = await service.Register(payload);
                ItemResponse<IdentityUser> response = new ItemResponse<IdentityUser>();
                return Request.CreateResponse(response);

            }
            catch (IdentityResultException ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Result);
            }
        }

        // POST: /User/Login
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public HttpResponseMessage Login(UserLoginRequest payload)
        {
            UserService service = new UserService();
            SuccessResponse response = new SuccessResponse();
            response.IsSuccessful = service.SignIn(payload);
            return Request.CreateResponse(response);

        }
        [Route("Logout")]
        [HttpPost]
        public HttpResponseMessage Logout()
        {
            UserService service = new UserService();
            ItemResponse<bool> response = new ItemResponse<bool>();
            response.Item = service.Logout();
            return Request.CreateResponse(response);
        }
    }
}
