using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Requests.DnD
{
    public class CharacterDetailsUpdateReq
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public string Background { get; set; }
        public string PlayerName { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }
        public int ExperiencePoints { get; set; }

    }
}