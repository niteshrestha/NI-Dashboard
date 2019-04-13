using NIDashboard.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIDashboard.Models.Section
{
    public class SectionTopicModel
    {
        public SectionListingModel Section { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}
