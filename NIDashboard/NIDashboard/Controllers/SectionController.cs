using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NIDashboard.Data;
using NIDashboard.Models.Section;

namespace NIDashboard.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISection _sectionService;

        public SectionController(ISection sectionService)
        {
            _sectionService = sectionService;
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