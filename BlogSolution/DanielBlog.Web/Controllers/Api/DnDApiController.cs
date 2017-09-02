using DanielBlog.Web.Models.Domain.DnD;
using DanielBlog.Web.Models.Requests.DnD;
using DanielBlog.Web.Models.Shared;
using DanielBlog.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DanielBlog.Web.Controllers.Api
{
    [RoutePrefix("api/dnd")]
    public class DnDApiController : ApiController
    {
        //Routes


        //Character Detail GetAllCharacters

        //Character Detail GetById

        //MainStats GetByCharacterId

        //MainStats Update

        //Health GetByCharacterId

        //Health Update


        //HitDice GetByCharacterId

        //HitDice Update

        //DeathSaves GetByCharacterId

        //DeathSaves Update


        //Skill Specialty GetByCharacterId

        //Skill Specialty Update


        //Creation of Character Full Db Call
        [Route("character"), HttpPost]
        public HttpResponseMessage CharacterInsert([FromBody] FullCharacterAddReq payload)
        {
            DnDService dndService = new DnDService();
            ItemResponse<bool> model = new ItemResponse<bool>();
            model.Item = dndService.FullCharacterInsert(payload);
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        //Get Full Character Information with Modifiers 
    }
}
