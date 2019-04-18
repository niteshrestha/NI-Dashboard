using Microsoft.EntityFrameworkCore;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Delete(int Id)
        {
            var section = GetByID(Id);
            _context.Remove(section);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Section> GetAll()
        {
            return _context.Sections
                .Include(section => section.Posts);
        }

        public Section GetByID(int id)
        {
            var section = _context.Sections
                .Where(s => s.Id == id)
                .Include(s => s.Posts)
                .ThenInclude(p => p.User)
                .FirstOrDefault();

            return section;
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
