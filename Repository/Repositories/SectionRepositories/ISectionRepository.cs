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
       public IEnumerable<Testimonial> GetAllTestimonials();
       public Testimonial CreateTestimonail(Testimonial model);
       public Testimonial GetTestimonialById(int id);
       public void UpdateTestimonial(Testimonial testimonialToupdate, Testimonial testimonial);
       public void DeleteTestimonial(Testimonial testimonial);
        public IEnumerable<LikeableArea> GetAllLikeableArea();
        public LikeableArea GetLikeableAreaById(int? id);
        public LikeableArea RemovePhoto(int? id);
        public void UpdateLikeAble(LikeableArea likeableToUpdate, LikeableArea likeableArea);
        public IEnumerable<Faq> GetAllFaqs();
        public Faq CreateFaq(Faq model);
        public Faq GetFaqById(int id);
        public void UpdateFaq(Faq faqToUpdate, Faq faq);
        public void DeleteFaq(Faq faq);
        public IEnumerable<Contact> GetAllContact();
        public Contact GetContactById(int id);
        public void UpdateConact(Contact contactToUpdate, Contact contact);
        public IEnumerable<NewTo> GetAllNewTo();
        public NewTo GetNewToById(int? id);
        public NewTo RmovePhoto(int? id);
        public void UpdateNewTo(NewTo newToUpdate, NewTo newTo);
        public IEnumerable<CoveredContact> GetAllCovereds();
        public CoveredContact GetCoveredById(int? id);
        public CoveredContact RemovePhoto1(int? id);
        public void UpdateCovered(CoveredContact coveredToUpdate, CoveredContact covered);
        public SliderItem RemoveSLiderPhoto(int? id);
        public IEnumerable<SliderItem> GetAllSliderItems();
        public SliderItem GetSliderItemById(int? id);
        public void UpdateSLiderİtem(SliderItem sliderToUpdate, SliderItem sliderItem);
        public SliderItem CreateSLiderItem(SliderItem model);
        public void DeleteSLiderItem(SliderItem sliderItem);
        public IEnumerable<LikeableArea> GetLikeableAreas();
        public Brand RemoveBrandPhoto(int? id);
        public IEnumerable<Brand> GetAllBrands();
        public Brand GetBrandById(int? id);
        public Brand CreateBrand(Brand model);
        public void UpdateBrand(Brand brandToUpdate, Brand brand);
        public void DeleteBrand(Brand brand);

    }
}
