using NIDashboard.Data.Models;
using System.Threading.Tasks;

namespace NIDashboard.Data
{
    public interface ISliderConfig
    {
        SliderConfig GetSliderConfig();
        Task Save(SliderConfig sliderConfig);
    }
}
