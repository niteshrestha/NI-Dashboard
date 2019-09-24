using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using NIDashboard.Helpers;
using NIDashboard.Models.Post;
using NIDashboard.Models.Search;
using NIDashboard.Models.Section;

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
            List<Post> posts = null;

            if (searchTag)
            {
                posts = _postService.SearchByTag(searchQuery).ToList();
            }
            else if (searchContent)
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
                Section = BuildSectionListing(post),
                Title = post.Title,
                DatePosted = post.Created.ToString(CultureInfo.InvariantCulture),
                Ago = td.PostTimeDifference(post.Created),
                AuthorName = post.User.FirstName + " " + post.User.LastName,
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
        public ActionResult Search(string searchQuery, string searchTag, string searchContent)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Result", new { searchQuery, searchTag, searchContent});
        }

        private SectionListingModel BuildSectionListing(Post post)
        {
            var section = post.Section;

            return BuildSectionListing(section);
        }

        private SectionListingModel BuildSectionListing(Section section)
        {
            return new SectionListingModel
            {
                Id = section.Id,
                Title = section.Title,
                Description = section.Description
            };
        }
    }
}