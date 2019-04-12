using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _context;
        public SectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Section section)
        {
            _context.Add(section);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int sectionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Section> GetAll()
        {
            return _context.Sections
                .Include(section => section.Posts);
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
