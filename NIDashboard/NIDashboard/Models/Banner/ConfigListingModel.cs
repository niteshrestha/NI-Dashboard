using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIDashboard.Models.Banner
{
    public class ConfigListingModel
    {
        public string Effect { get; set; }
        public int Slices { get; set; }
        public int BoxCols { get; set; }
        public int BoxRows { get; set; }
        public int AnimSpeed { get; set; }
        public int PauseTime { get; set; }
    }
}
