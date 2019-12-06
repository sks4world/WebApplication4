﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Country
    {  
        [Key]
        public int id { get; set; }
        public string country_name { get; set; }
    }
}
