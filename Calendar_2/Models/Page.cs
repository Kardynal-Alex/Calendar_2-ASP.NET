﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar_2.Models
{
    public class Page
    {
        public int TotalPage { get; set; }
        public Page(int k)
        {
            TotalPage += k;
        }
    }
}
