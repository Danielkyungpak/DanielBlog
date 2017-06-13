using Project.Web.Models.View;
using Project.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Web.Controllers.Api
{
    [RoutePrefix("api/people")]
    public class PeopleApiController : ApiController
    {
        [Route(""), HttpGet]
        public HttpResponseMessage GetPeople()
        {
            PeopleService peopleService = new PeopleService();
            List<Person> peopleList = peopleService.GetPeople();
            return Request.CreateResponse(HttpStatusCode.OK, peopleList);
        }
    }
}
