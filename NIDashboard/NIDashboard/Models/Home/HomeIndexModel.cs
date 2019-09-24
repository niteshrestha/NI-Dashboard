using NIDashboard.Models.Post;
using System.Collections.Generic;

namespace NIDashboard.Models.Home
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }
        public bool SearchTag { get; set; }
        public bool SearchContent { get; set; }
        public IEnumerable<PostListingModel> LatestPosts { get; set; }
    }
}
