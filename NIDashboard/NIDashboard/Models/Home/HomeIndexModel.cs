using NIDashboard.Models.Post;
using System.Collections.Generic;

namespace NIDashboard.Models.Home
{
    public class HomeIndexModel
    {
        public IEnumerable<PostListingModel> LatestPosts { get; set; }
    }
}
