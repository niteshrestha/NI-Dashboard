using NIDashboard.Data.Models;
using NIDashboard.Data.Models.spModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NIDashboard.Data
{
    public interface ISection
    {
        IEnumerable<SpSectionWithPost> GetByID(int id);
        Section GetSection(int id);
        IEnumerable<Section> GetAll();

        Task Create(Section section);
        Task Delete(int Id);
    }
}
