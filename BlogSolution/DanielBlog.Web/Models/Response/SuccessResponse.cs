﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Response
{
    public class SuccessResponse
    {
        public string Response { get; set; }
        public bool IsSuccessful { get; set; }
    }
}