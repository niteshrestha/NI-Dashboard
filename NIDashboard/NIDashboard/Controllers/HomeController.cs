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
using NIDashboard.Service;

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
            TimeDifference td = new TimeDifference();

            var posts = latestPost.Select(post => new PostListingModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = post.User.FirstName + " " + post.User.LastName,
                DatePosted = td.PostTimeDifference(post.Created),
                Section = GetSectionListingForPost(post)
            });

            return new HomeIndexModel
            {
                LatestPosts = posts
            };
        }

        //private string TimeDiffference(DateTime datePosted)
        //{
        //    TimeSpan ts = DateTime.Now - datePosted;
        //    string result;
        //    if (ts.TotalMinutes < 60)
        //    {
        //        if (ts.TotalMinutes < 1)
        //        {
        //            result = "now.";
        //        }
        //        else if ((int)ts.TotalMinutes == 1)
        //        {
        //            result = "1 minute ago.";
        //        }
        //        else
        //        {
        //            result = ts.Minutes.ToString() + " minutes ago.";
        //        }
        //    }
        //    else if (ts.TotalHours < 24)
        //    {
        //        if ((int)ts.TotalHours == 1)
        //        {
        //            result = "1 hour ago.";
        //        }
        //        else
        //        {
        //            result = ts.Hours.ToString() + " hours ago.";
        //        }
        //    }
        //    else
        //    {
        //        if ((int)ts.TotalDays == 1)
        //        {
        //            result = "1 day ago.";
        //        }
        //        else
        //        {
        //            result = ((int)ts.TotalDays).ToString() + " days ago.";
        //        }
        //    }

        //    return result;
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
