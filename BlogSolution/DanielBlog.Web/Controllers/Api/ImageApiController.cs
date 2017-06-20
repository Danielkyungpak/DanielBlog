using DanielBlog.Web.Models.Requests;
using DanielBlog.Web.Models.Response;
using DanielBlog.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DanielBlog.Web.Controllers.Api
{
    [RoutePrefix("api/image")]
    public class ImageApiController : ApiController
    {
        [Route(""), HttpPost]
        public HttpResponseMessage ImageInsert()
        {
            //send request to server
            HttpRequest request = HttpContext.Current.Request;
            //if they did not send an image....return with error message
            if (request.Files.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "no image to upload");
            }

            HttpPostedFile postedFile = request.Files[0];
            AmazonService aws = new AmazonService();
            string newImage = aws.UploadFile(postedFile.InputStream, postedFile.FileName);

            SuccessResponse response = new SuccessResponse();
            response.IsSuccessful = true;
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

    }
}

