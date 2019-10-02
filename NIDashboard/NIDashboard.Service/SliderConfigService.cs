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

        public SliderConfig GetSliderConfig()
        {
            return _context.SliderConfigs.FirstOrDefault();
        }

        public async Task Save(SliderConfig config)
        {
            var sliderConfig = new SliderConfig
            {
                Effect = config.Effect,
                Slices = config.Slices,
                BoxCols = config.BoxCols,
                BoxRows = config.BoxRows,
                AnimSpeed = config.AnimSpeed,
                PauseTime = config.PauseTime
            };
            _context.Update(sliderConfig);
            await _context.SaveChangesAsync();
        }
    }
}
