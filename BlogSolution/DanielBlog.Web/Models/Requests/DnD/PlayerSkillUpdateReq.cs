using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Requests.DnD
{
    public class PlayerSkillUpdateReq
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int Acrobatics { get; set; }
        public bool AcrobaticsPro { get; set; }
        public int AnimalHandling { get; set; }
        public bool AnimalHandlingPro { get; set; }
        public int Arcana { get; set; }
        public bool ArcanaPro { get; set; }
        public int Athletics { get; set; }
        public bool AthleticsPro { get; set; }
        public int Deception { get; set; }
        public bool DeceptionPro { get; set; }
        public int History { get; set; }
        public bool HistoryPro { get; set; }
        public int Insight { get; set; }
        public bool InsightPro { get; set; }
        public int Intimidation { get; set; }
        public bool IntimidationPro { get; set; }
        public int Investigation { get; set; }
        public bool InvestigationPro { get; set; }
        public int Medicine { get; set; }
        public bool MedicinePro { get; set; }
        public int Nature { get; set; }
        public bool NaturePro { get; set; }
        public int Perception { get; set; }
        public bool PerceptionPro { get; set; }
        public int Performance { get; set; }
        public bool PerformancePro { get; set; }
        public int Persuasion { get; set; }
        public bool PersuasionPro { get; set; }
        public int Religion { get; set; }
        public bool ReligionPro { get; set; }
        public int SleightofHand { get; set; }
        public bool SleightofHandPro { get; set; }
        public int Stealth { get; set; }
        public bool StealthPro { get; set; }
        public int Survival { get; set; }
        public bool SurvivalPro { get; set; }


    }
}