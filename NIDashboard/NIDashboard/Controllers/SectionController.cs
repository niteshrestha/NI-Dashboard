﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using NIDashboard.Helpers;
using NIDashboard.Models.Post;
using NIDashboard.Models.Section;

namespace NIDashboard.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISection _sectionService;
        private readonly IPost _postService;

        public SectionController(ISection sectionService, IPost postService)
        {
            _sectionService = sectionService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            IEnumerable<SectionListingModel> sections = _sectionService.GetAll()
                .Select(section => new SectionListingModel
                {
                    Id = section.Id,
                    Title = section.Title,
                    Description = section.Description
                });

            var model = new SectionIndexModel
            {
                Sections = sections
            };
            return View(model);
        }

        [Authorize(Roles ="HOD, Teacher")]
        public IActionResult Create()
        {
            var model = new AddSectionModel();
            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var section = _sectionService.GetByID(id);

            var posts = section.Posts;

            TimeDifference td = new TimeDifference();

            var postListing = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                Title = post.Title,
                DatePosted = post.Created.ToString(CultureInfo.InvariantCulture),
                Ago = td.PostTimeDifference(post.Created),
                AuthorName = post.User.FirstName + " " + post.User.LastName,
                Section = BuildSectionListing(post)
            }).OrderByDescending(post => post.DatePosted);

            var model = new SectionTopicModel
            {
                Posts = postListing,
                Section = BuildSectionListing(section)
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var section = _sectionService.GetByID(Id);

            foreach (var posts in section.Posts.ToList())
            {
                await _postService.Delete(posts.Id);
            }

            await _sectionService.Delete(Id);
            return RedirectToAction("Index", "Section");
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

        [HttpPost]
        public async Task<IActionResult> AddSection(AddSectionModel model)
        {
            var section = new Data.Models.Section()
            {
                Title = model.Title,
                Description = model.Description
            };

            await _sectionService.Create(section);
            return RedirectToAction("Index", "Section");
        }
    }
}