using NIDashboard.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NIDashboard.Data
{
    public interface ISection
    {
        Section GetByID(int id);
        IEnumerable<Section> GetAll();

        Task Create(Section section);
        Task Delete(int sectionId);
        Task UpdateSectionTitle(int sectionId, string newSectionTitle);
        Task UpdateSectionDescription(int sectionId, string newSectionDescription);
    }
}
