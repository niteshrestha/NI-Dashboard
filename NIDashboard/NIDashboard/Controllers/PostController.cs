using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using NIDashboard.Models.Post;

namespace NIDashboard.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly ISection _sectionService;
        private static UserManager<ApplicationUser> _userManager;

        public PostController(IPost postService, ISection sectionService, UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _sectionService = sectionService;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                PostContent = post.Content,
                AuthorName = post.User.FirstName + " " + post.User.LastName,
                Created = post.Created,
                SectionName = post.Section.Title,
                SectionId = post.Section.Id
            };

            return View(model);
        }
        [Authorize(Roles ="HOD, Teacher")]
        public IActionResult Create(int id)
        {
            //id is SectionId
            var section = _sectionService.GetByID(id);

            var model = new NewPostModel
            {
                SectionName = section.Title,
                SectionId = section.Id,
                AuthorName = User.Identity.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;
            var post = BuildPost(model, user);

            _postService.Add(post).Wait();

            return RedirectToAction("Index", "Post", new { id = post.Id });
        }

        private Post BuildPost(NewPostModel model, ApplicationUser user)
        {
            var section = _sectionService.GetByID(model.SectionId);
            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                User = user,
                Section = section
            };
        }
    }
}