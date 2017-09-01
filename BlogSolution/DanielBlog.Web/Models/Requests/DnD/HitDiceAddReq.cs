﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Requests.DnD
{
    public class HitDiceAddReq
    {
        public int CharacterId { get; set; }
        public int D4 { get; set; }
        public int D6 { get; set; }
        public int D8 { get; set; }
        public int D10 { get; set; }
        public int D12 { get; set; }

    }
}