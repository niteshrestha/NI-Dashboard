using Microsoft.AspNetCore.Mvc;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using NIDashboard.Helpers;
using NIDashboard.Models;
using NIDashboard.Models.Home;
using NIDashboard.Models.Post;
using NIDashboard.Models.Section;
using System.Diagnostics;
using System.Linq;

namespace NIDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _postService;
        public HomeController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexModel();
            return View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latestPost = _postService.GetLatestPost(10);
            TimeDifference td = new TimeDifference();

            var posts = latestPost.Select(post => new PostListingModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = string.Format("{0} {1}", post.FirstName, post.LastName),
                DatePosted = td.PostTimeDifference(post.Created),
                SectionId = post.SectionId,
                SectionTitle = post.SectionTitle
            });

            return new HomeIndexModel
            {
                LatestPosts = posts
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
