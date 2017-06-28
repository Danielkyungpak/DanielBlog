using DanielBlog.Web.Models.Requests;
using DanielBlog.Web.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static DanielBlog.Web.Models.Poker.CardLogic;

namespace DanielBlog.Web.Controllers.Api
{
    [RoutePrefix("api/poker")]
    public class PokerApiController : ApiController
    {
        [Route("Deal"), HttpGet]
        public HttpResponseMessage ProcessHand()
        {
            Deck deck = new Deck();
            deck.Shuffle(deck.Cards);
            var cards = deck.DealStandardHand();
            return Request.CreateResponse(HttpStatusCode.OK, cards);

        }
        [Route("Deal"), HttpPost]
        public HttpResponseMessage DealWithHeldCards([FromBody] Card[] payload)
        {
            Deck deck = new Deck();
            List<Card> newDeck = deck.RemoveCards(payload);
            deck.Shuffle(newDeck);
            var cards = deck.DealNonHeldCards(payload);
            return Request.CreateResponse(HttpStatusCode.OK, cards);

        }
    }
}
