using NIDashboard.Data;
using NIDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NIDashboard.Service
{
    public class SectionService : ISection
    {
        public Task Create(Section section)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int sectionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Section> GetAll()
        {
            throw new NotImplementedException();
        }

        public Section GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSectionDescription(int sectionId, string newSectionDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSectionTitle(int sectionId, string newSectionTitle)
        {
            throw new NotImplementedException();
        }
    }
}
