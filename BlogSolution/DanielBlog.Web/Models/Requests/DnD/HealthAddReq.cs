﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Requests.DnD
{
    public class HealthAddReq
    {
        public int CharacterId { get; set; }
        public int MaxHealth { get; set; }
        public int TempHealth { get; set; }
        public int CurrentHealth { get; set; }
    }
}