using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.SectionRepositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly JotexDbContext _context;
        public SectionRepository(JotexDbContext context)
        {
            _context = context;
        }

        //partnerler
        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.OrderByDescending(b => b.AddedDate).ToList();
        }

        //ana sehife slider
        public IEnumerable<SliderItem> GetSliderItems()
        {
            return _context.SliderItems.Where(s => s.Status).ToList();
        }

        //testimonials
        public IEnumerable<Testimonial> GetTestimonials()
        {
            return _context.Testimonials.Where(t => t.Status).ToList();
        }
    }
}
