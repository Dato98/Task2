﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task2.Models
{
    public class MobileForm
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public double Size { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double ScreenSize { get; set; }
        [Required]
        public string Processor { get; set; }
        [Required]
        public int Memory { get; set; }
        [Required]
        public string OS { get; set; }
        [Required]
        public double Price { get; set; }
        public IFormFile Video { get; set; }
        public List<IFormFile> Pictures { get; set; }
    }
}
