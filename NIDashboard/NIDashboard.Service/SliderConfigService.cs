using Microsoft.EntityFrameworkCore;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NIDashboard.Service
{
    public class SliderConfigService : ISliderConfig
    {
        private readonly ApplicationDbContext _context;
        public SliderConfigService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DefaultConfig()
        {
            _context.Database.ExecuteSqlCommand($"spDefaultSliderConfig 500, 8, 4, fade, 3000, 15");
        }

        public SliderConfig GetSliderConfig()
        {
            return _context.SliderConfigs.FromSql("spGetSliderConfig").FirstOrDefault();
        }

        public async Task Save(SliderConfig config)
        {
            var sliderConfig = GetSliderConfig();
            _context.Database.ExecuteSqlCommand($"spSaveSliderConfig {config.AnimSpeed}, {config.BoxCols}, {config.BoxRows}, {config.Effect}, {config.PauseTime}, {config.Slices}, {sliderConfig.ID}");
        }
    }
}
