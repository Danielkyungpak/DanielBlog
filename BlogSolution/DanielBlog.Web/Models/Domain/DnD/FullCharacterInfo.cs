using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Domain.DnD
{
    public class FullCharacterInfo
    {
        public CharacterDetails CharacterDetails { get; set; }
        public MainStats MainStats { get; set; }
        public MainStatModifiers MainStatModifiers { get; set; }
        public Health Health { get; set; }
        public HitDice HitDice { get; set; }
        public DeathSaves DeathSaves { get; set; }
        public PlayerSkill PlayerSkill { get; set; }
    }
}