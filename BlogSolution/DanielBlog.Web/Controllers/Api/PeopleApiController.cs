using DanielBlog.Web.Models.Domain;
using DanielBlog.Web.Models.Requests;
using DanielBlog.Web.Models.Response;
using DanielBlog.Web.Models.Shared;
using DanielBlog.Web.Models.View;
using DanielBlog.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DanielBlog.Web.Controllers.Api
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
        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetPerson([FromUri] int id)
        {
            PeopleService peopleService = new PeopleService();
            ItemResponse<Person> response = new ItemResponse<Person>();
            response.Item = peopleService.GetPerson(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route(), HttpPost]
        public HttpResponseMessage PersonInsert([FromBody] PersonAddRequest payload)
        {
            PeopleService peopleService = new PeopleService();
            ItemResponse<int> model = new ItemResponse<int>();
            model.Item = peopleService.PersonInsert(payload);
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        [Route(), HttpPut]
        public HttpResponseMessage PersonUpdate([FromBody] PersonUpdateRequest payload)
        {
            PeopleService peopleService = new PeopleService();
            peopleService.PersonUpdate(payload);
            SuccessResponse response = new SuccessResponse();
            response.IsSuccessful = true;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage PersonDelete([FromUri] int id)
        {
            PeopleService peopleService = new PeopleService();
            peopleService.PersonDelete(id);
            SuccessResponse response = new SuccessResponse();
            response.IsSuccessful = true;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }

}
