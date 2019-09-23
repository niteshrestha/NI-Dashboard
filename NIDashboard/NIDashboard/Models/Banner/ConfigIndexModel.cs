using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIDashboard.Models.Banner
{
    public class ConfigIndexModel
    {
        IEnumerable<ConfigListingModel> Configs { get; set; }
    }
}
