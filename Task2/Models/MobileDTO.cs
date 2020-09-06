using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2.Models
{
    public class MobileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }
        public double ScreenSize { get; set; }
        public string Processor { get; set; }
        public int Memory { get; set; }
        public string OS { get; set; }
        public double Price { get; set; }
        public string VideoThumb { get; set; }
        public List<string> PicThumbs { get; set; }
    }
}
