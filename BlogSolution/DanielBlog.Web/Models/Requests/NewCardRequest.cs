using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static DanielBlog.Web.Models.Poker.CardLogic;

namespace DanielBlog.Web.Models.Requests
{
    public class NewCardRequest
    {
        public Card Card { get; set; }
    }
}