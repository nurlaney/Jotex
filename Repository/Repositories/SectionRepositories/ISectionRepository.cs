using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.SectionRepositories
{
   public interface ISectionRepository
    {
       public IEnumerable<SliderItem> GetSliderItems();
       public IEnumerable<Brand> GetBrands();
       public IEnumerable<Testimonial> GetTestimonials();
       public IEnumerable<NewTo> GetNewTo();
       public IEnumerable<CoveredContact> GetSectionItems();
       public IEnumerable<Faq> GetFaqs();
       public Faq GetFaqById(int? id);
        public IEnumerable<Contact> GetContacts();

    }
}
