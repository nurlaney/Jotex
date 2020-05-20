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
            CreateMap<AboutCompany, AboutCompanySectionViewModel>();
            CreateMap<AboutCompanyBanner, AboutCompanyBannerViewModel>();
            CreateMap<AboutCompanyEncourage, AboutPageEncourageViewModel>();
            CreateMap<Agent, AgentViewModel>();
            CreateMap<Brand, BrandViewModel>();
            CreateMap<Testimonial, TestimonialViewModel>();
            CreateMap<AboutCompanyFunFact, AboutSectionFunFactViewModel>();
            CreateMap<ServiceDetail, ServiceDetailsViewModel>();
            CreateMap<ServiceSpec, ServiceSpecViewModel>();
            CreateMap<Service, ServiceViewModel>();
            CreateMap<Service, ServiceListViewModel>();
            CreateMap<LikeableArea, LikeAbleViewModel>();
            CreateMap<Plan, PlanViewModel>()
                .ForMember(p => p.PlanDetails, opt => opt.MapFrom(src => src.Details.Select(d => d.Condition)));
            CreateMap<Label, LabelViewModel>();
        }
    }
}
