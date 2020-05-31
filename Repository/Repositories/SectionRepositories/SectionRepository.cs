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

        public Brand CreateBrand(Brand model)
        {
            model.AddedDate = DateTime.Now;
            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public Faq CreateFaq(Faq model)
        {
            model.AddedDate = DateTime.Now;
            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public SliderItem CreateSLiderItem(SliderItem model)
        {
            model.AddedDate = DateTime.Now;
            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public Testimonial CreateTestimonail(Testimonial model)
        {
            model.AddedDate = DateTime.Now;

            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public void DeleteBrand(Brand brand)
        {
            _context.Remove(brand);
            _context.SaveChanges();
        }

        public void DeleteFaq(Faq faq)
        {
            _context.Remove(faq);
            _context.SaveChanges();
        }

        public void DeleteSLiderItem(SliderItem sliderItem)
        {
            _context.Remove(sliderItem);
            _context.SaveChanges();
        }

        public void DeleteTestimonial(Testimonial testimonial)
        {
            _context.Remove(testimonial);
            _context.SaveChanges();
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _context.Brands.OrderByDescending(b => b.AddedDate).ToList();
        }

        public IEnumerable<Contact> GetAllContact()
        {
            return _context.Contacts.OrderByDescending(c => c.AddedDate).ToList();
        }

        public IEnumerable<CoveredContact> GetAllCovereds()
        {
            return _context.CoveredContacts.OrderByDescending(c => c.AddedDate).ToList();
        }

        public IEnumerable<Faq> GetAllFaqs()
        {
            return _context.Faqs.OrderByDescending(f => f.AddedDate).ToList();
        }

        public IEnumerable<LikeableArea> GetAllLikeableArea()
        {
            return _context.LikeableAreas.OrderByDescending(l => l.AddedDate).ToList();
        }

        public IEnumerable<NewTo> GetAllNewTo()
        {
            return _context.NewTos.OrderByDescending(n => n.AddedDate).ToList();
        }

        public IEnumerable<SliderItem> GetAllSliderItems()
        {
            return _context.SliderItems.OrderByDescending(s => s.AddedDate).ToList();
        }

        public IEnumerable<Testimonial> GetAllTestimonials()
        {
            return _context.Testimonials.OrderByDescending(t => t.AddedDate).ToList();
        }

        public Brand GetBrandById(int? id)
        {
            return _context.Brands.OrderByDescending(b => b.AddedDate).FirstOrDefault(b => b.Id == id);
        }

        //partnerler
        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.OrderByDescending(b => b.AddedDate).ToList();
        }

        public Contact GetContactById(int id)
        {
            return _context.Contacts.OrderByDescending(c => c.AddedDate).FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _context.Contacts.Include(c => c.Settings).Where(c => c.Status).ToList();
        }

        public CoveredContact GetCoveredById(int? id)
        {
            return _context.CoveredContacts.OrderByDescending(c => c.AddedDate).FirstOrDefault(c => c.Id == id);
        }

        public Faq GetFaqById(int? id)
        {
            return _context.Faqs.Where(s => s.Status).FirstOrDefault(s => s.Id == id);
        }

        public Faq GetFaqById(int id)
        {
            return _context.Faqs.OrderByDescending(f => f.AddedDate).FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Faq> GetFaqs()
        {
            return _context.Faqs.Where(f => f.Status).ToList();
        }

        public LikeableArea GetLikeableAreaById(int? id)
        {
            return _context.LikeableAreas.OrderByDescending(l => l.AddedDate).FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<LikeableArea> GetLikeableAreas()
        {
            return _context.LikeableAreas.Where(n => n.Status).ToList();
        }

        //ana sehife newToInsurance Section`u
        public IEnumerable<NewTo> GetNewTo()
        {
            return _context.NewTos.Where(n => n.Status).ToList();
        }

        public NewTo GetNewToById(int? id)
        {
            return _context.NewTos.OrderByDescending(n => n.AddedDate).FirstOrDefault(n => n.Id == id);
        }

        //ana sehife about
        public IEnumerable<CoveredContact> GetSectionItems()
        {
            return _context.CoveredContacts.Where(c => c.Status).ToList();
        }

        public SliderItem GetSliderItemById(int? id)
        {
            return _context.SliderItems.OrderByDescending(s => s.AddedDate).FirstOrDefault(s => s.Id == id);
        }

        //ana sehife slider
        public IEnumerable<SliderItem> GetSliderItems()
        {
            return _context.SliderItems.Where(s => s.Status).ToList();
        }

        public Testimonial GetTestimonialById(int id)
        {
            return _context.Testimonials.OrderByDescending(t => t.AddedDate).FirstOrDefault(t => t.Id == id);
        }

        //testimonials
        public IEnumerable<Testimonial> GetTestimonials()
        {
            return _context.Testimonials.Where(t => t.Status).ToList();
        }

        public Brand RemoveBrandPhoto(int? id)
        {
            var brand = _context.Brands.FirstOrDefault(s => s.Id == id);

            brand.Logo = null;

            _context.SaveChanges();

            return brand;
        }

        public LikeableArea RemovePhoto(int? id)
        {
            var likeableArea = _context.LikeableAreas.FirstOrDefault(s => s.Id == id);

            likeableArea.Image = null;

            _context.SaveChanges();

            return likeableArea;
        }

        public CoveredContact RemovePhoto1(int? id)
        {
            var covered = _context.CoveredContacts.FirstOrDefault(s => s.Id == id);

            covered.Image = null;

            _context.SaveChanges();

            return covered;
        }

        public SliderItem RemoveSLiderPhoto(int? id)
        {
            var sliderItem = _context.SliderItems.FirstOrDefault(s => s.Id == id);

            sliderItem.Image = null;

            _context.SaveChanges();

            return sliderItem;
        }

        public NewTo RmovePhoto(int? id)
        {
            var newto = _context.NewTos.FirstOrDefault(s => s.Id == id);

            newto.Image = null;

            _context.SaveChanges();

            return newto;
        }

        public void UpdateBrand(Brand brandToUpdate, Brand brand)
        {
            brandToUpdate.ModifiedDate = DateTime.Now;
            brandToUpdate.Status = brand.Status;
            brandToUpdate.Name = brand.Name;

            _context.SaveChanges();
        }

        public void UpdateConact(Contact contactToUpdate, Contact contact)
        {
            contactToUpdate.ModifiedDate = DateTime.Now;
            contactToUpdate.Status = contact.Status;
            contactToUpdate.Title = contact.Title;
            contactToUpdate.Description = contact.Description;
            contactToUpdate.FormTitle = contact.FormTitle;
            contactToUpdate.FormDescription = contact.FormDescription;
            contactToUpdate.FormActionText = contact.FormActionText;

            _context.SaveChanges();
        }

        public void UpdateCovered(CoveredContact coveredToUpdate, CoveredContact covered)
        {
            coveredToUpdate.ModifiedDate = DateTime.Now;
            coveredToUpdate.Status = covered.Status;
            coveredToUpdate.Title = covered.Title;
            coveredToUpdate.Text = covered.Text;
            coveredToUpdate.ActionText = covered.ActionText;

            _context.SaveChanges();
        }

        public void UpdateFaq(Faq faqToUpdate, Faq faq)
        {
            faqToUpdate.ModifiedDate = DateTime.Now;
            faqToUpdate.Status = faq.Status;
            faqToUpdate.Question = faq.Question;
            faqToUpdate.Answer = faq.Answer;

            _context.SaveChanges();
        }

        public void UpdateLikeAble(LikeableArea likeableToUpdate, LikeableArea likeableArea)
        {
            likeableToUpdate.ModifiedDate = DateTime.Now;
            likeableToUpdate.Status = likeableArea.Status;
            likeableToUpdate.Title = likeableArea.Title;
            likeableArea.Text = likeableArea.Text;

            _context.SaveChanges();
        }

        public void UpdateNewTo(NewTo newToUpdate, NewTo newTo)
        {
            newToUpdate.ModifiedDate = DateTime.Now;
            newToUpdate.Status = newTo.Status;
            newToUpdate.Title = newTo.Title;
            newToUpdate.Text = newTo.Text;
            newToUpdate.Entry = newTo.Entry;
            newToUpdate.ImageText = newTo.ImageText;

            _context.SaveChanges();
        }

        public void UpdateSLiderİtem(SliderItem sliderToUpdate, SliderItem sliderItem)
        {
            sliderToUpdate.ModifiedDate = DateTime.Now;
            sliderToUpdate.Status = sliderItem.Status;
            sliderToUpdate.Title = sliderItem.Title;
            sliderToUpdate.Slogan = sliderItem.Slogan;
            sliderToUpdate.ActionText = sliderItem.ActionText;

            _context.SaveChanges();
        }

        public void UpdateTestimonial(Testimonial testimonialToupdate, Testimonial testimonial)
        {
            testimonialToupdate.ModifiedDate = DateTime.Now;
            testimonialToupdate.Status = testimonial.Status;
            testimonialToupdate.WriterName = testimonial.WriterName;
            testimonialToupdate.WriterDesc = testimonial.WriterDesc;
            testimonialToupdate.Text = testimonial.Text;

            _context.SaveChanges();
        }
    }
}
