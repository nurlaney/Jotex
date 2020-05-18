using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.SectionRepositories
{
   public interface ISectionRepository
    {
        IEnumerable<SliderItem> GetSliderItems();
        IEnumerable<Brand> GetBrands();
        IEnumerable<Testimonial> GetTestimonials();
    }
}
