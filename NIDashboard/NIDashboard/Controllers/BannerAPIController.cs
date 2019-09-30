using Microsoft.AspNetCore.Mvc;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using System.Collections.Generic;

namespace NIDashboard.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class BannerAPIController : ControllerBase
    {
        private readonly IBanner _bannerService;
        private readonly ISliderConfig _sliderConfigService;
        public BannerAPIController(IBanner bannerService, ISliderConfig sliderConfigService)
        {
            _bannerService = bannerService;
            _sliderConfigService = sliderConfigService;
        }
        [Route("api/getbanner")]
        [HttpGet]
        public IEnumerable<Banner> GetBanners()
        {
            return _bannerService.GetAll();
        }

        [Route("api/getconfig")]
        [HttpGet]
        public SliderConfig GetConfig()
        {
            return _sliderConfigService.GetSliderConfig();
        }
    }
}