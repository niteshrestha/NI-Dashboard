using System;
using System.Collections.Generic;
using System.Text;

namespace NIDashboard.Data.Models
{
    public class SliderConfig
    {
        public int ID { get; set; }
        public string Effect { get; set; }
        public int Slices { get; set; }
        public int BoxCols { get; set; }
        public int BoxRows { get; set; }
        public int AnimSpeed { get; set; }
        public int PauseTime { get; set; }
        //public string DirectionNav { get; set; }
        //public string ControlNav { get; set; }
        //public string PauseOnHover { get; set; }
        //public string ManulaAdvance { get; set; }
        //public string PrevText { get; set; }
        //public string NextText { get; set; }
        //public string RandomStart { get; set; }
    }
}
