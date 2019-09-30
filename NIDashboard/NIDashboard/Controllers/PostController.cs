using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using NIDashboard.Helpers;
using NIDashboard.Models.Post;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NIDashboard.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly ISection _sectionService;
        private static UserManager<ApplicationUser> _userManager;
        private readonly IPostFormatter _postFormatter;
        private readonly IHostingEnvironment _environment;

        public PostController(IPost postService,
            ISection sectionService,
            UserManager<ApplicationUser> userManager,
            IPostFormatter postFormatter,
            IHostingEnvironment environment)
        {
            _postService = postService;
            _sectionService = sectionService;
            _userManager = userManager;
            _postFormatter = postFormatter;
            _environment = environment;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            string tags = post.Tags;
            string[] stringTags = tags.Split(',');
            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                PostContent = _postFormatter.FormatContent(post.Content),
                Tags = stringTags,
                AuthorName = post.User.FirstName + " " + post.User.LastName,
                Created = post.Created,
                SectionName = post.Section.Title,
                SectionId = post.Section.Id
            };

            return View(model);
        }

        [Authorize(Roles = "HOD, Teacher")]
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

        [Authorize(Roles = "HOD, Teacher")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _postService.Delete(Id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var post = BuildPost(model, user);

            await _postService.Add(post);
            return RedirectToAction("Index", "Post", new { id = post.Id });
        }

        private Post BuildPost(NewPostModel model, ApplicationUser user)
        {
            var section = _sectionService.GetByID(model.SectionId);
            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Tags = model.Tags,
                Created = DateTime.Now,
                User = user,
                Section = section
            };
        }

        [HttpPost]
        public ActionResult UploadImage(IFormFile upload)
        {
            string fileName = "";
            string url = "";
            if (upload.Length <= 0)
            {
                return null;
            }

            var file = upload;
            var uploads = Path.Combine(_environment.WebRootPath, "post");
            if (file.Length > 0)
            {
                fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                {
                    file.CopyToAsync(fileStream).Wait();
                }
                url = $"{"/post/"}{fileName}";
            }

            var successMessage = "image is uploaded successfully";
            dynamic success = JsonConvert.DeserializeObject("{ 'uploaded': 1,'fileName': \"" + fileName + "\",'url': \"" + url + "\", 'error': { 'message': \"" + successMessage + "\"}}");
            return Json(success);
        }
    }
}