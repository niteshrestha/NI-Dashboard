using System.Collections.Generic;

namespace NIDashboard.Models.Banner
{
    public class BannerViewModel
    {
        public IEnumerable<BannerListingModel> Banners { get; set; }
        public ConfigListingModel Config { get; set; }
    }
}
