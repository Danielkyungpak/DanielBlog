using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Domain.DnD
{
    public class DeathSaves
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int Successes { get; set; }
        public int Failures { get; set; }
    }
}