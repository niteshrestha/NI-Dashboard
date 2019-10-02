using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using NIDashboard.Models.Banner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NIDashboard.Controllers
{
    public class BannerController : Controller
    {
        private readonly IBanner _bannerService;
        private readonly IHostingEnvironment _environment;
        private readonly ISliderConfig _sliderConfigService;

        public BannerController(IBanner bannerService, IHostingEnvironment environment, ISliderConfig sliderConfig)
        {
            _bannerService = bannerService;
            _environment = environment;
            _sliderConfigService = sliderConfig;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "HOD")]
        public IActionResult List()
        {
            IEnumerable<BannerListingModel> banners = _bannerService.GetAll()
               .Select(banner => new BannerListingModel
               {
                   Name = banner.Name,
                   ID = banner.ID
               });

            var model = new BannerIndexModel
            {
                Banners = banners
            };

            return View(model);
        }

        [Authorize(Roles = "HOD")]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = "HOD")]
        public IActionResult Setting()
        {
            var config = _sliderConfigService.GetSliderConfig();
            if (config == null)
            {
                _sliderConfigService.Defaut();
            }
            config = _sliderConfigService.GetSliderConfig();

            var model = new SliderConfig
            {
                Effect = config.Effect,
                Slices = config.Slices,
                BoxCols = config.BoxCols,
                BoxRows = config.BoxRows,
                AnimSpeed = config.AnimSpeed,
                PauseTime = config.PauseTime
            };
            return View(model);
        }
        [Authorize(Roles = "HOD")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _bannerService.Delete(Id);
            return RedirectToAction("Index", "Banner");
        }

        [HttpPost]
        public async Task<IActionResult> AddBanner()
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;

                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;
                        var uploads = Path.Combine(_environment.WebRootPath, "banners");
                        if (file.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                            var banner = new Banner()
                            {
                                Name = fileName
                            };
                            await _bannerService.Add(banner);
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Banner");

        }

        [HttpPost]
        public async Task<IActionResult> SaveConfig(ConfigListingModel model)
        {
            var config = new SliderConfig
            {
                Effect = model.Effect,
                Slices = model.Slices,
                BoxCols = model.BoxCols,
                BoxRows = model.BoxRows,
                AnimSpeed = model.AnimSpeed,
                PauseTime = model.PauseTime
            };

            await _sliderConfigService.Save(config);

            return RedirectToAction("Index", "Banner");
        }
    }
}