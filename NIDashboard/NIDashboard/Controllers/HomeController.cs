using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using NIDashboard.Models;
using NIDashboard.Models.Home;
using NIDashboard.Models.Post;
using NIDashboard.Models.Section;

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

        private SectionListingModel GetSectionListingForPost(Post post)
        {
            var section = post.Section;

            return new SectionListingModel
            {
                Title = section.Title,
                Id = section.Id
            };
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latestPost = _postService.GetLatestPost(10);

            var posts = latestPost.Select(post => new PostListingModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = post.User.FirstName + " " + post.User.LastName,
                DatePosted = post.Created.ToString(),
                Section = GetSectionListingForPost(post)
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
