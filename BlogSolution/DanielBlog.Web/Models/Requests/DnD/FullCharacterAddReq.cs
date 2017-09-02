using DanielBlog.Web.Models.Domain.DnD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Requests.DnD
{
    public class FullCharacterAddReq
    {
        public CharacterDetailsAddReq CharacterDetails { get; set; }
        public MainStatsAddReq MainStats { get; set; }
        public HealthAddReq Health { get; set; }
        public HitDiceAddReq HitDice { get; set; }
        public DeathSavesAddReq DeathSaves { get; set; }
        public PlayerSkillAddReq PlayerSkill { get; set; }
    }
}