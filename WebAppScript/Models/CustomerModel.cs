﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppScript.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
    }
}