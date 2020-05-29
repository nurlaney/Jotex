using AutoMapper;
using Jotex.Models;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SliderItem, SliderItemViewModel>();

            CreateMap<AboutCompany, AboutCompanyViewModel>();
            CreateMap<AboutCompanyEncourage, AboutEncourageViewModel>();
            CreateMap<AboutCompanyFunFact, AboutFunFactViewModel>();

            //home page
            CreateMap<Agent, AgentViewModel>();
            CreateMap<Brand, BrandViewModel>();
            CreateMap<Testimonial, TestimonialViewModel>();
            CreateMap<LikeableArea, LikeAbleViewModel>();
            CreateMap<NewTo, NewToViewModel>();
            CreateMap<Setting, SettingViewModel>();

            //pages
            CreateMap<ServiceSpec, ServiceSpecViewModel>();
            CreateMap<Service, ServiceViewModel>();
            CreateMap<Service, ServiceListViewModel>();

            CreateMap<Faq, FaqViewModel>();

            CreateMap<CaseStudy, CaseStudyViewModel>();
            CreateMap<CaseStudySpec, CaseStudySpecViewModel>();
            
            CreateMap<Contact, ContactViewModel>();


            CreateMap<Plan, PlanViewModel>()
                .ForMember(p => p.PlanDetails, opt => opt.MapFrom(src => src.Details.Select(d => d.Condition)));

            CreateMap<Label, LabelViewModel>();
            CreateMap<CoveredContact, ContactSectionViewModel>();
            
            
            CreateMap<Blog, BlogViewModel>();

            CreateMap<Comment, CommentViewModel>();
            CreateMap<CommentViewModel, Comment>();
        }
    }
}
