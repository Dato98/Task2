using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class MobilePictures
    {
        public int Id { get; set; }
        public int MobileId { get; set; }
        public string Thumb { get; set; }
        public Mobile Mobile { get; set; }
    }
}
