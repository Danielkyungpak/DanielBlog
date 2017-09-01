using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Domain.DnD
{
    public class MainStats
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int ProficiencyBonus { get; set; }
        public bool Inspiration { get; set; }
    }
}