using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIDashboard.Models.Banner
{
    public class BannerIndexModel
    {
        public IEnumerable<BannerListingModel> Banners { get; set; }
    }
}
