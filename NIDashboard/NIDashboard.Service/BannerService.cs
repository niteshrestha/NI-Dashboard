using Microsoft.EntityFrameworkCore;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIDashboard.Service
{
    public class BannerService : IBanner
    {
        private readonly ApplicationDbContext _context;
        public BannerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Banner banner)
        {
            _context.Add(banner);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var banner = GetById(id);
            _context.Remove(banner);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Banner> GetAll()
        {
            return _context.Banners;
        }

        public Banner GetById(int id)
        {
            return _context.Banners
                .Where(banner => banner.ID == id)
                .FirstOrDefault();
        }
    }
}
