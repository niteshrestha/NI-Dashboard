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

        public async Task Defaut()
        {
            var defaultSliderConfig = new SliderConfig()
            {
                Effect = "fold",
                Slices = 15,
                BoxCols = 8,
                BoxRows = 4,
                AnimSpeed = 500,
                PauseTime = 3000
            };

            _context.Add(defaultSliderConfig);
            await _context.SaveChangesAsync();
        }

        public SliderConfig GetSliderConfig()
        {
            return _context.SliderConfigs.FirstOrDefault();
        }

        public async Task Save(SliderConfig config)
        {
            var sliderConfig = GetSliderConfig();
            sliderConfig.Effect = config.Effect;
            sliderConfig.Slices = config.Slices;
            sliderConfig.BoxCols = config.BoxCols;
            sliderConfig.BoxRows = config.BoxRows;
            sliderConfig.AnimSpeed = config.AnimSpeed;
            sliderConfig.PauseTime = config.PauseTime;
            _context.Update(sliderConfig);
            await _context.SaveChangesAsync();
        }
    }
}
