using Microsoft.EntityFrameworkCore;
using NIDashboard.Data;
using NIDashboard.Data.Models;
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
            _context.Database.ExecuteSqlCommand("spCreateSection @p0, @p1",
                parameters: new[] { section.Title, section.Description });
        }

        public async Task Delete(int Id)
        {
            _context.Database.ExecuteSqlCommand("spDeleteSection @p0", Id);
        }

        public IEnumerable<Section> GetAll()
        {
            return _context.Sections.FromSql("spGetSections");
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
    }
}
