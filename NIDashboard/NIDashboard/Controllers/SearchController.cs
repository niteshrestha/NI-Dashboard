using Microsoft.AspNetCore.Mvc;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using NIDashboard.Data.Models.spModels;
using NIDashboard.Helpers;
using NIDashboard.Models.Post;
using NIDashboard.Models.Search;
using NIDashboard.Models.Section;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NIDashboard.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPost _postService;
        public SearchController(IPost postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Result(string searchQuery, bool searchTag, bool searchContent)
        {
            IEnumerable<SpLatestPost> posts = null;

            if (searchTag && !searchContent)
            {
                posts = _postService.SearchByTag(searchQuery).ToList();
            }
            else if (searchContent && !searchTag)
            {
                posts = _postService.SearchByContent(searchQuery).ToList();
            }
            else
            {
                posts = _postService.Search(searchQuery).ToList();
            }

            var noResult = (!string.IsNullOrEmpty(searchQuery) && !posts.Any());

            TimeDifference td = new TimeDifference();

            var postListing = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = string.Format("{0} {1}", post.FirstName, post.LastName),
                DatePosted = td.PostTimeDifference(post.Created),
                SectionId = post.SectionId,
                SectionTitle = post.SectionTitle
            }).OrderByDescending(post => post.DatePosted);

            var model = new SearchResultModel
            {
                EmptySearchResults = noResult,
                Posts = postListing,
                SearchQuery = searchQuery
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Search(string searchQuery, bool searchTag, bool searchContent)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Result", new { searchQuery, searchTag, searchContent });
        }
    }
}