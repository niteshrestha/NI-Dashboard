using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIDashboard.Models.Banner
{
    public class BannerViewModel
    {
        public IEnumerable<BannerListingModel> Banners { get; set; }
        public ConfigListingModel Config { get; set; }
    }
}
