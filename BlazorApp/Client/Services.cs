﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client
{
    public class ServiceSingleton
    {
        public int Value { get; set; }
    }

    public class ServiceTransient
    {
        public int Value { get; set; }
    }
}
