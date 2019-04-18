using NIDashboard.Models.Post;
using System.Collections.Generic;

namespace NIDashboard.Models.Section
{
    public class SectionTopicModel
    {
        public SectionListingModel Section { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}
