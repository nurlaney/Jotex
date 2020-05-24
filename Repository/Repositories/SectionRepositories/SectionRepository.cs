using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Contact> GetContacts()
        {
            return _context.Contacts.Include(c => c.Settings).Where(c => c.Status).ToList();
        }

        public Faq GetFaqById(int? id)
        {
            return _context.Faqs.Where(s => s.Status).FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Faq> GetFaqs()
        {
            return _context.Faqs.Where(f => f.Status).ToList();
        }

        //ana sehife newToInsurance Section`u
        public IEnumerable<NewTo> GetNewTo()
        {
            return _context.NewTos.Where(n => n.Status).ToList();
        }
        //ana sehife about
        public IEnumerable<CoveredContact> GetSectionItems()
        {
            return _context.CoveredContacts.Where(c => c.Status).ToList();
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
