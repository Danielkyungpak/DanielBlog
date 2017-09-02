using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Requests.DnD
{
    public class MainStatModifiersAddReq
    {
        public int StrengthPlus { get; set; }
        public int DexterityPlus { get; set; }
        public int ConstitutionPlus { get; set; }
        public int IntelligencePlus { get; set; }
        public int WisdomPlus { get; set; }
        public int CharismaPlus { get; set; }
    }
}